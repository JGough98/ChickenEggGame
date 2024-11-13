namespace Assets.TowerDefense.Scripts.Agents.Actions.IntializeData
{
	using Interfaces;


	public struct ShootActionSetup
	{
		public float RateOfFire
		{
			get;
			private set;
		}

		public Bullet Bullet
		{
			get;
			private set;
		}

		public IFacingDirection FacingDirection
		{
			get;
			private set;
		}


		public ShootActionSetup(
			float rateOfFire,
			Bullet bullet,
			IFacingDirection facingDirection)
		{
			this.RateOfFire = rateOfFire;
			this.Bullet = bullet;
			this.FacingDirection = facingDirection;
		}
	}
}