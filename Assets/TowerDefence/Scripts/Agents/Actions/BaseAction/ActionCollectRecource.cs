using System;


using UnityEngine;


namespace Assets.TowerDefence.Scripts.Agents.Actions.BaseAction
{
	using Assets.TowerDefence.Scripts.Agents;
	using Interfaces;


	public class ActionCollectRecource : IStartAction<RecourseDeposit>
	{
		private RecourseDeposit recourse;

		private float startCollectingTime;

		private Guid recourseClameToken;


		private bool FinishedGathering => (Time.unscaledTime - startCollectingTime) >= recourse.TimeToTake(recourseClameToken);


		public void Cancle()
			=> recourse.CancleCollecting(recourseClameToken);

		public bool IsFinished()
		{
			var e = Time.unscaledTime - startCollectingTime;
			var d = recourse.TimeToTake(recourseClameToken);

			if (!FinishedGathering)
				return false;

			recourse.CompleteRemoval(recourseClameToken);

			return true; // TryGather();
		}

		public bool Start(
			RecourseDeposit recourse)
		{
			this.recourse = recourse;
			return TryGather();
		}


		private bool TryGather()
		{
			var canPerform = recourse.ClaimRecourse(
				20,
				out var claim);

			if (canPerform)
			{
				recourseClameToken = claim!.Value;
				startCollectingTime = Time.unscaledTime;
			}

			return canPerform;
		}
	}
}