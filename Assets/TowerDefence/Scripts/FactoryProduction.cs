using Assets.TowerDefense.Scripts.Agents;
using Assets.TowerDefense.Scripts.Utility.GO;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	public abstract class FactoryProduction : MonoBehaviour, IRecourseFactory
	{
		protected GameObject parent;
		protected GameObject position;


		public abstract int TotalInputsRequired { get; }


		public void Initialize(GameObject parent, GameObject position)
		{
			this.parent = parent;
			this.position = position;
		}


		public abstract GameObject CreateRecourse(List<ConveyorItemType> conveyorItemRecourseTypes);

		public abstract bool ShouldReject(List<ConveyorItemType> currentConveyorItemTypes, ConveyorItemType conveyorItemType);


		protected GameObject InstantiateNewItem(GameObject newItem)
			=> GameObjectUtility.Instantiate(
				newItem,
				parent.transform,
				position.transform.position,
				Vector3.zero,
				true);
	}
}