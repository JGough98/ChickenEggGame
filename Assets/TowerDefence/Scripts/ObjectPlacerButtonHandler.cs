using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	using TowerDefense.ScriptableObjects;
	using InputReader;


	/// <summary>
	/// Used as the handler for all of the Unity Button actions.
	/// </summary>
	public class ObjectPlacerButtonHandler : MonoBehaviour
	{
		[SerializeField]
		private MousePlacer mousePlacer;

		[SerializeField]
		private ObjectPlacerItem convayorBelt;

		private bool convayorButtonState;


		public void TappedConveyorBelt()
			=> UpdateMousePlacer(
				convayorBelt,
				ref convayorButtonState);


		private void UpdateMousePlacer(
			ObjectPlacerItem objectPlacerItem,
			ref bool buttonState)
		{
			buttonState = !buttonState;
			
			if (!buttonState)
			{
				mousePlacer.HideItems();
				return;
			}

			mousePlacer.UpdateItem(
				objectPlacerItem.Shown,
				objectPlacerItem.Placed);
		}
	}
}