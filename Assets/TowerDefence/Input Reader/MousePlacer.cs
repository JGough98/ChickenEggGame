using System.Collections.Generic;
using System.Linq;
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
		/// Where instantiated items are placed under.
		/// </summary>
		[SerializeField]
		private Transform placedItemsParent;
		/// <summary>
		/// Where shown items are placed under.
		/// </summary>
		[SerializeField]
		private Transform shownItemsParent;

		/// <summary>
		/// What layers the mouse position ray should account for.
		/// </summary>
		[SerializeField]
		private LayerMask placeMouseLayer;

		/// <summary>
		/// What item will be placed in the scene.
		/// </summary>
		private GameObject placedItem;
		/// <summary>
		/// What item is displayed when moving the mouse.
		/// </summary>
		private GameObject shownItem;

		/// <summary>
		/// The object pool of all currently shown items.
		/// </summary>
		private List<GameObject> shownItemsObjectPool = new List<GameObject>();

		/// <summary>
		/// Used to toggle if an item can be instantiated multiple times in a single drag.
		/// </summary>
		private bool itemPermitsDragMultiple;


		private bool ShowingItem => placedItem != null || shownItem != null;


		public void UpdateItem(
			GameObject shownItem,
			GameObject placedItem,
			bool canDragMultiple,
			bool canRotate)
		{
			this.placedItem = placedItem;
			this.shownItem = shownItem;
			this.itemPermitsDragMultiple = canDragMultiple;

			shownItem.SetActive(false);
			shownItemsObjectPool.Clear();
		}

		public void CancelShown()
		{
			placedItem = null;
			shownItem = null;

			HideShownItems();
		}


		private void Start()
		{
			Subscribe();
		}

		private void Update()
		{
			if(!ShowingItem)
				return;

			if (itemPermitsDragMultiple)
			{
				HandleDragInput();
				return;
			}

			HandleMouseInput();
		}

		private void HandleMouseInput()
		{
			if (mouseReader.MouseOneClicked)
			{
				AddPlacedItem(mouseReader.MouseGridPosition, Vector3.zero);
				return;
			}

			shownItem.transform.position = mouseReader.MouseGridPosition;
		}

		private void HandleDragInput()
		{
			if(!mouseReader.MouseDrag.MouseInDrag)
			{
				shownItem.transform.position = mouseReader.MouseGridPosition;
				return;
			}

			var mouseDragPositionToDirection = mouseReader.MouseDrag.PositionToDirection.ToList();

			UpdateShownObjectPool(mouseDragPositionToDirection);

			var index = 0;
			foreach ((var position, var direction) in mouseDragPositionToDirection)
			{
				var shownItem = shownItemsObjectPool[index];

				shownItem.transform.position = position;
				shownItem.transform.rotation = Quaternion.Euler(direction);
				shownItem.SetActive(true);

				index++;
			}
		}

		private void HandleMouseFinishedDragging()
		{
			if(!itemPermitsDragMultiple)
				return;

			var draggedPositions = mouseReader.MouseDrag.MouseGridDragPositions;
			var draggedDirections = mouseReader.MouseDrag.MouseGridDragDirections;

			if (draggedPositions.Count != draggedDirections.Count)
			{
				throw new System.Exception($"DraggedPositions and DridDirections do not align\n" +
					$"DraggedPositions : {draggedPositions.Count}\n" +
					$"GridDirections : {draggedDirections.Count}");
			}

			for(var i = 0; i < draggedPositions.Count; i++)
			{
				AddPlacedItem(draggedPositions[i], draggedDirections[i]);
			}

			HideShownItems();
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

		private void UpdateShownObjectPool(
			IEnumerable<(Vector3 position, Vector3 direction)> positionToDirection)
		{
			var diffInObjectPool = positionToDirection.Count() - shownItemsObjectPool.Count();

			if (diffInObjectPool <= 0)
				return;

			for (var i = 0; i < diffInObjectPool; i++)
			{
				shownItemsObjectPool.Add(AddHiddenShownItem());
			}
		}

		private GameObject AddPlacedItem(
			Vector3 position,
			Vector3 rotation)
			=> InstanciateItem(
				placedItem,
				placedItemsParent,
				position,
				rotation,
				shown : true);

		private GameObject AddHiddenShownItem()
			=> InstanciateItem(
				shownItem,
				shownItemsParent,
				position : Vector3.zero,
				rotation : Vector3.zero,
				shown : false);

		private GameObject InstanciateItem(
			GameObject item,
			Transform parent,
			Vector3 position,
			Vector3 rotation,
			bool shown)
		{
			var placed = GameObject.Instantiate(
				item,
				position,
				Quaternion.LookRotation(rotation),
				parent.transform);

			placed.SetActive(shown);

			return placed;
		}

		private void HideShownItems()
			=> HideShownItems(0);

		private void HideShownItems(int startingIndex)
		{
			for (var i = startingIndex; i < shownItemsObjectPool.Count(); i++)
			{
				shownItemsObjectPool[i].SetActive(false);
			}
		}

		private void Subscribe()
		{
			mouseReader.OnMouseInWorldSpace += (inWorldSpace, position) => HandleMouseInWorldSpace(
				inWorldSpace,
				position);

			//mouseReader.MouseDrag.OnMouseStartedDrag += () => HandleMouseFinishedDragging();
			mouseReader.MouseDrag.OnMouseFinishedDrag += () => HandleMouseFinishedDragging();
		}

		private void UnSubscribe()
		{
			mouseReader.OnMouseInWorldSpace -= (inWorldSpace, position) => HandleMouseInWorldSpace(
				inWorldSpace,
				position);

			//	mouseReader.MouseDrag.OnMouseStartedDrag += () => HandleMouseFinishedDragging();
			mouseReader.MouseDrag.OnMouseFinishedDrag += () => HandleMouseFinishedDragging();
		}

		private void Destroy()
			=> UnSubscribe();
	}
}