namespace Assets.TowerDefense.Scripts.Agents.Actions.IntializeData
{
	using ComplexActions;
	using Interfaces;
	using UnityEngine;

	public struct ShootAtTargetInitializeData
	{
		public IInitializeAction<IPosition, RotateActionSetup> RotateTowardsAction
		{
			get;
			private set;
		}

		public IInitializeAction<ShootActionStart, IFacingDirection> ShootAction
		{
			get;
			private set;
		}

		public ITargetSelector TargetSelector
		{
			get;
			private set;
		}

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

		public Transform Barrel
		{
			get;
			private set;
		}

		public AmmunitionFeed Magazine
		{
			get;
			private set;
		}


		public ShootAtTargetInitializeData(
			IInitializeAction<IPosition, RotateActionSetup> rotateTowardsAction,
			IInitializeAction<ShootActionStart, IFacingDirection> shootAction,
			ITargetSelector targetSelector,
			float rateOfFire,
			Bullet bullet,
			Transform barrel,
			AmmunitionFeed magazine)
		{
			this.RotateTowardsAction = rotateTowardsAction;
			this.ShootAction = shootAction;
			this.TargetSelector = targetSelector;
			this.RateOfFire = rateOfFire;
			this.Bullet = bullet;
			this.Barrel = barrel;
			this.Magazine = magazine;
		}
	}
}