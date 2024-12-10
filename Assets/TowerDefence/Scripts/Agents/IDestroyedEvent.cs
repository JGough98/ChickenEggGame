namespace Assets.TowerDefense.Scripts.Agents
{
	public delegate void Destroyed<T>(T target);


	public interface IDestroyedEvent<T>
	{
		public event Destroyed<T> OnDestroyed;
	}
}