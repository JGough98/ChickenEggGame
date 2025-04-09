using System.Collections.Generic;
using UnityEngine;


namespace Assets.TowerDefense.Scripts.Utility.GO
{
	public enum SpawnType
	{
		BUILDING,
		RECOURSE,
	}


	public static class GameObjectUtility
	{
		private static Dictionary<SpawnType, Transform> parentSpawn;


		public static void Intialize(Dictionary<SpawnType, Transform> parentSpawn)
			=> GameObjectUtility.parentSpawn = parentSpawn;

		public static GameObject Instantiate(
			GameObject item,
			Transform parent,
			Vector3 position,
			Vector3 rotation,
			bool shown)
		{
			var placed = GameObject.Instantiate(
				item,
				new Vector3(position.x, position.y + HalfHeihgt(item), position.z),
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
			var renderer = item.GetComponentInChildren<Renderer>();
			var height = renderer.bounds.size.y;
			var placed = GameObject.Instantiate(
				item,
				new Vector3(position.x, position.y + HalfHeihgt(item), position.z),
				item.transform.rotation,
				parent.transform);

			placed.SetActive(shown);

			return placed;
		}

		public static GameObject Instantiate(
			GameObject item,
			Vector3 position,
			SpawnType spawnType,
			bool shown)
		{
			var placed = GameObject.Instantiate(
				item,
				new Vector3(position.x, position.y + HalfHeihgt(item), position.z),
				item.transform.rotation,
				parentSpawn[spawnType]);

			placed.SetActive(shown);

			return placed;
		}


		public static float HalfHeihgt(GameObject item)
		{
			var renderer = item.GetComponentInChildren<Renderer>();
			return renderer.bounds.size.y / 2;
		}
	}
}