using UnityEngine;


namespace Assets.TowerDefense.Scripts.Agents
{
	using ScriptableObjects;
	using Enums;
	using System.Collections.Generic;
	using System;
	using System.Diagnostics.CodeAnalysis;

	public struct RecourseClaim
	{
		public int AmountRemoved
		{
			get;
			private set;
		}

		public float TimeTaken
		{
			get;
			private set;
		}


		public RecourseClaim(
			int amountRemoved,
			float timeTaken)
		{
			AmountRemoved = amountRemoved;
			TimeTaken = timeTaken;
		}
	}


	public class RecourseDeposit : MonoBehaviour
	{
		[SerializeField]
		private RecourseDepositData recourseDeposit;

		private int recoursesTaken;

		private int reacoursesClaimed;

		private float timeTakenToCollectOneUnit;

		private Dictionary<Guid, RecourseClaim> recourseClaims = new Dictionary<Guid, RecourseClaim>();


		private int RecoursesRemaning => recourseDeposit.StackCount - (recoursesTaken + reacoursesClaimed);


		public bool HasRecourses => RecoursesRemaning > 0;

		public ERecourseType Type => recourseDeposit.Type;


		private void Awake()
		{
			timeTakenToCollectOneUnit = recourseDeposit.TimeTakenToCollectOneUnit;
		}


		public float TimeToTake(Guid claimToken)
			=> recourseClaims[claimToken].TimeTaken;

		public bool ClaimRecourse(
			int claimAmount,
			[NotNullWhen(true)] out Guid? claimToken)
		{
			claimToken = null;

			var canClaim = CanClaim(
				claimAmount,
				out var recourseClaim);

			if (canClaim)
			{
				claimToken = Guid.NewGuid();
				recourseClaims.Add(
					claimToken!.Value,
					recourseClaim!.Value);

				reacoursesClaimed += claimAmount;
			}

			return canClaim;
		}

		public int CancleCollecting(
			Guid claimToken)
		{
			var freedClaim = recourseClaims[claimToken].AmountRemoved;
			reacoursesClaimed -= freedClaim;
			recourseClaims.Remove(claimToken);
			return freedClaim;
		}

		public void CompleteRemoval(
			Guid claimToken)
			=> recoursesTaken += CancleCollecting(claimToken);


		private bool CanClaim(
			int claimAmount,
			out RecourseClaim? recourseClaim)
		{
			recourseClaim = null;
			var canClaim = RecoursesRemaning - claimAmount >= 0;

			if (canClaim)
			{
				recourseClaim = new RecourseClaim(
					claimAmount,
					timeTakenToCollectOneUnit * claimAmount);
			}

			return canClaim;
		}
	}
}