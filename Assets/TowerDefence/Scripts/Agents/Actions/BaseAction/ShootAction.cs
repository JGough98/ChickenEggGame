namespace Assets.TowerDefense.Scripts.Agents.Actions.BaseAction
{
	using Interfaces;
	using IntializeData;


	public class ShootAction : IStartAction<ShootActionSetup>
	{
		private Bullet amunitionType;

		private IFacingDirection facingDirection;


		public void Cancel()
		{

		}

		public bool IsFinished()
		{
			if(facingDirection.IsFacing)
			{
				var nextBullet = GameController.Instantiate(amunitionType);
			}

			return false;
		}

		public bool Start(ShootActionSetup instructions)
		{
			this.facingDirection = instructions.FacingDirection;
			this.amunitionType = instructions.Bullet;

			return true;
		}
	}
}