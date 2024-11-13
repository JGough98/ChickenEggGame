using System.Linq;
using UnityEngine;
using UnityEngine.AI;


namespace Assets.TowerDefense.Scripts.Agents.Actions.ComplexActions
{
	using BlackBoard;
	using Enums;
	using Utility;
	using InstructionData;
	using Interfaces;
	using IntializeData;


	public class CollectAllRecoursesOfType :
		IInitializeAction<CollectAllRecoursesOfTypeInstructions, CollectAllRecoursesOfTypeIntializeData>
	{
		private BlackBoardSceneData blackBoardSceneData;

		private NavMeshAgent agent;

		private ERecourseType recouseToCollect;

		private IStartAction<Vector3> moveTooAction;

		private IStartAction<RecourseDeposit> collectRecourse;

		private IAction mineThenDepositAction;


		public void Initialize(
			CollectAllRecoursesOfTypeIntializeData intializeData)
		{
			blackBoardSceneData = intializeData.BlackBoardSceneData;
			moveTooAction = intializeData.MoveTooAction;
			collectRecourse = intializeData.CollectRecourse;
		}

		public bool Start(
			CollectAllRecoursesOfTypeInstructions instructions)
		{
			agent = instructions.Agent;
			recouseToCollect = instructions.RecourseToCollect;

			return TryMiningRecourse();
		}

		public bool IsFinished()
		{
			if (!mineThenDepositAction.IsFinished())
			{
				return false;
			}

			return TryMiningRecourse();
		}

		public void Cancel()
			=> mineThenDepositAction.Cancel();


		private bool TryMiningRecourse()
		{
			var availableRecourses = blackBoardSceneData.Recourses
				.Where(x => x.Type == recouseToCollect && x.HasRecourses);
			var availableDropOffs = blackBoardSceneData.DropOffs
				.Where(x => x.AcceptsRecourse(recouseToCollect));

			if (!MonoBehaviourUtlility.FindNearest(availableRecourses, agent.transform.position, out var nearestRecourse)
				|| !MonoBehaviourUtlility.FindNearest(availableDropOffs, nearestRecourse.transform.position, out var nearestDropOff))
				return true;

			// What if were already holding items?
			mineThenDepositAction = ActionCombinerUtility.CombinedAction(
				(moveTooAction, () => moveTooAction.Start(nearestRecourse.transform.position)),
				(collectRecourse, () => collectRecourse.Start(nearestRecourse)),
				(moveTooAction, () => moveTooAction.Start(nearestDropOff.transform.position)));

			return false;
		}
	}
}