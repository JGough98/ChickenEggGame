using UnityEngine;


namespace Assets.TowerDefense.Scripts.Agents
{
	using Actions.Interfaces;
	using TowerDefense.ScriptableObjects;


	public class Turret : MonoBehaviour, IRotationSetter
	{
		[SerializeField]
		private FieldOfView fieldOfView;

		[SerializeField]
		private AmunitionTypeData amunitionType;

		[SerializeField]
		private Transform barrelRoundStart;


		private Vector3 CurrentDirection => Rotation.eulerAngles.normalized;


		public Quaternion Rotation => transform.rotation;

		public Vector3 Position => transform.position;

		public FieldOfView FieldOfView => fieldOfView;

		public AmunitionTypeData AmunitionType => amunitionType;

		public Transform BarrelRoundStart => barrelRoundStart;



		// Will need to account for how we rotate both the barrel and the turret.
		public bool SetRotation(
			Vector3 targetDirection,
			float rotationSpeed,
			IRotateFunction rotateFunction)
		{
			var directionChanged = (transform.rotation.eulerAngles - targetDirection).sqrMagnitude > 1f;

			if (!directionChanged)
				return false;

			var nextRotation = rotateFunction.GetRotation(
				targetDirection,
				rotationSpeed,
				Rotation);

			transform.rotation = nextRotation;

			return true;
		}


		// Need to look into Vector dot products and figure out not only if a bullet will intercect but at what rotation this should occur.
		private bool LineLineIntersection(
			out Vector3 intersection,
			Vector3 agentPosition,
			Vector3 agentDirection,
			Vector3 targetPosition,
			Vector3 targetDirection)
		{

			var lineVec3 = targetPosition - agentPosition;
			var crossVec1and2 = Vector3.Cross(agentDirection, targetDirection);
			var crossVec3and2 = Vector3.Cross(lineVec3, targetDirection);
			var planarFactor = Vector3.Dot(lineVec3, crossVec1and2);

			//is coplanar, and not parallel
			if (Mathf.Abs(planarFactor) < 0.0001f && crossVec1and2.sqrMagnitude > 0.0001f)
			{
				float s = Vector3.Dot(crossVec3and2, crossVec1and2) / crossVec1and2.sqrMagnitude;
				intersection = agentPosition + (agentDirection * s);
				return true;
			}
			else
			{
				intersection = Vector3.zero;
				return false;
			}
		}
	}
}