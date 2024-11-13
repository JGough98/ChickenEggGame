
using UnityEngine;


namespace Assets.TowerDefense.Scripts.ScriptableObjects
{
	using Enums;


	[CreateAssetMenu(fileName = "RecourseDepositData-", menuName = "ScriptableObjects/RecourseDeposit", order = 1)]
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

		public float TimeTakenToCollectOneUnit => timeTakenToCollect / quantityGathered;

		public int StackCount => stackCount;
	}
}