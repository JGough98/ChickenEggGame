using UnityEngine.AI;
using UnityEngine;


namespace Assets.TowerDefence.Scripts.Agents
{
	using Actions.Interfaces;


	public class Enamy : MonoBehaviour, IAgent, IPosition
	{
		[SerializeField]
		private NavMeshAgent agent;


		public NavMeshAgent NavMeshAgent => agent;

		public Vector3 Position => gameObject.transform.position;
	}
}