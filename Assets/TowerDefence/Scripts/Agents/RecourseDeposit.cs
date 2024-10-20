using UnityEngine;


namespace Assets.TowerDefence.Scripts.Agents
{
	using ScriptableObjects;
	using Enums;


	public class RecourseDeposit : MonoBehaviour
	{
		[SerializeField]
		private RecourseDepositData recourseDeposit;

		private int recoursesTaken;
		private int claimOnRecourse;


		private int RecoursesRemaning => recourseDeposit.StackCount - recoursesTaken;


		public bool CanStartCollecting => RecoursesRemaning - claimOnRecourse > 0;

		public float TimeTakenToCollect => recourseDeposit.TimeTakenToCollect;
		public float QuantityGathered => recourseDeposit.QuantityGathered;

		public ERecourseType Type => recourseDeposit.Type;


		public void StartCollecting()
		{
			claimOnRecourse++;
		}

		public void CancleCollecting()
		{
			claimOnRecourse++;
		}

		public void RemoveRecourse()
		{
			recoursesTaken++;
		}
	}
}