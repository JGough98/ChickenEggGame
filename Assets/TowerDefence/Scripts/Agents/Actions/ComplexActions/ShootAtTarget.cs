using UnityEngine.AI;


namespace Assets.TowerDefence.Scripts.Agents.Actions.ComplexActions
{
	using BlackBoard;
	using InstructionData;
	using Interfaces;
	using IntializeData;
	using System;

	public class ShootAtTarget : IInitializeAction<CollectAllRecoursesOfTypeInstructionsData, CollectAllRecoursesOfTypeIntializeData>
	{
		private BlackBoardSceneData blackBoardSceneData;

		private NavMeshAgent agent;

		private IStartAction<IPosition> rotateTowardsAction;

		private IStartAction<ShootActionSetup> shootAction;

		private IAction shootRotate;


		public void Cancle()
		{
			throw new System.NotImplementedException();
		}

		public void Intialize(CollectAllRecoursesOfTypeIntializeData intializeData)
		{
			throw new System.NotImplementedException();
		}

		public bool IsFinished()
		{
			throw new System.NotImplementedException();
		}

		public bool Start(CollectAllRecoursesOfTypeInstructionsData instructions)
		{
			throw new NotImplementedException();

			/*rotateTowardsAction.Start();
			shootAction.Start();*/
		}
	}
}