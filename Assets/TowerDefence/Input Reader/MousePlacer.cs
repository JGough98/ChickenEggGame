using UnityEngine;


namespace Assets.TowerDefense.Scripts.InputReader
{
	/// <summary>
	/// Used to place items in the scene displaying a icon of where its going to end up.
	/// </summary>
	public class MousePlacer : MonoBehaviour
	{
		/// <summary>
		/// The mouse input reader.
		/// </summary>
		[SerializeField]
		private MouseReader mouseReader;

		/// <summary>
		/// Converts world to grid positions.
		/// </summary>
		[SerializeField]
		private GridConvector gridConvector;

		/// <summary>
		/// What the object is placed under.
		/// </summary>
		[SerializeField]
		private Transform placedItemsParent;

		/// <summary>
		/// What layers the mouse position ray should account for.
		/// </summary>
		[SerializeField]
		private LayerMask placeMouseLayer;

		/// <summary>
		/// What item will be placed in the scene.
		/// </summary>
		private GameObject placedItem = null;
		/// <summary>
		/// What item is displayed when moving the mouse.
		/// </summary>
		private GameObject shownItem = null;


		private bool ShowingItem => placedItem != null || shownItem != null;

		private Vector3 MouseGridPosition => gridConvector.ConvertToWorldPosition(mouseReader.MouseWorldPosition);


		public void UpdateItem(GameObject shownItem)
			=> UpdateItem(shownItem, shownItem);

		public void UpdateItem(
			GameObject shownItem,
			GameObject placedItem)
		{
			this.shownItem = GameObject.Instantiate(shownItem);
			shownItem.SetActive(false);
			this.placedItem = placedItem;
		}

		public void HideItems()
		{
			placedItem = null;
			shownItem = null;
		}


		private void Awake()
		{
			SubscribeToOnMouseInWorldSpace();
		}

		private void Update()
		{
			if(!ShowingItem)
				return;

			if (mouseReader.MouseOneClicked)
			{
				PlaceItem(MouseGridPosition);
				return;
			}
			else
			{
				shownItem.transform.position = MouseGridPosition;
			}
		}

		private void HandleMouseInWorldSpace(
			bool inWorldSpace,
			Vector3 position)
		{
			if (!ShowingItem)
				return;

			shownItem.transform.position = position;
			shownItem.SetActive(inWorldSpace);
		}

		private void PlaceItem(Vector3 position)
		{
			var placed = GameObject.Instantiate(
				placedItem,
				position,
				placedItem.transform.rotation,
				placedItemsParent);

			placed.SetActive(true);
		}

		private void SubscribeToOnMouseInWorldSpace()
			=> mouseReader.OnMouseIsInWorldSpace += (inWorldSpace, position) => HandleMouseInWorldSpace(
				inWorldSpace,
				position);

		private void UnSubscribeToOnMouseInWorldSpace()
			=> mouseReader.OnMouseIsInWorldSpace -= (inWorldSpace, position) => HandleMouseInWorldSpace(
				inWorldSpace,
				position);

		private void Destroy()
			=> UnSubscribeToOnMouseInWorldSpace();
	}
}