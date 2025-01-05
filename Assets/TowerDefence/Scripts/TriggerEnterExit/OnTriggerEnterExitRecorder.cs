using System.Collections.Generic;
using UnityEngine;


namespace Assets.TowerDefense.Scripts.TriggerEnterExit
{
	public class OnTriggerEnterExitRecorder<T> : OnTriggerEnterNotifier<T>
	{
		private List<T> targets = new List<T>();


		public IReadOnlyList<T> Targets => targets;


		protected override void FoundTarget(T target)
		{
			targets.Add(target);
			base.FoundTarget(target);
		}

		protected virtual void TargetLost(T target)
			=> targets.Remove(target);


		private void OnTriggerExit(Collider collision)
		{
			if (IsTarget(collision, out var target))
				TargetLost(target);
		}
	}
}