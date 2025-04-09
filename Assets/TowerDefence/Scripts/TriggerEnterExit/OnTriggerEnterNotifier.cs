namespace Assets.TowerDefense.Scripts.TriggerEnterExit
{
	public delegate void TargetFound<T>(T target);


	public class OnTriggerEnterNotifier<T> : TriggerEnter<T>
	{
		public event TargetFound<T> OnTargetFound;


		protected override void FoundTarget(T target)
			=> OnTargetFound?.Invoke(target);
	}
}