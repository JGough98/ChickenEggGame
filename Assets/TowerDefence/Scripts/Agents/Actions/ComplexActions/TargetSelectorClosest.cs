namespace Assets.TowerDefense.Scripts.Agents.Actions.ComplexActions
{
	using TriggerEnterExit;
	using Utility;


	public class TargetSelectorClosest : ITargetSelector
	{
		private FieldOfView fieldOfView;

		private Enamy currentTarget;


		public Enamy Target => currentTarget;


		public TargetSelectorClosest(FieldOfView fieldOfView)
		{
			this.fieldOfView = fieldOfView;
		}


		public bool TargetChanged()
		{
			fieldOfView.Targets.FindNearest(
				fieldOfView.transform.position,
				out var nextTarget);

			var targetChanged = nextTarget != currentTarget;

			currentTarget = nextTarget;

			return targetChanged;
		}
	}
}