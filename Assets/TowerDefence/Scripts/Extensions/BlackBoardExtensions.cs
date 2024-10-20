using System.Reflection;


namespace Assets.TowerDefence.Scripts.Extensions
{
	using BlackBoard;
	using Utility;


	public static class BlackBoardExtensions
	{
		/// <summary>
		/// This uses reflection, do not use this at runtime!
		/// </summary>
		public static void RefreshBlackBoard(this BlackBoardSceneData blackBoardData)
			=> ReflectionUtility.SerializeAllListsWithValuesFromScene(
				blackBoardData,
				BindingFlags.Instance,
				BindingFlags.NonPublic);
	}
}