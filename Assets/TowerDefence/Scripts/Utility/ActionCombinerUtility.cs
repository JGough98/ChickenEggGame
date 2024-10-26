using System;
using System.Collections.Generic;


namespace Assets.TowerDefence.Scripts.Utility
{
	using Agents.Actions.ComplexActions;
	using Agents.Actions.Interfaces;


	public static class ActionCombinerUtility
	{
		public static IAction CombinedAction(
			params (IAction performingAction, Action start) [] actions)
		{
			var actionsQueue = new Queue<(IAction performingAction, Action start)>();
			
			foreach (var action in actions)
			{
				actionsQueue.Enqueue(action);
			}

			return new ActionCombiner(actionsQueue);
		}
	}
}
