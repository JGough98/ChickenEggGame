using UnityEngine;


namespace Assets.TowerDefense.Scripts.Utility.DataTypes
{
	public struct GameObjectPoolInitializeData
	{
		public Transform ParentTransform
		{
			get;
		}

		public GameObject InstantiatedItem
		{
			get;
		}


		public GameObjectPoolInitializeData(
			Transform parentTransform,
			GameObject instantiatedItem)
		{
			ParentTransform = parentTransform;
			InstantiatedItem = instantiatedItem;
		}
	}
}