using Assets.TowerDefense.Scripts.Agents;
using Assets.TowerDefense.Scripts.Utility.GO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	public class AmmunitionProduction : FactoryProduction
	{
		[SerializeField]
		private List<ProducedAmmunition> producedAmmunition;

		private Dictionary<NaturalRecourseType, GameObject> naturalRecourseToAmmunition;


		private void Awake()
		{
			naturalRecourseToAmmunition = producedAmmunition
				.ToDictionary(
					k => k.NaturalRecourseType,
					v => v.CreatedAmmunition);
		}


		// This might need to be edited per type received.
		public override int TotalInputsRequired => 1;


		public override GameObject CreateRecourse(List<ConveyorItemType> conveyorItemRecourseTypes)
		{
			var naturalRecourseType = conveyorItemRecourseTypes.First();

			return InstantiateNewItem(
				naturalRecourseToAmmunition[naturalRecourseType.NaturalRecourseType!.Value]);
		}

		public override bool ShouldReject(
			List<ConveyorItemType> currentConveyorItemTypes,
			ConveyorItemType conveyorItemType)
			=> conveyorItemType.ConstructedType != ConstructedType.NATURAL_RECOURSE;
	}
}