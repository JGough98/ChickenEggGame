using UnityEngine;


namespace Assets.TowerDefense.Scripts.Agents.Actions.BaseAction
{
	using IntializeData;
	using Interfaces;


	public class ActionRotate : IInitializeAction<IPosition, RotateActionSetup>
	{
		private readonly IRotateFunction rotateFunction = new SlerpRotate();

		private float rotationSpeed;

		private IRotationSetter agent;

		private IPosition target;


		private Vector3 NormalizedDirectionToTarget => (target.Position - agent.Position).normalized;


		public void Initialize(RotateActionSetup rotationSetup)
		{
			this.agent = rotationSetup.Agent;
			this.rotationSpeed = rotationSetup.RotationSpeed;
		}

		public bool Start(IPosition target)
		{
			this.target = target;
			return true;
		}

		public bool IsFinished()
			=> agent.SetRotation(
				NormalizedDirectionToTarget,
				rotationSpeed,
				rotateFunction);

		public void Cancel() { }
	}
}