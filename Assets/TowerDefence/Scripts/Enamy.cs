using Assets.TowerDefence.Scripts.Agents;
using UnityEngine.AI;
using UnityEngine;

public class Enamy : MonoBehaviour, IAgent
{
	[SerializeField]
	private NavMeshAgent agent;


	public NavMeshAgent Agent => agent;
}