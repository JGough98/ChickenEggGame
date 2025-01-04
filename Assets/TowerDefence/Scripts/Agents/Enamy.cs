using UnityEngine.AI;
using UnityEngine;


namespace Assets.TowerDefense.Scripts.Agents
{
	using Actions.Interfaces;


	public class Enamy : MonoBehaviour,
		IAgent,
		IPosition,
		IDestroyedEvent<Enamy>
	{
		public event Destroyed<Enamy> OnDestroyed;


		[SerializeField]
		private NavMeshAgent agent;

		[SerializeField]
		private int damageDealt;


		public NavMeshAgent NavMeshAgent => agent;

		public Vector3 Position => gameObject.transform.position;

		public int DamageDealt => damageDealt;


		public void OnDestroy()
		{
			OnDestroyed?.Invoke(this);
		}
	}
}