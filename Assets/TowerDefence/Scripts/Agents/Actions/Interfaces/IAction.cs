namespace Assets.TowerDefence.Scripts.Agents.Actions.Interfaces
{
	/// <summary>
	/// Action used to peform a unit of AI work.
	/// </summary>
	/// <typeparam name="T">Starting Instructions.</typeparam>
	public interface IAction
	{
		/// <summary>
		/// Used to peform the action and returns true once finished.
		/// </summary>
		/// <returns></returns>
		public bool IsFinished();

		/// <summary>
		/// Used to cancle the ongoing action.
		/// </summary>
		public void Cancle();
	}
}