using UnityEngine;


namespace Assets.TowerDefense.Scripts.ScriptableObjects
{
	using Enums;


	[CreateAssetMenu(fileName = "DepositDropOffData-", menuName = "ScriptableObjects/DepositDropOff", order = 2)]
	public class DepositDropOffData : ScriptableObject
	{
		// Make this a flag of allowed recourses
		[SerializeField]
		private ERecourseType accepted;


		public ERecourseType Accepted => accepted;
	}
}