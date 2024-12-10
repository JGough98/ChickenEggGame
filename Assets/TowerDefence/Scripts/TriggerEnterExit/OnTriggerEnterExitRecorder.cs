using System.Collections.Generic;
using UnityEngine;


namespace Assets.TowerDefense.Scripts.TriggerEnterExit
{
	public class OnTriggerEnterExitRecorder<T> : MonoBehaviour
	{
		private List<T> targets = new List<T>();


		public IReadOnlyList<T> Targets => targets;


		protected virtual void Add(T target)
			=> targets.Add(target);

		protected virtual void Remove(T target)
			=> targets.Remove(target);


		private void OnTriggerEnter(Collider collision)
		{
			if (Found(collision, out var target))
				Add(target);
		}

		private void OnTriggerExit(Collider collision)
		{
			if (Found(collision, out var target))
				Remove(target);
		}

		private bool Found(
			Collider collision,
			out T target)
		{
			target = collision.gameObject.GetComponent<T>();
			return target != null;
		}
	}
}