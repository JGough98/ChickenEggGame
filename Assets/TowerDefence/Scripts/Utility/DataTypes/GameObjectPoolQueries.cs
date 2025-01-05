using System.Collections.Generic;
using UnityEngine;


namespace Assets.TowerDefense.Scripts.Utility.DataTypes
{
	using GO;


	public class GameObjectPoolQueries :
		IObjectPoolQuery<GameObject, GameObjectPoolInitializeData, GameObjectInitializeData>
	{
		private GameObjectPoolInitializeData? initializeData;


		public void Initialize(GameObjectPoolInitializeData initializeData)
			=> this.initializeData = initializeData;

		public void Remove(IEnumerable<GameObject> removedItems)
		{
			foreach(var item in removedItems)
			{
				item.SetActive(false);
			}
		}

		public void Reset(IEnumerable<GameObject> resetItems)
		{
			if (initializeData != null)
			{
				initializeData!.Value.InstantiatedItem.SetActive(false);
				Remove(resetItems);
			}
		}

		public GameObject Add(GameObjectInitializeData itemInitializeData)
			=> GameObjectUtility.Instantiate(
				initializeData!.Value.InstantiatedItem,
				initializeData!.Value.ParentTransform,
				itemInitializeData.Position,
				itemInitializeData.Rotation,
				itemInitializeData.IsActive);
	}
}