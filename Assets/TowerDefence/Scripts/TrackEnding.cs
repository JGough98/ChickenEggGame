using System.Collections.Generic;
using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	using Agents;
	using TriggerEnterExit;


	[RequireComponent(typeof(EnemyTriggerNotifier))]
	public class TrackEnding : MonoBehaviour
	{
		[SerializeField]
		private HealthBar healthBar;

		[SerializeField]
		private EnemyTriggerNotifier enamyNotifier;

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

			enamiesPassedFinishLine.Add(nextEnemy);
			healthBar.DecrementHealth(nextEnemy.DamageDealt);
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

		private void Reset()
		{
			enamyNotifier = gameObject.GetComponent<EnemyTriggerNotifier>();
		}
	}
}