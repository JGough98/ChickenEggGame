using UnityEngine;


namespace Assets.TowerDefence.Scripts.Agents
{
	public class AmunitionType : ScriptableObject
	{
		[SerializeField]
		private float velocity;



		public float Velocity => velocity;
	}
}