using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public static class BlackBoardExtensions
{
	/// <summary>
	/// This uses reflection, do not use this at runtime!
	/// </summary>
	public static void RefreshBlackBoard(this BlackBoardData blackBoardData)
		=> ReflectionUtility.SerializeAllListsWithValuesFromScene(blackBoardData);
}
