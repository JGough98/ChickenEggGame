using UnityEngine;


namespace Assets.TowerDefense.Scripts.Agents.Actions.BaseAction
{
	using IntializeData;
	using Interfaces;


	public class ActionRotate : IInitializeAction<IPosition, RotateActionSetup>, IFacingDirection
	{
		private bool followingTarget;

		private bool ignoreRotationChange;

		private float rotationSpeed;

		private readonly IRotateFunction rotateFunction = new SlerpRotate();

		private IRotationSetter agent;

		private IPosition target;

		private Vector3 startingDirection;


		private Vector3 NormalizedDirectionToTarget => (target.Position - agent.Target.position).normalized;

		private Vector3 LookingDirection
			=> followingTarget
				? NormalizedDirectionToTarget
				: startingDirection;

		// TODO - Need to check were in sight of target.
		public bool IsFacing => followingTarget;

		public Vector3 Rotation => agent.Target.forward;


		public void Initialize(RotateActionSetup rotationSetup)
		{
			this.agent = rotationSetup.Agent;
			this.rotationSpeed = rotationSetup.RotationSpeed;
			this.startingDirection = rotationSetup.Agent.Target.rotation.eulerAngles;
		}

		public bool Start(IPosition target)
		{
			this.target = target;
			ignoreRotationChange = false;
			return followingTarget = true;
		}

		public bool Update()
		{
			if(ignoreRotationChange)
				return false;
			
			// Look into this issue in the future...
			var rotationChanged = agent.SetRotation(
				LookingDirection,
				rotationSpeed,
				rotateFunction);

			ignoreRotationChange = !followingTarget && !rotationChanged;

			return rotationChanged;
		}

		public void Cancel()
			=> followingTarget = false;
	}
}