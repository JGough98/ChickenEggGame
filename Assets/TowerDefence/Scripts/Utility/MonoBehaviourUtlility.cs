using System.Collections.Generic;
using UnityEngine;


namespace Assets.TowerDefence.Scripts.Utility
{
	public static class MonoBehaviourUtlility
	{
		public static bool FindNearest<T>(
			IEnumerable<T> items,
			Vector3 positionToTravelToo,
			out T closestItem)
				where T : MonoBehaviour
		{
			var closest = float.MaxValue;
			closestItem = null;

			foreach (var item in items)
			{
				var straightLineDistance = Vector3.Distance(
					item.transform.position,
					positionToTravelToo);

				if (straightLineDistance < closest)
				{
					closest = straightLineDistance;
					closestItem = item;
				}
			}

			return closestItem != null;
		}
	}
}