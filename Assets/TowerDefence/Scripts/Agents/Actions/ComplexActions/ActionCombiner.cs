using System;
using System.Collections.Generic;
using System.Linq;


namespace Assets.TowerDefence.Scripts.Agents.Actions.ComplexActions
{
	using Interfaces;


	public class ActionCombiner : IAction
	{
		private Queue<(IAction performingAction, Action start)> combinedActions;

		private IAction currentAction;


		private bool ActionFinished => currentAction.Perform();

		private bool ActionsRemain => combinedActions.Count() > 0;


		public ActionCombiner(Queue<(IAction performingAction, Action start)> actions)
		{
			combinedActions = actions;
		}


		public bool Perform()
		{
			if (!ActionFinished)
				return true;

			if (ActionsRemain)
			{
				StartNextAction();
				return true;
			}

			return false;
		}

		public void Cancle()
			=> currentAction.Cancle();


		private void StartNextAction()
		{
			var nextAction = combinedActions.Dequeue();
			currentAction = nextAction.performingAction;
			nextAction.start();
		}
	}
}