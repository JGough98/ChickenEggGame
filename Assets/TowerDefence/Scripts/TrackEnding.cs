using System.Collections.Generic;
using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	using Agents;
	using TriggerEnterExit;


	public class TrackEnding : MonoBehaviour
	{
		[SerializeField]
		private OnTriggerEnterNotifier<Enamy> enamyNotifier;

		private HashSet<Enamy> enamiesPassedFinishLine = new HashSet<Enamy>();


		private void Awake()
		{
			Subscribe();
		}

		private void TryDealDamage(Enamy nextEnemy)
		{
			// If an enemy happens to go through twice ignore.
			if (enamiesPassedFinishLine.Contains(nextEnemy))
				return;

			DecrementHealth(nextEnemy.DamageDealt);
		}

		private void DecrementHealth(int damageDealt)
		{

		}

		private void Subscribe()
		{
			enamyNotifier.OnTargetFound += (e) => TryDealDamage(e);
		}

		private void UnSubscribe()
		{
			enamyNotifier.OnTargetFound -= (e) => TryDealDamage(e);
		}

		private void OnDestroy()
		{
			UnSubscribe();
		}
	}
}