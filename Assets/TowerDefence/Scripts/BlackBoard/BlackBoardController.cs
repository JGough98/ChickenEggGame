using UnityEngine;


namespace Assets.TowerDefence.Scripts.BlackBoard
{
	/// <summary>
	/// Represents all data agents will need to request for.
	/// </summary>
	[RequireComponent(typeof(BlackBoardSceneData))]
	public class BlackBoardController : MonoBehaviour
	{
		[SerializeField]
		private BlackBoardSceneData sceneData;


		public BlackBoardSceneData Data => sceneData;


		public void Reset()
		{
			sceneData = gameObject.GetComponent<BlackBoardSceneData>();
			sceneData.Reset();
		}
	}
}