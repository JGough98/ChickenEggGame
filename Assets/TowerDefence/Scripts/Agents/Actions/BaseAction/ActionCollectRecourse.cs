using System;


namespace Assets.TowerDefense.Scripts.Agents.Actions.BaseAction
{
	using Agents;
	using Utility;
	using Interfaces;


	public class ActionCollectRecourse : IStartAction<RecourseDeposit>
	{
		private RecourseDeposit recourseDeposit;

		private Guid recourseClameToken;

		private ITimer timer = new Timer();


		private bool FinishedGathering => timer.Finished;


		public void Cancel()
			=> recourseDeposit.CancleCollecting(recourseClameToken);

		public bool Update()
		{
			if (!FinishedGathering)
				return false;

			recourseDeposit.CompleteRemoval(recourseClameToken);

			return true; // TryGather();
		}

		public bool Start(
			RecourseDeposit recourse)
		{
			this.recourseDeposit = recourse;
			return TryGather();
		}


		private bool TryGather()
		{
			var canPerform = recourseDeposit.ClaimRecourse(
				20,
				out var claim);

			if (canPerform)
			{
				recourseClameToken = claim!.Value;
				timer.Start(recourseDeposit.TimeToTake(recourseClameToken));
			}

			return canPerform;
		}
	}
}