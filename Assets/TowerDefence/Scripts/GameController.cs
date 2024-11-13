using System.Linq;
using UnityEngine;


namespace Assets.TowerDefense.Scripts
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

			var droneGoCollectRecourses = new CollectAllRecoursesOfType();
			var turretShootAction = new ShootAtTarget();

			var moveAction = new ActionMoveToPoint();
			var collectRecourse = new ActionCollectRecourse();
			var shootAction = new ShootAction();
			var rotateAction = new ActionRotate();

			moveAction.Initialize(
				agent.NavMeshAgent);

			droneGoCollectRecourses.Initialize(
				new CollectAllRecoursesOfTypeIntializeData(
					moveAction,
					collectRecourse,
					blackBoard.Data));

			droneGoCollectRecourses.Start(
				new CollectAllRecoursesOfTypeInstructions(
					ERecourseType.IRON,
					agent.NavMeshAgent));

			turretShootAction.Initialize(
				new ShootAtTargeIntializeData(
					blackBoard.Data,
					rotateAction,
					shootAction,
					turretExample));

			// NOT NEEDED!
			turretShootAction.Start(
				new ShootAtTargetInstructions(
					turretExample));

			agentManager.AddAgents(
				enamySpawner.SpwanAtRunWay(enamyExample),
				droneGoCollectRecourses,
				turretShootAction);
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