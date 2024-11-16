namespace Assets.TowerDefense.Scripts.Agents.Actions.BaseAction
{
	using Utility;
	using Interfaces;
	using IntializeData;
	using UnityEngine;

	public class ShootAction : IInitializeAction<ShootActionStart, IFacingDirection>
	{
		private float rateOfFire;

		private Bullet amunitionType;

		private IFacingDirection facingDirection;

		private ITimer roundTimer = new Timer();

		private Transform roundPosition;


		public void Initialize(IFacingDirection data)
		{
			this.facingDirection = data;
		}

		public bool Start(
			ShootActionStart instructions)
		{
			this.amunitionType = instructions.Bullet;
			this.rateOfFire = instructions.RateOfFire;
			this.roundPosition = instructions.Barrel;

			return true;
		}

		public bool Update()
		{
			var firedRound = facingDirection.IsFacing && roundTimer.Finished;

			if (firedRound)
				Fire();

			return firedRound;
		}

		public void Cancel() { }


		private void Fire()
		{
			var nextBullet = GameController.Instantiate(
				amunitionType,
				roundPosition.position,
				amunitionType.transform.rotation);

			nextBullet.SetVelocity(
				facingDirection.Rotation.eulerAngles.normalized * 8);

			roundTimer.Start(
				rateOfFire);
		}
	}
}