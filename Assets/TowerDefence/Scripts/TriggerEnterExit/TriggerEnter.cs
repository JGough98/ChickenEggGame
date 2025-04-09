using UnityEngine;


namespace Assets.TowerDefense.Scripts.TriggerEnterExit
{
	public abstract class TriggerEnter<T> : MonoBehaviour
	{
		protected abstract void FoundTarget(T target);

		protected virtual bool IsTarget(
			Collider collision,
			out T target)
		{
			target = collision.gameObject.GetComponent<T>();
			return target != null;
		}


		private void OnTriggerEnter(Collider collision)
		{
			if (IsTarget(collision, out var target))
				FoundTarget(target);
		}
	}
}