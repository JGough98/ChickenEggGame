using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Assets.TowerDefense.Scripts.Agents.Actions.ComplexActions
{
	using Interfaces;


	public class ActionCombiner : IAction
	{
		private Queue<(IAction performingAction, Action start)> combinedActions;

		private IAction currentAction;

		private bool started = false;


		public ActionCombiner(Queue<(IAction performingAction, Action start)> actions)
		{
			combinedActions = actions;
		}


		public bool IsFinished()
		{
			// Not sure this is quite right, have a feeling the navmesh agent needs a frame to update before confirming?
			if(!started)
			{
				StartNextAction();
				started = true;
				return false;
			}
			else if (!currentAction.IsFinished())
			{
				Debug.Log($"Doing action ({combinedActions.Count()+1})");
				return false;
			}
			else if (combinedActions.Count() > 0)
			{
				Debug.Log($"Finished action ({combinedActions.Count()+1})");
				StartNextAction();
				return false;
			}

			return true;
		}

		public void Cancel()
			=> currentAction.Cancel();


		private void StartNextAction()
		{
			var actionNum = combinedActions.Count();
			var nextAction = combinedActions.Dequeue();
			currentAction = nextAction.performingAction;
			Debug.Log($"Starting action ({actionNum})");
			nextAction.start();
		}
	}
}