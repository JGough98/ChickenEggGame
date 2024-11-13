using UnityEngine.AI;
using UnityEngine;


namespace Assets.TowerDefence.Scripts.Agents
{
	public interface IAgent
	{
		public NavMeshAgent NavMeshAgent
		{
			get;
		}
	}

	[RequireComponent(typeof(NavMeshAgent))]
	public class Drone : MonoBehaviour, IAgent
	{
		public NavMeshAgent NavMeshAgent => gameObject.GetComponent<NavMeshAgent>();
	}
}