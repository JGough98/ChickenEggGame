using UnityEngine;


namespace Assets.TowerDefense.ScriptableObjects
{
	[CreateAssetMenu(fileName = "AmunitionTypeData-", menuName = "ScriptableObjects/AmunitionType", order = 5)]
	public class AmunitionTypeData : ScriptableObject
	{
		[SerializeField]
		private float velocity;



		public float Velocity => velocity;
	}
}