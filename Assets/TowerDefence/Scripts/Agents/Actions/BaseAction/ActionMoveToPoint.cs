using UnityEngine;
using UnityEngine.AI;


namespace Assets.TowerDefence.Scripts.Agents.Actions.BaseAction
{
	using Interfaces;


	public class ActionMoveToPoint : IInitializeAction<Vector3, NavMeshAgent>
	{
		private NavMeshAgent agent;

		private Vector3 travelPosition;


		private bool ReachedDestination => agent.remainingDistance <= agent.stoppingDistance;


		public void Intialize(NavMeshAgent agent)
		{
			this.agent = agent;
		}

		public bool Start(Vector3 travelPosition)
		{
			this.travelPosition = travelPosition;
			return agent.SetDestination(travelPosition);
		}

		public bool Perform()
		{
			Debug.DrawRay(travelPosition, Vector3.up, Color.blue, 1.0f);
			return ReachedDestination;
		}

		public void Cancle()
			=> agent.isStopped = true;
	}
}