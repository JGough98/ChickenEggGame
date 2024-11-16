namespace Assets.TowerDefense.Scripts.Agents.Actions.Interfaces
{
	public interface IFacingDirection : IRotation
	{
		public bool IsFacing
		{
			get;
		}
	}
}