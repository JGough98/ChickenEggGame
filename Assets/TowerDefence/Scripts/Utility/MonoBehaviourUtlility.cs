using System.Collections.Generic;
using UnityEngine;


namespace Assets.TowerDefense.Scripts.Utility
{
	public static class MonoBehaviourUtlility
	{
		public static bool FindNearest<T>(
			this IEnumerable<T> items,
			Vector3 position,
			out T closestItem)
			where T : MonoBehaviour
		{
			var closest = float.MaxValue;
			closestItem = null;

			foreach (var item in items)
			{
				var straightLineDistance = Vector3.Distance(
					item.transform.position,
					position);

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