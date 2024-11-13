namespace Assets.TowerDefense.Scripts.Agents.Actions.Interfaces
{
	/// <summary>
	/// Action used to perform a unit of AI work.
	/// </summary>
	/// <typeparam name="T">Starting Instructions.</typeparam>
	public interface IAction
	{
		/// <summary>
		/// Used to perform the action and returns true once finished.
		/// </summary>
		/// <returns></returns>
		public bool IsFinished();

		/// <summary>
		/// Used to cancel the ongoing action.
		/// </summary>
		public void Cancel();
	}
}