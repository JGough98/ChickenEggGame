using UnityEngine;


namespace Assets.TowerDefense.Scripts.Utility.Physics
{
	public static class Vector3Extensions
	{
		public static Vector3 Inverse(this Vector3 v)
			=> new Vector3(-v.x, -v.y, -v.z);
	}
}