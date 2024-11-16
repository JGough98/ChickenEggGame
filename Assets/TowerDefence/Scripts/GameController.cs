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

		[SerializeField]
		private Bullet turretBulletExample;


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
			rotateAction.Initialize(
				new RotateActionSetup(
					turretExample,
					5));
			shootAction.Initialize(
				rotateAction);

			droneGoCollectRecourses.Initialize(
				new CollectAllRecoursesOfTypeIntializeData(
					moveAction,
					collectRecourse,
					blackBoard.Data));

			droneGoCollectRecourses.Start(
				new CollectAllRecoursesOfTypeInstructions(
					ERecourseType.IRON,
					agent.NavMeshAgent));

			turretShootAction.Start(
				new ShootAtTargetInitializeData(
					rotateAction,
					shootAction,
					new TargetSelectorClosest(turretExample.FieldOfView),
					0.6f,
					turretBulletExample,
					turretExample.BarrelRoundStart));

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