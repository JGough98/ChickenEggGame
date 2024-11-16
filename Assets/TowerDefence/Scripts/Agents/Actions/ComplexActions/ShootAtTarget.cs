namespace Assets.TowerDefense.Scripts.Agents.Actions.ComplexActions
{
	using Interfaces;
	using IntializeData;


	// So need to think how this class will work,
	// Not so sure that combining all actions into one is a good idea here.
	// Will definitely need a way to track if target has left sight.
	// And the two actions rely solely on one another...
	// Also this class will never be able to be canceled unless
	// And calling start here makes no sense
	public class ShootAtTarget : IStartAction<ShootAtTargetInitializeData>
	{
		private IInitializeAction<IPosition, RotateActionSetup> rotateTowardsAction;

		private IInitializeAction<ShootActionStart, IFacingDirection> shootAction;

		private ITargetSelector targetSelector;

		private ShootActionStart shootParams;


		public bool Start(ShootAtTargetInitializeData instructions)
		{
			this.shootAction = instructions.ShootAction;
			this.rotateTowardsAction = instructions.RotateTowardsAction;
			this.targetSelector = instructions.TargetSelector;

			shootParams = new ShootActionStart(
				instructions.RateOfFire,
				instructions.Bullet,
				instructions.Barrel);

			return true;
		}

		public bool Update()
		{
			SetNewActions();
			UpdateActions();
			return false;
		}

		public void Cancel() { }

		private void SetNewActions()
		{
			if (!targetSelector.TargetChanged())
				return;

			if (!targetSelector.TargetInSight)
			{
				rotateTowardsAction.Cancel();
				shootAction.Cancel();
			}
			else
			{
				rotateTowardsAction.Start(
					targetSelector.Target);
				shootAction.Start(
					shootParams);
			}
		}

		private void UpdateActions()
		{
			rotateTowardsAction.Update();

			if (targetSelector.TargetInSight)
			{
				shootAction.Update();
			}
		}
	}
}