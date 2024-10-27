using UnityEngine;


namespace Assets.TowerDefence.Scripts.Agents.Actions.BaseAction
{
	using Interfaces;


	public class SlerpRotate : IRotateFunction
	{
		public Quaternion GetRotation(
			Vector3 direction,
			float rotationSpeed,
			Quaternion currentRotatation)
			=> Quaternion.Slerp(
				currentRotatation,
				Quaternion.LookRotation(direction),
				Time.deltaTime * rotationSpeed);
	}
}