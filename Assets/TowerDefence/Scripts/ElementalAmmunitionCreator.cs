using Assets.TowerDefense.Scripts.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	public class ElementalAmmunitionCreator : FactoryProduction
	{
		[SerializeField]
		private List<ElementalAmmunitionProduction> elementAndAmmunitionToElementalAmmunition;

		private Dictionary<Tuple<ElementType, AmmunitionType>, GameObject> recourseFactory;


		public override int TotalInputsRequired => 2;


		public void Awake()
		{
			recourseFactory = elementAndAmmunitionToElementalAmmunition
				.ToDictionary(
					k => k.ElementToAmmunition,
					v => v.CreatedElementalAmmunition);
		}


		public override GameObject CreateRecourse(
			List<ConveyorItemType> conveyorItemRecourseTypes)
		{
			var elementType = conveyorItemRecourseTypes.First(x => x.ElementType != null);
			var aummuntionType = conveyorItemRecourseTypes.First(x => x.AmmunitionType != null);

			var key = new Tuple<ElementType, AmmunitionType>(
				elementType.ElementType.Value,
				aummuntionType.AmmunitionType.Value);

			return InstantiateNewItem(recourseFactory[key]);
		}

		public override bool ShouldReject(
			List<ConveyorItemType> currentConveyorItemTypes,
			ConveyorItemType nextConveyorItemType)
		{
			switch (nextConveyorItemType.ConstructedType)
			{
				case ConstructedType.AMMUNITION_RECOURSE:
					return currentConveyorItemTypes
						.Any(x => x.ConstructedType == ConstructedType.AMMUNITION_RECOURSE);
				case ConstructedType.ELEMENT_RECOURSE:
					return currentConveyorItemTypes
						.Any(x => x.ConstructedType == ConstructedType.ELEMENT_RECOURSE);
				default:
					return true;
			}
		}
	}
}