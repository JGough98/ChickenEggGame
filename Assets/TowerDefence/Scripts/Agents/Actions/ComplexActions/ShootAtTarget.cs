using System;
using System.Linq;
using UnityEngine.AI;


namespace Assets.TowerDefence.Scripts.Agents.Actions.ComplexActions
{
	using BlackBoard;
	using InstructionData;
	using Interfaces;
	using IntializeData;
	using System.Diagnostics;
	using Utility;


	// So need to think how this class will work,
	// Not so sure that combining all actions into one is a good idea here.
	// Will defintley need a way to track if taget has left sight.
	// And the two actions rely soley on one another...
	// Also this class will never be able to be cancalled unless
	// And calling start here makes no sense
	public class ShootAtTarget : IInitializeAction<ShootAtTargetInstructions, ShootAtTargeIntializeData>
	{
		private BlackBoardSceneData blackBoardSceneData;

		private Turret turret;

		private IInitializeAction<IPosition, RotateActionSetup> rotateTowardsAction;

		private IStartAction<ShootActionSetup> shootAction;

		private IAction shootRotate;


		public void Intialize(ShootAtTargeIntializeData intializeData)
		{
			UnityEngine.Debug.Log("Look here!!");

			this.blackBoardSceneData = intializeData.BlackBoardSceneData;
			this.rotateTowardsAction = intializeData.RotateTowardsAction;
			this.shootAction = intializeData.ShootAction;
			this.turret = intializeData.Turret;

			rotateTowardsAction.Intialize(new RotateActionSetup(turret, 50));
		}

		public bool Start(
			ShootAtTargetInstructions instructions)
		{
			this.turret = instructions.Turret;

			rotateTowardsAction.Intialize(new RotateActionSetup(turret, 50));

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

		public void Cancle()
			=> shootRotate.Cancle();


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