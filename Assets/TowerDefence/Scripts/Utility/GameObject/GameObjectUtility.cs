using UnityEngine;


namespace Assets.TowerDefense.Scripts.Utility.GO
{
	public static class GameObjectUtility
	{
		public static GameObject Instantiate(
			GameObject item,
			Transform parent,
			Vector3 position,
			Vector3 rotation,
			bool shown)
		{
			var placed = GameObject.Instantiate(
				item,
				position,
				Quaternion.LookRotation(rotation),
				parent.transform);

			placed.SetActive(shown);

			return placed;
		}

		public static GameObject Instantiate(
			GameObject item,
			Transform parent,
			Vector3 position,
			bool shown)
		{
			var placed = GameObject.Instantiate(
				item,
				position,
				item.transform.rotation,
				parent.transform);

			placed.SetActive(shown);

			return placed;
		}
	}
}