namespace Assets.TowerDefence.Scripts.Agents.Actions.IntializeData
{
	using Interfaces;


	public struct RotateActionSetup
	{
		public IRotationSetter Agent
		{
			get;
		}

		public float RotationSpeed
		{
			get;
		}
	}
}