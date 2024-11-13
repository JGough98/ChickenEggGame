using UnityEngine;


namespace Assets.TowerDefense.Scripts.Agents.Actions.Interfaces
{
	public interface IRotateFunction
	{
		public Quaternion GetRotation(
			Vector3 targetDirection,
			float rotationSpeed,
			Quaternion currentRotatation);
	}
}