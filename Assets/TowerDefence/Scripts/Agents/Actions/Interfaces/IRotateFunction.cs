using UnityEngine;


namespace Assets.TowerDefence.Scripts.Agents.Actions.Interfaces
{
	public interface IRotateFunction
	{
		public Quaternion GetRotation(
			Vector3 targetDirection,
			float rotationSpeed,
			Quaternion currentRotatation);
	}
}