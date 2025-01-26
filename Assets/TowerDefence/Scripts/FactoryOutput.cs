using Assets.TowerDefense.Scripts.Agents;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	// So this should take in a set of recourses and check if this can be combined together.
	public class FactoryRecourseBuilder
	{
		public bool CanCreate(
			List<ConveyorItemRecourseType> conveyorItemRecourseTypes,
			out GameObject createdObject)
		{
			var canCreate = false;
			createdObject = null;


			return canCreate;
		}
	}


	public class FactoryOutput : MonoBehaviour
	{
		public event AnimationFinished OnOutputProcessed;


		public void PerformOutputAnimation()
		{


			OnOutputProcessed?.Invoke();
		}
	}
}