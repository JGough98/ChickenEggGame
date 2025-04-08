using UnityEngine;


namespace Assets.TowerDefense.Scripts.Agents
{
	/*
	public enum EventType
	{
		CONAVYOR_FOUND_TARGET,
	}

	public delegate void GenericEventNotifier<T>(T target, EventType eventType);

	public interface IEventNotifier<T>
	{
		/// <summary>
		/// Used as a generic event notifier.
		/// </summary>
		event GenericEventNotifier<T> OnNotifed;
	}*/


	public delegate void Destroyed<T>(T target);

	/// <summary>
	/// Contract used to remove references to a 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IDestroyedEvent<T>
	{
		/// <summary>
		/// Used as an event notifier to remove references to the object.
		/// </summary>
		event Destroyed<T> OnDestroyed;

		/// <summary>
		/// Used as an event caller to remove references to the object.
		/// </summary>
		void InvokeDestroyedEvent();
	}


	public static class DestroyedEventUtility
	{
		// Need to send cache event
		public static void SafeDestroy<T>(this T gameObject)
			where T : MonoBehaviour,
			IDestroyedEvent<T>
		{
			gameObject.gameObject.SetActive(false);
			gameObject.InvokeDestroyedEvent();
		}
	}
}