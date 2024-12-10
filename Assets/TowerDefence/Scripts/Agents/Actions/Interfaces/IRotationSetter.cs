using UnityEngine;


namespace Assets.TowerDefense.Scripts.Agents.Actions.Interfaces
{
	public interface IRotationSetter
	{
		public Transform Target { get; }

		public bool SetRotation(
			Vector3 targetDirection,
			float rotationSpeed,
			IRotateFunction rotateFunction);
	}
}