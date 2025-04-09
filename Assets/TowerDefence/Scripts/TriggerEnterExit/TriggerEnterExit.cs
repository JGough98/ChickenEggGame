using UnityEngine;


namespace Assets.TowerDefense.Scripts.TriggerEnterExit
{
	public abstract class TriggerEnterExit<T> : TriggerEnter<T>
	{
		protected abstract void LostTarget(T target);


		private void OnTriggerExit(Collider collision)
		{
			if (IsTarget(collision, out var target))
				LostTarget(target);
		}
	}
}