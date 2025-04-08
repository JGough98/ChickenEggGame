using Assets.TowerDefense.Scripts.Agents;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	// So this should take in a set of recourses and check if this can be combined together.
	public interface IRecourseFactory
	{
		public int TotalInputsRequired
		{
			get;
		}

		public GameObject CreateRecourse(
			List<ConveyorItemType> conveyorItemRecourseTypes);

		public bool ShouldReject(
			List<ConveyorItemType> currentConveyorItemTypes,
			ConveyorItemType conveyorItemType);

		public void Initialize(
			GameObject parent,
			GameObject position);
	}
}