using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;


namespace Assets.TowerDefence.Scripts
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
			runWayPoints.GuardAgainstNull();
		}
#endif

		public IAction SpwanAtRunWay<T>(T enamy) where T : MonoBehaviour, IAgent
		{
			var newEnamy = GameObject.Instantiate<T>(enamy);

			return CreateMoveThroughRunWayAction(newEnamy.NavMeshAgent);
		}


		private IAction CreateMoveThroughRunWayAction(NavMeshAgent agent)
		{
			var moveToAction = new ActionMoveToPoint();

			moveToAction.Intialize(agent);

			return ActionCombinerUtility.CombinedAction(
				runWayPoints
					.Select(x => ((IAction)moveToAction, (Action)(() => moveToAction.Start(x.RandomWayPointPostion))))
					.ToArray());
		}
	}
}