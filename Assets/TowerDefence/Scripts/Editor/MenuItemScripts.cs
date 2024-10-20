using UnityEditor;
using UnityEngine;


namespace Assets.TowerDefence.Scripts.Editor
{
	using Assets.TowerDefence.Scripts.Extensions;
	using BlackBoard;


	public static class MenuItemScripts
	{
		[MenuItem("EditorTools/Refresh/BlackBoard")]
		public static void MenuitemRefreshBlackBoard()
		{
			Object.FindObjectOfType<BlackBoardSceneData>().RefreshBlackBoard();
			Debug.Log($"Refreshed {typeof(BlackBoardSceneData).Name}");
		}
	}
}