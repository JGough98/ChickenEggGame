using UnityEngine;


namespace Assets.TowerDefense.Scripts.Utility
{
	public class Timer : ITimer
	{
		private float startingTime;
		private float waitTime;

		private bool isPaused = true;


		private float TimeRemaning => Time.unscaledTime - startingTime;


		public bool Finished => !isPaused && TimeRemaning >= waitTime;


		public void Pause()
		{
			waitTime -= TimeRemaning;
			isPaused = true;
		}

		public void Resume()
		{
			startingTime = Time.unscaledTime;
			isPaused = false;
		}

		public void Start(float waitTime)
		{
			this.waitTime = waitTime;
			Resume();
		}
	}
}