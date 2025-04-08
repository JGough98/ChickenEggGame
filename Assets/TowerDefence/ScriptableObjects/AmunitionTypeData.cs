using UnityEngine;


namespace Assets.TowerDefense.ScriptableObjects
{
	[CreateAssetMenu(fileName = "AmunitionTypeData-", menuName = "ScriptableObjects/AmmunitionType", order = 5)]
	public class AmunitionTypeData : ScriptableObject
	{
		[SerializeField]
		private float velocity;



		public float Velocity => velocity;
	}
}