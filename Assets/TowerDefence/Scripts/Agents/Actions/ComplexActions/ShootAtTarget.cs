using System;
using System.Linq;
using UnityEngine.AI;


namespace Assets.TowerDefense.Scripts.Agents.Actions.ComplexActions
{
	using BlackBoard;
	using InstructionData;
	using Interfaces;
	using IntializeData;
	using Utility;


	// So need to think how this class will work,
	// Not so sure that combining all actions into one is a good idea here.
	// Will definitely need a way to track if target has left sight.
	// And the two actions rely solely on one another...
	// Also this class will never be able to be canceled unless
	// And calling start here makes no sense
	public class ShootAtTarget : IInitializeAction<ShootAtTargetInstructions, ShootAtTargeIntializeData>
	{
		private BlackBoardSceneData blackBoardSceneData;

		private Turret turret;

		private IInitializeAction<IPosition, RotateActionSetup> rotateTowardsAction;

		private IStartAction<ShootActionSetup> shootAction;

		private IAction shootRotate;


		public void Initialize(ShootAtTargeIntializeData initializeData)
		{
			UnityEngine.Debug.Log("Look here!!");

			this.blackBoardSceneData = initializeData.BlackBoardSceneData;
			this.rotateTowardsAction = initializeData.RotateTowardsAction;
			this.shootAction = initializeData.ShootAction;
			this.turret = initializeData.Turret;

			rotateTowardsAction.Initialize(new RotateActionSetup(turret, 50));
		}

		public bool Start(
			ShootAtTargetInstructions instructions)
		{
			this.turret = instructions.Turret;

			rotateTowardsAction.Initialize(new RotateActionSetup(turret, 50));

			return false;
		}

		public bool IsFinished()
		{
			if(shootRotate == null)
			{
				return TryAssignNewTarget();
			}
			if (!shootRotate.IsFinished())
			{
				return false;
			}

			return false;
		}

		public void Cancel()
			=> shootRotate.Cancel();


		private bool TryAssignNewTarget()
		{
			if(turret.FieldOfView.Targets.Any())
			{
				UnityEngine.Debug.Log("Lets go!!");
				shootRotate = ActionCombinerUtility.CombinedAction(
					(rotateTowardsAction, () => rotateTowardsAction.Start(turret.FieldOfView.Targets.First())));
			}

			return false;
		}
	}
}