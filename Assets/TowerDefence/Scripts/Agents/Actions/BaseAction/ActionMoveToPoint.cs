using UnityEngine;
using UnityEngine.AI;


namespace Assets.TowerDefense.Scripts.Agents.Actions.BaseAction
{
	using Interfaces;


	public class ActionMoveToPoint : IInitializeAction<Vector3, NavMeshAgent>
	{
		private NavMeshAgent agent;

		private Vector3 travelPosition;


		private bool ReachedDestination => agent.remainingDistance <= agent.stoppingDistance;


		public void Initialize(NavMeshAgent agent)
		{
			this.agent = agent;
		}

		public bool Start(Vector3 travelPosition)
		{
			this.travelPosition = travelPosition;
			var e = agent.SetDestination(travelPosition);
			return e;
		}

		public bool IsFinished()
		{
			Debug.DrawRay(travelPosition, Vector3.up, Color.blue, 1.0f);
			return ReachedDestination;
		}

		public void Cancel()
			=> agent.isStopped = true;
	}
}