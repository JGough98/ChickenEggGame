using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;


namespace Assets.TowerDefence.Scripts
{
	using Agents;
	using Agents.Actions.BaseAction;
	using Agents.Actions.ComplexActions;
	using Agents.Actions.InstructionData;
	using Agents.Actions.IntializeData;
	using Agents.Actions.Interfaces;
	using Enums;
	using BlackBoard;


	[RequireComponent(typeof(BlackBoardController))]
	public class GameController : MonoBehaviour
	{
		[SerializeField]
		private BlackBoardController blackBoard;

		[SerializeField]
		private EnamySpawner enamySpawner;

		[SerializeField]
		private Enamy enamyExample;

		[SerializeField]
		private Turret turretExample;


		private List<IAction> agentActions = new List<IAction>();


		public void Start()
		{
			var agent = blackBoard.Data.Drones.FirstOrDefault();
			var navMeshAgent = agent.GetComponent<NavMeshAgent>();

			var goCollectRecourses = new CollectAllRecoursesOfType();

			var moveAction = new ActionMoveToPoint();
			var collectRecourse = new ActionCollectRecource();

			moveAction.Intialize(
				navMeshAgent);

			goCollectRecourses.Intialize(
				new CollectAllRecoursesOfTypeIntializeData(
					moveAction,
					collectRecourse,
					blackBoard.Data));

			goCollectRecourses.Start(
				new CollectAllRecoursesOfTypeInstructionsData(ERecourseType.IRON, navMeshAgent));

			agentActions.Add(
				enamySpawner.SpwanEnamy(enamyExample));
			agentActions.Add(
				goCollectRecourses);
		}


		public void Update()
		{
			foreach(var e in agentActions)
			{
				e.IsFinished();
			}
		}

		public void Reset()
		{
			blackBoard = gameObject.GetComponent<BlackBoardController>();
			blackBoard.Reset();
		}
	}
}