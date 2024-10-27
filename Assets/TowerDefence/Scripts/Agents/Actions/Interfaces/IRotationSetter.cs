using UnityEngine;


namespace Assets.TowerDefence.Scripts.Agents.Actions.Interfaces
{
	public interface IRotationSetter : IRotation, IPosition
	{
		public bool SetRotation(
			Vector3 targetDirection,
			float rotationSpeed,
			IRotateFunction rotateFunction);
	}
}