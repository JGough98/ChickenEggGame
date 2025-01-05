using System;
using System.Linq;
using UnityEngine;


namespace Assets.TowerDefense.Scripts.Agents
{
	using TriggerEnterExit;
	using Utility.Physics;


	public class ConveyorBelt : MonoBehaviour
	{
		[SerializeField]
		private ConveyorItemFieldOfView conveyorItemFieldOfView;

		[SerializeField]
		private float speed;

		[SerializeField]
		[Range(0, 360)]
		private float angleDirectionThreshold;

		[SerializeField]
		[Range(0, 1)]
		private float decelrationRate;


		private Vector3? directionOfMovement;


		private Vector3 DirectionOfMovement
		{
			get
			{
				if (directionOfMovement == null)
					directionOfMovement = transform.TransformDirection(Vector3.forward);

				return directionOfMovement!.Value;
			}
		}


		public void Update()
		{
			if (!conveyorItemFieldOfView.Targets.Any())
			{
				return;
			}

			foreach (var conavayorItem in conveyorItemFieldOfView.Targets)
			{
				TryApplyForce(conavayorItem);
			}
		}


		private void TryApplyForce(ConveyorItem convayorItem)
		{
			var rb = convayorItem.RigidBody;

			if (GetConvayorForce(rb, out var nexxtForceApplied))
				rb.AddForce(nexxtForceApplied);
		}

		private bool GetConvayorForce(Rigidbody convayorItem, out Vector3 conavyorItemForce)
		{
			var convayorItemDirection = convayorItem.velocity.normalized;
			var convayorItemMagnitued = convayorItem.velocity.magnitude;
			
			var isTooFast = convayorItemMagnitued >= speed;
			var directionDelta = MathF.Abs(Vector2.Angle(convayorItemDirection, DirectionOfMovement));
			var isWrongDirection = MathF.Abs(Vector2.Angle(convayorItemDirection, DirectionOfMovement)) > angleDirectionThreshold;
			
			conavyorItemForce = isTooFast
				? Vector3.zero
				: speed * DirectionOfMovement;

			if (isWrongDirection)
			{
				var inverseForce = convayorItemMagnitued * decelrationRate;
				var inverseDirection = convayorItemDirection.Inverse();
				conavyorItemForce += inverseDirection * inverseForce;
			}

			return !isTooFast || isWrongDirection;
		}
	}
}