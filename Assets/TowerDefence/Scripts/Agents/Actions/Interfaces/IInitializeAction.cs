namespace Assets.TowerDefence.Scripts.Agents.Actions.Interfaces
{
	/// <summary>
	/// Action used to peform a unit of AI work.
	/// </summary>
	/// <typeparam name="T">Starting Instructions.</typeparam>
	/// <typeparam name="U">Intialize Data</typeparam>
	public interface IInitializeAction<T, U> : IStartAction<T>
	{
		/// <summary>
		/// Passes the intialize data which will be used between each request.
		/// </summary>
		/// <param name="intializeData"></param>
		public void Intialize(U intializeData);
	}
}