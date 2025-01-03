using UnityEngine;


namespace Assets.TowerDefense.Scripts.Agents
{
	[RequireComponent(typeof(Rigidbody))]
	public class ConveyorItem : MonoBehaviour, IDestroyedEvent<ConveyorItem>
	{
		public event Destroyed<ConveyorItem> OnDestroyed;


		[SerializeField]
		private Rigidbody rigidBody;


		public Rigidbody RigidBody => rigidBody;


		/// <summary>
		/// Used as an event notifier to remove references to the object.
		/// </summary>
		public void CallDestroy()
		{
			OnDestroyed?.Invoke(this);
		}


		private void Reset()
		{
			rigidBody = gameObject.GetComponent<Rigidbody>();
		}

		private void OnDestroy()
			=> CallDestroy();
	}
}