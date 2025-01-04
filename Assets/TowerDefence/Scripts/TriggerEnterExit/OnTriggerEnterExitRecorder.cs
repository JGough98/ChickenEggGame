using System.Collections.Generic;
using UnityEngine;


namespace Assets.TowerDefense.Scripts.TriggerEnterExit
{
	public class OnTriggerEnterExitRecorder<T> : OnTriggerEnterNotifier<T>
	{
		private List<T> targets = new List<T>();


		public IReadOnlyList<T> Targets => targets;


		protected override void NotifyFoundTarget(T target)
		{
			targets.Add(target);
			base.NotifyFoundTarget(target);
		}

		protected virtual void NotifyTargetLost(T target)
			=> targets.Remove(target);


		private void OnTriggerExit(Collider collision)
		{
			if (FoundTarget(collision, out var target))
				NotifyTargetLost(target);
		}
	}
}