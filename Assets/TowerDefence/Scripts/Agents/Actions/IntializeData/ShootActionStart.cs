using UnityEngine;

namespace Assets.TowerDefense.Scripts.Agents.Actions.IntializeData
{
	public struct ShootActionStart
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

		public Transform Barrel
		{
			get;
			private set;
		}


		public ShootActionStart(
			float rateOfFire,
			Bullet bullet,
			Transform barrel)
		{
			this.RateOfFire = rateOfFire;
			this.Bullet = bullet;
			this.Barrel = barrel;
		}
	}
}