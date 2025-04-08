using System.Collections.Generic;
using UnityEngine;


namespace Assets.TowerDefense.Scripts.BlackBoard
{
	using Agents;
	using Extensions;
	using Utility;


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


#if UNITY_EDITOR
		private void Awake()
		{
			recourses.GuardEnumrableAgainstNull();
			drones.GuardEnumrableAgainstNull();
			dropOffs.GuardEnumrableAgainstNull();
		}
#endif


		public void Reset()
		{
			this.RefreshBlackBoard();
		}
	}
}