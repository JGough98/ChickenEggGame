using UnityEngine;


namespace Assets.TowerDefense.Scripts.Agents
{
	public enum ConveyorItemRecourseType
	{
		IRON,
		FIRE
	}

	[RequireComponent(typeof(Rigidbody))]
	public class ConveyorItem : MonoBehaviour, IDestroyedEvent<ConveyorItem>
	{
		public event Destroyed<ConveyorItem> OnDestroyed;


		[SerializeField]
		private Rigidbody rigidBody;

		[SerializeField]
		private ConveyorItemRecourseType conveyorItemRecourseType;


		public Rigidbody RigidBody => rigidBody;

		public ConveyorItemRecourseType ConveyorItemRecourseType => conveyorItemRecourseType;


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