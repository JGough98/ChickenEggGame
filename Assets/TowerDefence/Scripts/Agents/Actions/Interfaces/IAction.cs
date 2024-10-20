namespace Assets.TowerDefence.Scripts.Agents.Actions.Interfaces
{
	/// <summary>
	/// Action used to peform a unit of AI work.
	/// </summary>
	/// <typeparam name="T">Starting Instructions.</typeparam>
	public interface IAction
	{
		/// <summary>
		/// Used to peform an action and state whether its finished.
		/// </summary>
		/// <returns></returns>
		public bool Perform();

		/// <summary>
		/// Used to cancle the ongoing action.
		/// </summary>
		public void Cancle();
	}
}