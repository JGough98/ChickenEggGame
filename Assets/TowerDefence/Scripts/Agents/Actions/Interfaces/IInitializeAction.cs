namespace Assets.TowerDefense.Scripts.Agents.Actions.Interfaces
{
	/// <summary>
	/// Action used to perform a unit of AI work.
	/// </summary>
	/// <typeparam name="T">Starting Instructions.</typeparam>
	/// <typeparam name="U">Initialize Data</typeparam>
	public interface IInitializeAction<T, U> : IStartAction<T>
	{
		/// <summary>
		/// Passes the initialize data which will be used between each request.
		/// </summary>
		/// <param name="data"></param>
		public void Initialize(U data);
	}
}