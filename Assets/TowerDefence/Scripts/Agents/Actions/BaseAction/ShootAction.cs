namespace Assets.TowerDefence.Scripts.Agents.Actions.BaseAction
{
	using Interfaces;
	using IntializeData;


	public class ShootAction : IStartAction<ShootActionSetup>
	{
		private Bullet amunitionType;

		private IFacingDirection facingDirection;


		public void Cancle()
		{

		}

		public bool IsFinished()
		{
			if(facingDirection.Isfacing)
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