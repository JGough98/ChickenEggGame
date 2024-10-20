using UnityEngine;


namespace Assets.TowerDefence.Scripts.BlackBoard
{
	[RequireComponent(typeof(BlackBoardSceneData))]
	public class BlackBoard : MonoBehaviour
	{
		[SerializeField]
		public BlackBoardSceneData Data;


		public void Reset()
		{
			Data = gameObject.GetComponent<BlackBoardSceneData>();
		}
	}
}