using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	using Utility.GO;


	public class ParentSpawner : MonoBehaviour
	{
		[SerializeField]
		private SpawnType spawnType;


		public Transform Parent => transform.parent;

		public SpawnType SpawnType => spawnType;
	}
}