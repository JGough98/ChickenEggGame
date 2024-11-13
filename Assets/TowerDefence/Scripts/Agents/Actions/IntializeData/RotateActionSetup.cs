namespace Assets.TowerDefence.Scripts.Agents.Actions.IntializeData
{
	using Interfaces;


	public struct RotateActionSetup
	{
		public IRotationSetter Agent
		{
			get;
			private set;
		}

		public float RotationSpeed
		{
			get;
			private set;
		}


		public RotateActionSetup(IRotationSetter agent, float rotationSpeed)
		{
			Agent = agent;
			RotationSpeed = rotationSpeed;
		}
	}
}