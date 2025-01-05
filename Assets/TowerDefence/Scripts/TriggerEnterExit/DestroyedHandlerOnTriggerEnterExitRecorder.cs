namespace Assets.TowerDefense.Scripts.TriggerEnterExit
{
	using Agents;


	public class DestroyedHandlerOnTriggerEnterExitRecorder<T> :
		OnTriggerEnterExitRecorder<T>
		where T : IDestroyedEvent<T>
	{
		protected override void FoundTarget(T target)
		{
			base.FoundTarget(target);
			target.OnDestroyed += (t) => TargetLost(t);
		}

		protected override void TargetLost(T target)
		{
			base.TargetLost(target);
			target.OnDestroyed -= (t) => TargetLost(t);
		}
	}
}