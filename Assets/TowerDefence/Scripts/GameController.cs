using System.Linq;
using UnityEngine;
using UnityEngine.AI;


namespace Assets.TowerDefence.Scripts
{
	using Agents.Actions.BaseAction;
	using Agents.Actions.ComplexActions;
	using Agents.Actions.InstructionData;
	using Agents.Actions.IntializeData;
	using Assets.TowerDefence.Scripts.Enums;
	using BlackBoard;


	public class GameController : MonoBehaviour
	{
		[SerializeField]
		private BlackBoardController blackBoard;

		private CollectAllRecoursesOfType goCollectRecourses;


		public void Start ()
		{
			var agent = blackBoard.Data.Drones.FirstOrDefault();
			var navMeshAgent = agent.GetComponent<NavMeshAgent>();

			goCollectRecourses = new CollectAllRecoursesOfType();

			var moveAction = new ActionMoveToPoint();
			var collectRecourse = new ActionCollectRecource();

			moveAction.Intialize(navMeshAgent);

			goCollectRecourses.Intialize(new CollectAllRecoursesOfTypeIntializeData(moveAction, collectRecourse, blackBoard.Data));

			goCollectRecourses.Start(new CollectAllRecoursesOfTypeInstructionsData(ERecourseType.IRON, navMeshAgent));
		}


		public void FixedUpdate()
		{
			goCollectRecourses.Perform();
		}
	}
}