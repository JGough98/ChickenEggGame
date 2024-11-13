namespace Assets.TowerDefence.Scripts.Agents.Actions.IntializeData
{
	using BlackBoard;
	using Interfaces;


	public struct ShootAtTargeIntializeData
	{
		public BlackBoardSceneData BlackBoardSceneData
		{
			get;
			private set;
		}

		public IInitializeAction<IPosition, RotateActionSetup> RotateTowardsAction
		{
			get;
			private set;
		}

		public IStartAction<ShootActionSetup> ShootAction
		{
			get;
			private set;
		}

		public Turret Turret
		{
			get;
			private set;
		}


		public ShootAtTargeIntializeData(
			BlackBoardSceneData blackBoardSceneData,
			IInitializeAction<IPosition, RotateActionSetup> rotateTowardsAction,
			IStartAction<ShootActionSetup> shootAction,
			Turret turret)
		{
			this.BlackBoardSceneData = blackBoardSceneData;
			this.RotateTowardsAction = rotateTowardsAction;
			this.ShootAction = shootAction;
			this.Turret = turret;
		}
	}
}