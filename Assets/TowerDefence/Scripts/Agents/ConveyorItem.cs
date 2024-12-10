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


		private void Reset()
		{
			rigidBody = gameObject.GetComponent<Rigidbody>();
		}

		private void OnDestroy()
		{
			OnDestroyed?.Invoke(this);
		}
	}
}