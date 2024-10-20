using System.Collections.Generic;
using UnityEngine;


namespace Assets.TowerDefence.Scripts.BlackBoard
{
	using Assets.TowerDefence.Scripts.Agents;
	using Extensions;


	public class BlackBoardSceneData : MonoBehaviour
	{
		[SerializeField]
		private List<RecourseDeposit> recourses;

		[SerializeField]
		private List<Drone> drones;

		[SerializeField]
		private List<DepositDropOff> dropOffs;


		public IReadOnlyList<RecourseDeposit> Recourses => recourses;

		public IReadOnlyList<Drone> Drones => drones;

		public IReadOnlyList<DepositDropOff> DropOffs => dropOffs;


		public void Reset()
		{
			this.RefreshBlackBoard();
		}
	}
}