using UnityEngine;


namespace Assets.TowerDefense.Scripts.Agents
{
	public delegate void Destroyed<T>(T target);

	public interface IDestroyedEvent
	{
		/// <summary>
		/// Used as an event caller to remove references to the object.
		/// </summary>
		void InvokeDestroyedEvent();
	}

	/// <summary>
	/// Contract used to remove references to a 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IDestroyedEvent<T> : IDestroyedEvent
	{
		/// <summary>
		/// Used as an event notifier to remove references to the object.
		/// </summary>
		event Destroyed<T> OnDestroyed;
	}


	public static class DestroyedEventUtility
	{
		// Need to send cache event
		public static void SafeDestroy<T>(
			this T gameObject)
				where T : MonoBehaviour, IDestroyedEvent
		{
			gameObject.gameObject.SetActive(false);
			gameObject.InvokeDestroyedEvent();
		}

		// Need to send cache event
		public static void SafeDestroy(
			this IDestroyedEvent destroyedEvent,
			GameObject gameObject)
		{
			gameObject.gameObject.SetActive(false);
			destroyedEvent.InvokeDestroyedEvent();
		}
	}
}