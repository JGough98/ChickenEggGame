using UnityEngine;


namespace Assets.TowerDefense.Scripts.Agents
{
	public class AmmunitionFeed : MonoBehaviour
	{
		private int ammunitionCount = 0;


		public bool HasAmmunition => ammunitionCount > 0;


		public void RemoveRound()
			=> ammunitionCount--;


		private void OnTriggerEnter(Collider collision)
		{
			var amunition = collision.gameObject.GetComponent<ConveyorItem>();

			if (amunition != null)
			{
				ammunitionCount++;
				Destroy(amunition.gameObject);
			}
		}
	}
}