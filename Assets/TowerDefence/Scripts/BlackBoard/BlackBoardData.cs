using System.Collections.Generic;
using UnityEngine;


public class BlackBoardData : MonoBehaviour
{
	[SerializeField]
	public List<Recourse> Recourses;

	[SerializeField]
	public List<Drone> Drones;


	public void Reset()
	{
		this.RefreshBlackBoard();
	}
}