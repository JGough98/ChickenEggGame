using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	public static class Vector3Extensions
	{
		/// <summary>
		/// Rounds Vector3.
		/// </summary>
		/// <param name="v"></param>
		/// <param name="decimalPlaces"></param>
		/// <returns></returns>
		public static Vector3 Round(this Vector3 v, int decimalPlaces = 3)
		{
			var multiplier = Mathf.Pow(10, decimalPlaces);

			return new Vector3(
				Mathf.Round(v.x * multiplier) / multiplier,
				Mathf.Round(v.y * multiplier) / multiplier,
				Mathf.Round(v.z * multiplier) / multiplier);
		}
	}
}