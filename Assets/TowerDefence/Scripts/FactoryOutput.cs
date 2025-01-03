using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	public class FactoryOutput : MonoBehaviour
	{
		public event AnimationFinished OnOutputProcessed;


		public void PerformOutputAnimation()
		{


			OnOutputProcessed?.Invoke();
		}
	}
}