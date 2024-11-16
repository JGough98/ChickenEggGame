namespace Assets.TowerDefense.Scripts.Agents.Actions.ComplexActions
{
	public interface ITargetSelector
	{
		public bool TargetInSight => Target != null;

		public Enamy Target
		{
			get;
		}


		public bool TargetChanged();
	}
}