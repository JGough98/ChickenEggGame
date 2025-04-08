using Assets.TowerDefense.Scripts.Agents;
using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	[CreateAssetMenu(fileName = "AmmunitionProduction-", menuName = "ScriptableObjects/FactoryProduction/Ammunition", order = 5)]
	public class ProducedAmmunition : ScriptableObject
	{
		public NaturalRecourseType NaturalRecourseType;

		public GameObject CreatedAmmunition;
	}
}