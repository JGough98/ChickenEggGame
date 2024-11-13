using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	[RequireComponent(typeof(Rigidbody))]
	public class Bullet : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody rigidBody;


		public void SetVelocity(Vector3 velocity)
		{
			rigidBody.velocity = velocity;
		}


		public void OnTriggerEnter(Collider other)
		{
			if (other != null && other.tag == "Player")
			{
				Destroy(this);
			}
		}

		public void Reset()
		{
			this.rigidBody = gameObject.GetComponent<Rigidbody>();
		}
	}
}