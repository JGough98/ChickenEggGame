using System.Collections.Generic;
using UnityEngine;


namespace Assets.TowerDefence.Scripts.Agents
{
	public class FieldOfView : MonoBehaviour
	{
		private List<Enamy> targets = new List<Enamy>();


		public IReadOnlyList<Enamy> Targets => targets;


		private void OnTriggerEnter(Collider collision)
		{
			var newEnamy = collision.gameObject.GetComponent<Enamy>();

			if (newEnamy != null)
			{
				targets.Add(newEnamy);
			}
		}

		private void OnTriggerExit(Collider collision)
		{
			var newEnamy = collision.gameObject.GetComponent<Enamy>();

			if (newEnamy != null)
			{
				targets.Remove(newEnamy);
			}
		}
	}
}