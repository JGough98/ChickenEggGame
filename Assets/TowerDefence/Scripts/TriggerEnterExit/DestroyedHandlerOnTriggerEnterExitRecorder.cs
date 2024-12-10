namespace Assets.TowerDefense.Scripts.TriggerEnterExit
{
	using Agents;


	public class DestroyedHandlerOnTriggerEnterExitRecorder<T> :
		OnTriggerEnterExitRecorder<T>
		where T : IDestroyedEvent<T>
	{
		protected override void Add(T target)
		{
			base.Add(target);
			target.OnDestroyed += (t) => Remove(t);
		}

		protected override void Remove(T target)
		{
			base.Remove(target);
			target.OnDestroyed -= (t) => Remove(t);
		}
	}
}