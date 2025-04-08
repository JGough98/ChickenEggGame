using UnityEngine;


namespace Assets.TowerDefense.Scripts.Agents
{
	[CreateAssetMenu(fileName = "ConvayorItem-", menuName = "ScriptableObjects/ConvayorItem", order = 2)]
	public class ConveyorItemType : ScriptableObject
	{
		[SerializeField]
		private ElementType elementType;

		[SerializeField]
		private AmmunitionType ammunitionType;

		[SerializeField]
		private NaturalRecourseType naturalRecourseType;


		public ConstructedType ConstructedType => DetermineConstructionType();

		public ElementType? ElementType => elementType == Agents.ElementType.NULL ? null : elementType;

		public AmmunitionType? AmmunitionType => ammunitionType == Agents.AmmunitionType.NULL ? null : ammunitionType;

		public NaturalRecourseType? NaturalRecourseType => naturalRecourseType == Agents.NaturalRecourseType.NULL ? null : naturalRecourseType;



		private ConstructedType DetermineConstructionType()
		{
			var containsElement = ElementType != null;
			var containsAmmuntion = AmmunitionType != null;
			var containsNatualRecourse = NaturalRecourseType != null;

			if (containsElement && containsAmmuntion)
			{
				return ConstructedType.ELEMENT_AMUNINTION;
			}
			if (containsElement)
			{
				return ConstructedType.ELEMENT_RECOURSE;
			}
			if (containsAmmuntion)
			{
				return ConstructedType.AMMUNITION_RECOURSE;
			}
			if(containsNatualRecourse)
			{
				return ConstructedType.NATURAL_RECOURSE;
			}

			Debug.LogError($"{nameof(ConstructedType.NULL)} was created.");

			return ConstructedType.NULL;
		}
	}
}