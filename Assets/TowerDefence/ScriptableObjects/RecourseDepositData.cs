using UnityEngine;


namespace Assets.TowerDefence.Scripts.ScriptableObjects
{
	using Enums;


	[CreateAssetMenu(fileName = "RecourseDepositData", menuName = "ScriptableObjects/RecourseDepositData", order = 1)]
	public class RecourseDepositData : ScriptableObject
	{
		[SerializeField]
		private ERecourseType type;

		[SerializeField]
		private float timeTakenToCollect;

		[SerializeField]
		private float quantityGathered;

		[SerializeField]
		private int stackCount;


		public ERecourseType Type => type;

		public float TimeTakenToCollect => timeTakenToCollect;

		public float QuantityGathered => quantityGathered;

		public int StackCount => stackCount;
	}
}