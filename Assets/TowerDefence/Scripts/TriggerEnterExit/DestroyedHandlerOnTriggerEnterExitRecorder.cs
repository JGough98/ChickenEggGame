namespace Assets.TowerDefense.Scripts.TriggerEnterExit
{
	using Agents;


	public class DestroyedHandlerOnTriggerEnterExitRecorder<T> :
		OnTriggerEnterExitRecorder<T>
		where T : IDestroyedEvent<T>
	{
		protected override void NotifyFoundTarget(T target)
		{
			base.NotifyFoundTarget(target);
			target.OnDestroyed += (t) => NotifyTargetLost(t);
		}

		protected override void NotifyTargetLost(T target)
		{
			base.NotifyTargetLost(target);
			target.OnDestroyed -= (t) => NotifyTargetLost(t);
		}
	}
}