namespace Assets.TowerDefence.Scripts.Agents.Actions.Interfaces
{
	/// <summary>
	/// Action used to peform a unit of AI work.
	/// </summary>
	/// <typeparam name="T">Starting Instructions.</typeparam>
	public interface IStartAction<T> : IAction
	{
		/// <summary>
		/// Passes the instruction paramiters and starts the action.
		/// </summary>
		/// <param name="instructions"></param>
		/// <returns></returns>
		public bool Start(T instructions);
	}
}