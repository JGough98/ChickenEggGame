using Assets.TowerDefense.Scripts.Agents;
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
			if(other.gameObject.GetComponent<Enamy>() != null)
			{
				Destroy(gameObject);
			}
		}

		public void Reset()
		{
			this.rigidBody = gameObject.GetComponent<Rigidbody>();
		}
	}
}