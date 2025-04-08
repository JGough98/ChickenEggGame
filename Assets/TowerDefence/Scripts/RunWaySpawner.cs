using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;


namespace Assets.TowerDefense.Scripts
{
	using Agents;
	using Agents.Actions.BaseAction;
	using Agents.Actions.Interfaces;
	using Utility;


	public class RunWaySpawner : MonoBehaviour
	{
		[SerializeField]
		private List<RunWayPoint> runWayPoints;


#if UNITY_EDITOR
		private void Awake()
		{
			runWayPoints.GuardEnumrableAgainstNull();
		}
#endif

		public IAction SpawnAtRunWay<T>(T enemy) where T : MonoBehaviour, IAgent
		{
			var newEnamy = GameObject.Instantiate<T>(enemy);

			return CreateMoveThroughRunWayAction(newEnamy.NavMeshAgent);
		}


		private IAction CreateMoveThroughRunWayAction(NavMeshAgent agent)
		{
			var moveToAction = new ActionMoveToPoint();

			moveToAction.Initialize(agent);

			return ActionCombinerUtility.CombinedAction(
				runWayPoints
					.Select(x => ((IAction)moveToAction, (Action)(() => moveToAction.Start(x.RandomWayPointPosition))))
					.ToArray());
		}
	}
}