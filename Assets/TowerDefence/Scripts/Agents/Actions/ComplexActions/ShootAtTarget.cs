using System;
using UnityEngine.AI;


namespace Assets.TowerDefence.Scripts.Agents.Actions.ComplexActions
{
	using Assets.TowerDefence.Scripts.Utility;
	using BlackBoard;
	using InstructionData;
	using Interfaces;
	using IntializeData;
	using Mono.Reflection;
	using System.Diagnostics;
	using System.Linq;

	public class ShootAtTarget : IInitializeAction<ShootAtTargetInstructions, ShootAtTargeIntializeData>
	{
		private BlackBoardSceneData blackBoardSceneData;

		private Turret turret;

		private IInitializeAction<IPosition, RotateActionSetup> rotateTowardsAction;

		private IStartAction<ShootActionSetup> shootAction;

		private IAction shootRotate;


		public void Intialize(ShootAtTargeIntializeData intializeData)
		{
			this.blackBoardSceneData = intializeData.BlackBoardSceneData;
			this.rotateTowardsAction = intializeData.RotateTowardsAction;
			this.shootAction = intializeData.ShootAction;
			this.turret = intializeData.Turret;
		}

		public bool Start(
			ShootAtTargetInstructions instructions)
		{
			this.turret = instructions.Turret;

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
				rotateTowardsAction.Intialize(new RotateActionSetup(turret, 50));
				UnityEngine.Debug.Log("Lets go!!");
				shootRotate = ActionCombinerUtility.CombinedAction(
					(rotateTowardsAction, () => rotateTowardsAction.Start(turret.FieldOfView.Targets.First())));
			}

			return false;
		}
	}
}