using System;


namespace Assets.TowerDefence.Scripts.Agents.Actions.BaseAction
{
	using Agents;
	using Utility;
	using Interfaces;


	public class ActionCollectRecource : IStartAction<RecourseDeposit>
	{
		private RecourseDeposit recourse;

		private Guid recourseClameToken;

		private ITimer timer = new Timer();


		private bool FinishedGathering => timer.Finished;


		public void Cancle()
			=> recourse.CancleCollecting(recourseClameToken);

		public bool IsFinished()
		{
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
				timer.Start(recourse.TimeToTake(recourseClameToken));
			}

			return canPerform;
		}
	}
}