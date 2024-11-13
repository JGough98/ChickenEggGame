using UnityEditor;
using UnityEngine;


namespace Assets.TowerDefense.Scripts.Editor
{
	using Assets.TowerDefense.Scripts.Extensions;
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