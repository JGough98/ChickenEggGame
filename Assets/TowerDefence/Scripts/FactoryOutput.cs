using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	public class FactoryOutput : MonoBehaviour
	{
		[SerializeField]
		private GameObject outputPosition;


		public event AnimationFinished OnOutputProcessed;


		public GameObject OutputPosition => outputPosition;


		public void PerformOutputAnimation(GameObject createdObject)
		{
			OnOutputProcessed?.Invoke();
		}
	}
}