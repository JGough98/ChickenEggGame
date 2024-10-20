using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;


namespace Assets.TowerDefence.Scripts.Agents.Actions
{
	using Assets.TowerDefence.Scripts.BlackBoard;
	using Assets.TowerDefence.Scripts.Utility;
	using InstructionData;
	using Interfaces;
	using IntializeData;


	public class ActionCollectAllRecoursesOfType :
		IInitializeAction<CollectAllRecoursesOfTypeInstructionsData, CollectAllRecoursesOfTypeIntializeData>
	{
		private BlackBoardSceneData blackBoardSceneData;

		private NavMeshAgent agent;

		private ERecourseType recouseToCollect;

		private IStartAction<Vector3> moveTooAction;

		private IStartAction<RecourseDeposit> collectRecourse;

		private IAction mineThenDepositAction;


		public void Intialize(
			CollectAllRecoursesOfTypeIntializeData intializeData)
		{
			blackBoardSceneData = intializeData.BlackBoardSceneData;
			moveTooAction = intializeData.MoveTooAction;
			collectRecourse = intializeData.CollectRecourse;
		}


		public bool Start(
			CollectAllRecoursesOfTypeInstructionsData instructions)
		{
			agent = instructions.Agent;
			recouseToCollect = instructions.RecouseToCollect;

			return TryMiningRecourse();
		}


		public bool Perform()
			=> mineThenDepositAction.Perform();

		public void Cancle()
			=> mineThenDepositAction.Cancle();


		private bool TryMiningRecourse()
		{
			var availableRecourses = blackBoardSceneData.Recourses
				.Where(x => x.Type == recouseToCollect);
			var availableDropOffs = blackBoardSceneData.DropOffs
				.Where(x => x.AcceptsRecourse(recouseToCollect));

			if (!MonoBehaviourUtlility.FindNearest(availableRecourses, agent.transform.position, out var nearestRecourse)
				|| !MonoBehaviourUtlility.FindNearest(availableDropOffs, nearestRecourse.transform.position, out var nearestDropOff))
				return false;

			var actionsQueue = new Queue<(IAction performingAction, Action start)>();

			actionsQueue.Enqueue(new(moveTooAction, () => moveTooAction.Start(nearestRecourse.transform.position)));
			actionsQueue.Enqueue(new(collectRecourse, () => collectRecourse.Start(nearestRecourse)));
			actionsQueue.Enqueue(new(moveTooAction, () => moveTooAction.Start(nearestDropOff.transform.position)));

			mineThenDepositAction = new ActionCombiner(actionsQueue);

			return true;
		}
	}
}