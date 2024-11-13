using System.Linq;
using UnityEngine;


namespace Assets.TowerDefence.Scripts
{
	using Agents;
	using Agents.Actions.BaseAction;
	using Agents.Actions.ComplexActions;
	using Agents.Actions.InstructionData;
	using Agents.Actions.IntializeData;
	using BlackBoard;
	using Enums;


	[RequireComponent(typeof(BlackBoardController))]
	public class GameController : MonoBehaviour
	{
		[SerializeField]
		private BlackBoardController blackBoard;

		[SerializeField]
		private RunWaySpawner enamySpawner;

		[SerializeField]
		private Enamy enamyExample;

		[SerializeField]
		private Turret turretExample;

		private AgentManager agentManager = new AgentManager();


		public void Start()
		{
			var agent = blackBoard.Data.Drones.FirstOrDefault();

			var goCollectRecourses = new CollectAllRecoursesOfType();

			var moveAction = new ActionMoveToPoint();
			var collectRecourse = new ActionCollectRecource();

			moveAction.Intialize(
				agent.NavMeshAgent);

			goCollectRecourses.Intialize(
				new CollectAllRecoursesOfTypeIntializeData(
					moveAction,
					collectRecourse,
					blackBoard.Data));

			goCollectRecourses.Start(
				new CollectAllRecoursesOfTypeInstructionsData(
					ERecourseType.IRON,
					agent.NavMeshAgent));

			agentManager.AddAgents(
				enamySpawner.SpwanAtRunWay(enamyExample),
				goCollectRecourses);
		}


		public void Update()
		{
			agentManager.PeformAgentActions();
		}

		public void Reset()
		{
			blackBoard = gameObject.GetComponent<BlackBoardController>();
			blackBoard.Reset();
		}
	}
}