using UnityEngine;


namespace Assets.TowerDefense.Scripts.TriggerEnterExit
{
	public delegate void TargetFound<T>(T target);


	public class OnTriggerEnterNotifier<T> : MonoBehaviour
	{
		public event TargetFound<T> OnTargetFound;


		protected bool FoundTarget(
			Collider collision,
			out T target)
		{
			target = collision.gameObject.GetComponent<T>();
			return target != null;
		}

		protected virtual void NotifyFoundTarget(T target)
			=> OnTargetFound?.Invoke(target);


		private void OnTriggerEnter(Collider collision)
		{
			if (FoundTarget(collision, out var target))
				NotifyFoundTarget(target);
		}
	}
}