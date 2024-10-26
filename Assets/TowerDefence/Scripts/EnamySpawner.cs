using Assets.TowerDefence.Scripts.Agents;
using Assets.TowerDefence.Scripts.Agents.Actions.BaseAction;
using Assets.TowerDefence.Scripts.Agents.Actions.Interfaces;
using Assets.TowerDefence.Scripts.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;


public class EnamySpawner : MonoBehaviour
{
	[SerializeField]
	private List<EnamyWayPoint> enamyWayPoints;


	public IAction SpwanEnamy<T>(T enamy) where T : MonoBehaviour, IAgent
	{
		var newEnamy = GameObject.Instantiate<T>(enamy);

		return CreateMoveThroughLevelAction(newEnamy.Agent);
	}


	private IAction CreateMoveThroughLevelAction(NavMeshAgent agent)
	{
		var moveToAction = new ActionMoveToPoint();

		moveToAction.Intialize(agent);

		return ActionCombinerUtility.CombinedAction(
			enamyWayPoints
				.Select(x => ((IAction) moveToAction, (Action)(() => moveToAction.Start(x.RandomWayPointPostion))))
				.ToArray());
	}
}