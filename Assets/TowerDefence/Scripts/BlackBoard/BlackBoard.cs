using UnityEngine;


[RequireComponent(typeof(BlackBoardData))]
public class BlackBoard : MonoBehaviour
{
	[SerializeField]
	public BlackBoardData Data;


	public void Reset()
	{
		Data = gameObject.GetComponent<BlackBoardData>();
	}
}