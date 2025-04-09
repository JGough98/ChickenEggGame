using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Assets.TowerDefense.Scripts
{
	using TowerDefense.ScriptableObjects;
	using InputReader;


	/// <summary>
	/// Used as the handler for manging the instantiation and state of factories.
	/// </summary>
	public class FactoryPlacerButtonHandler : MonoBehaviour
	{
		[SerializeField]
		private DeleteIcon deleteIcon;

		[SerializeField]
		private List<ObjectPlacerItem> placedObjects;

		[SerializeField]
		private GridLayoutGroup buttonLayoutParent;

		[SerializeField]
		private GameObject buttonPrefab;

		[SerializeField]
		private MousePlacer mousePlacer;

		private ObjectPlacerItem previouseObjectPlacerItem;


		private void Awake()
		{
			foreach (var placedObject in placedObjects)
			{
				var nextUI = Instantiate(buttonPrefab, buttonLayoutParent.transform);
				var button = nextUI.GetComponent<Button>();
				var textMeshPro = nextUI.GetComponentInChildren<TextMeshProUGUI>();

				button.onClick.AddListener(() => UpdateMousePlacer(placedObject));
				textMeshPro.SetText(placedObject.UIButtonName);
			}
		}

		private void UpdateMousePlacer(ObjectPlacerItem nextObjectPlacerItem)
		{
			var nextButtonState = nextObjectPlacerItem != previouseObjectPlacerItem;

			if (!nextButtonState)
			{
				previouseObjectPlacerItem = null;
				mousePlacer.CancelShown();
				return;
			}

			previouseObjectPlacerItem = nextObjectPlacerItem;
			mousePlacer.UpdateItem(
				nextObjectPlacerItem.Shown,
				nextObjectPlacerItem.Placed,
				nextObjectPlacerItem.CanDragMultiple,
				nextObjectPlacerItem.CanRotate);
		}
	}
}