using UnityEngine;


namespace Assets.TowerDefence.Scripts.Agents.Actions.IntializeData
{
	using Assets.TowerDefence.Scripts.Agents;
	using BlackBoard;
	using Interfaces;


	public struct CollectAllRecoursesOfTypeIntializeData
	{
		public BlackBoardSceneData BlackBoardSceneData
		{
			get;
			private set;
		}

		public IStartAction<Vector3> MoveTooAction
		{
			get;
			private set;
		}

		public IStartAction<RecourseDeposit> CollectRecourse
		{
			get;
			private set;
		}


		public CollectAllRecoursesOfTypeIntializeData(
			IStartAction<Vector3> moveTooAction,
			IStartAction<RecourseDeposit> collectRecourse,
			BlackBoardSceneData blackBoardSceneData)
		{
			MoveTooAction = moveTooAction;
			CollectRecourse = collectRecourse;
			BlackBoardSceneData = blackBoardSceneData;
		}
	}
}