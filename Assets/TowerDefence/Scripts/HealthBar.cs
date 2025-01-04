using UnityEngine;
using UnityEngine.UI;


namespace Assets.TowerDefense.Scripts
{
	public delegate void GameOver();


	public class HealthBar : MonoBehaviour
	{
		public event GameOver OnGameOver;


		[SerializeField]
		private int Total;

		[SerializeField]
		private Image healthImage;

		private int currentHealth;


		public void DecrementHealth(int damageTaken)
		{
			currentHealth -= damageTaken;

			if(currentHealth <= 0)
			{
				currentHealth = 0;
				OnGameOver?.Invoke();
			}

			UpdateUI();
		}


		private void Awake()
		{
			currentHealth = Total;
		}

		private void UpdateUI()
			=> healthImage.fillAmount = (float)currentHealth / Total;
	}
}