using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Assets.TowerDefence.Scripts.ScriptableObjects
{
	using Enums;


	[CreateAssetMenu(fileName = "DDOD", menuName = "ScriptableObjects/DepositDropOffData", order = 2)]
	public class DepositDropOffData : ScriptableObject
	{
		// Make this a flag of allowed recourses
		[SerializeField]
		private ERecourseType accepted;


		public ERecourseType Accepted => accepted;
	}
}