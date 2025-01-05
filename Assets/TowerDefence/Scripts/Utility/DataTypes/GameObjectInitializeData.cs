using UnityEngine;


namespace Assets.TowerDefense.Scripts.Utility.DataTypes
{
	public struct GameObjectInitializeData
	{
		public bool IsActive
		{
			get;
		}

		public Vector3 Position
		{
			get;
		}
		public Vector3 Rotation
		{
			get;
		}


		public GameObjectInitializeData(
			Vector3 position,
			Vector3 rotation,
			bool isActive)
		{
			Position = position;
			Rotation = rotation;
			IsActive = isActive;
		}
	}
}