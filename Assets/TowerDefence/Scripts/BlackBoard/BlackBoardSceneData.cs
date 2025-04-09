using System.Collections.Generic;
using UnityEngine;


namespace Assets.TowerDefense.Scripts.BlackBoard
{
	using Agents;
	using Extensions;
	using System.Linq;
	using Utility;


	public class BlackBoardSceneData : MonoBehaviour
	{
		[SerializeField]
		private List<RecourseDeposit> recourses;

		[SerializeField]
		private List<Drone> drones;

		[SerializeField]
		private List<DepositDropOff> dropOffs;

		[SerializeField]
		private List<ParentSpawner> parentSpawns;


		public IReadOnlyList<RecourseDeposit> Recourses => recourses;

		public IReadOnlyList<Drone> Drones => drones;

		public IReadOnlyList<DepositDropOff> DropOffs => dropOffs;

		public IReadOnlyList<ParentSpawner> ParentSpawns => parentSpawns;


#if UNITY_EDITOR
		private void Awake()
		{
			parentSpawns.GuardEnumrableAgainstNull();
			if(parentSpawns.Select(x => x.SpawnType).GroupBy(x => x).Where(x => x.Count() > 1).Any())
			{
				throw new System.Exception("Multiple spawn types added.");
			}
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