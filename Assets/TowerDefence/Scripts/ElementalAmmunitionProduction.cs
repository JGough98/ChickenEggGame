using Assets.TowerDefense.Scripts.Agents;
using System;
using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	[CreateAssetMenu(fileName = "ElementalAmmunitionProduction-", menuName = "ScriptableObjects/FactoryProduction/ElementalAmmunition", order = 2)]
	public class ElementalAmmunitionProduction : ScriptableObject
	{
		public AmmunitionType NaturalRecourseType;

		public ElementType ElementType;

		public GameObject CreatedElementalAmmunition;
		
		
		public Tuple<ElementType, AmmunitionType> ElementToAmmunition => new Tuple<ElementType, AmmunitionType>(
			ElementType,
			NaturalRecourseType);
	}
}