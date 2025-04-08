namespace Assets.TowerDefense.Scripts.Agents
{
	public struct RecourseClaim
	{
		public int AmountRemoved
		{
			get;
			private set;
		}

		public float TimeTaken
		{
			get;
			private set;
		}


		public RecourseClaim(
			int amountRemoved,
			float timeTaken)
		{
			AmountRemoved = amountRemoved;
			TimeTaken = timeTaken;
		}
	}
}