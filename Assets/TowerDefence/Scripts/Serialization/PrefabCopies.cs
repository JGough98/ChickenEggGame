using UnityEngine;


namespace Assets.TowerDefense.Scripts.Serialization
{
	/// <summary>
	/// This class is used as the Parent Transform to place the instantiated objects within.
	/// Used as a bit of a hacky solution to get around prefabs having their values modified at runtime.
	/// </summary>
	public class PrefabCopies : MonoBehaviour
	{
		private static Transform prefabCopiesTranform;


		public static Transform Transform => prefabCopiesTranform;


		private void Awake()
		{
			if (prefabCopiesTranform != null)
			{
				throw new System.InvalidOperationException("PrefabCopies is attempting to be serialized more than once.");
			}

			prefabCopiesTranform = gameObject.transform;
		}
	}
}