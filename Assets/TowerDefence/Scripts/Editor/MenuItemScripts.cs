using UnityEditor;
using UnityEngine;


public static class MenuItemScripts
{
	[MenuItem("EditorTools/Refresh/BlackBoard")]
	public static void MenuitemRefreshBlackBoard()
	{
		Object.FindObjectOfType<BlackBoardData>().RefreshBlackBoard();
		Debug.Log($"Refreshed {typeof(BlackBoardData).Name}");
	}
}