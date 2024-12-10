using UnityEngine;


namespace Assets.TowerDefense.Scripts.InputReader
{
	/// <summary>
	/// Used to place items in the scene displaying a icon of where its going to end up.
	/// </summary>
	public class MousePlacer : MonoBehaviour
	{
		/// <summary>
		/// What the object is placed under.
		/// </summary>
		[SerializeField]
		private Transform placedItemsParent;

		/// <summary>
		/// The mouse input reader.
		/// </summary>
		[SerializeField]
		private MouseReader mouseReader;

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


		private bool ShouldShow => placedItem != null || shownItem != null;


		public void UpdateItem(GameObject shownItem)
			=> UpdateItem(shownItem, shownItem);

		public void UpdateItem(
			GameObject shownItem,
			GameObject placedItem)
		{
			this.shownItem = GameObject.Instantiate(shownItem);
			this.placedItem = placedItem;
		}

		public void StopShowing()
		{
			placedItem = null;
			shownItem = null;
		}


		private void Awake()
		{
			SubscribeToOnMouseInWorldSpace(true);
		}

		private void Update()
		{
			if(!ShouldShow)
				return;

			if (mouseReader.MouseOneClicked)
			{
				PlaceItem(mouseReader.MouseWorldPosition);
			}
			else
			{
				shownItem.transform.position = mouseReader.MouseWorldPosition;
			}
		}

		private void HandleMouseInWorldSpace(
			bool inWorldSpace,
			Vector3 worldPosition)
		{
			shownItem.transform.position = worldPosition;
			shownItem.SetActive(inWorldSpace);
		}

		// TODO - This should account for placing things in a grid like structure.
		private void PlaceItem(Vector3 position)
			=> GameObject.Instantiate(
				placedItem,
				position,
				placedItem.transform.rotation,
				placedItemsParent);

		private void SubscribeToOnMouseInWorldSpace(bool subscribe)
		{
			if (subscribe)
			{
				mouseReader.OnMouseIsInWorldSpace += (inWorldSpace, worldPosition) => HandleMouseInWorldSpace(
					inWorldSpace,
					worldPosition);
			}
			else
			{
				mouseReader.OnMouseIsInWorldSpace -= (inWorldSpace, worldPosition) => HandleMouseInWorldSpace(
					inWorldSpace,
					worldPosition);
			}
		}

		private void Destroy()
			=> SubscribeToOnMouseInWorldSpace(false);
	}
}