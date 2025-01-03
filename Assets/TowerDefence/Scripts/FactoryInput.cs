using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	public class FactoryInput : MonoBehaviour
	{
		public event AnimationFinished OnInputProcessed;


		private bool recieved;

		public bool Received => recieved;


		public void PerformInputAnimation()
		{
			OnInputProcessed?.Invoke();
		}
	}
}