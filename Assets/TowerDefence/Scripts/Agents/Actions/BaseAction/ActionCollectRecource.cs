using System;


namespace Assets.TowerDefence.Scripts.Agents.Actions.BaseAction
{
	using Interfaces;


	public class ActionCollectRecource : IStartAction<RecourseDeposit>
	{
		private RecourseDeposit recourse;

		private DateTime startCollectingTime;


		private bool FinishedGathering => (DateTime.Now - startCollectingTime).TotalSeconds >= recourse.TimeTakenToCollect;


		public void Cancle()
			=> recourse.CancleCollecting();

		public bool Perform()
		{
			if (!FinishedGathering)
				return true;

			recourse.RemoveRecourse();

			return TryGather();
		}

		public bool Start(
			RecourseDeposit recourse)
		{
			this.recourse = recourse;
			return TryGather();
		}

		private bool TryGather()
		{
			var canPerform = recourse.CanStartCollecting;

			if (recourse.CanStartCollecting)
			{
				recourse.StartCollecting();
				startCollectingTime = DateTime.Now;
			}

			return canPerform;
		}
	}
}