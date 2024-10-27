using UnityEngine.AI;
using UnityEngine;


namespace Assets.TowerDefence.Scripts.Agents
{
	public class Enamy : MonoBehaviour, IAgent
	{
		[SerializeField]
		private NavMeshAgent agent;


		public NavMeshAgent Agent => agent;
	}
}