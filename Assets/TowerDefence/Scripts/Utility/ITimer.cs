namespace Assets.TowerDefense.Scripts.Utility
{
	public interface ITimer
	{
		public bool Finished
		{
			get;
		}

		public void Start(float waitTime);

		public void Pause();

		public void Resume();
	}
}