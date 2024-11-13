namespace Assets.TowerDefense.Scripts.Agents.Actions.InstructionData
{
	public struct ShootAtTargetInstructions
	{
		public Turret Turret
		{
			get;
			private set;
		}


		public ShootAtTargetInstructions(Turret turret)
		{
			this.Turret = turret;
		}
	}
}
