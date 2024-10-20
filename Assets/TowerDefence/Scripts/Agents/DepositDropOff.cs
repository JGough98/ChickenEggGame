using UnityEngine;


namespace Assets.TowerDefence.Scripts.Agents
{
	using ScriptableObjects;
	using Enums;


	public class DepositDropOff : MonoBehaviour
	{
		[SerializeField]
		private DepositDropOffData depositDropOffData;


		public bool AcceptsRecourse(ERecourseType recourseType)
			=> depositDropOffData.Accepted.HasFlag(recourseType);
	}
}