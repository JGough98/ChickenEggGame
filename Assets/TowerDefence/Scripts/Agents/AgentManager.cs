using System.Collections.Generic;


namespace Assets.TowerDefense.Scripts
{
	using Agents.Actions.Interfaces;


	public class AgentManager
	{
		private List<IAction> agentActions = new List<IAction>();


		public void AddAgents(
			params IAction [] agents)
			=> agentActions.AddRange(agents);

		public void AddAgent(
			IAction agent)
			=> agentActions.Add(agent);

		public void PeformAgentActions()
		{
			foreach (var agentAction in agentActions)
			{
				agentAction.IsFinished();
			}
		}
	}
}