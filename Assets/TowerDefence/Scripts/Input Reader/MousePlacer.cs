using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using GameObjectPools = Assets.TowerDefense.Scripts.Utility.DataTypes.ObjectPools<UnityEngine.GameObject, Assets.TowerDefense.Scripts.Utility.DataTypes.GameObjectPoolInitializeData, Assets.TowerDefense.Scripts.Utility.DataTypes.GameObjectInitializeData>;


namespace Assets.TowerDefense.Scripts.InputReader
{
	using Utility.DataTypes;
	using Utility.GO;


	/// <summary>
	/// Used to place items in the scene displaying a icon of where its going to end up.
	/// </summary>
	public class MousePlacer : MonoBehaviour
	{
		private readonly GameObjectInitializeData DEFAULT_GAME_OBJECT_INTIALIZE = new GameObjectInitializeData(
			isActive: false,
			position: Vector3.zero,
			rotation: Vector3.zero);


		/// <summary>
		/// The keyboard input reader.
		/// </summary>
		[SerializeField]
		private KeyBoardReader keyBoardReader;

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
		private Transform aboutToBePlacedParent;

		/// <summary>
		/// What layers the mouse position ray should account for.
		/// </summary>
		[SerializeField]
		private LayerMask placeMouseLayer;

		/// <summary>
		/// Used to toggle if an item can be instantiated multiple times in a single drag.
		/// </summary>
		private bool itemPermitsDragMultiple;

		/// <summary>
		/// What item will be placed in the scene.
		/// </summary>
		private GameObject placedItem;
		/// <summary>
		/// What item is displayed when moving the mouse.
		/// </summary>
		private GameObject shownItem;

		/// <summary>
		/// The object pools of about to be placed items.
		/// </summary>
		private GameObjectPools aboutToBePlaceditems;


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

			aboutToBePlaceditems.TryAddNewPool(
				new GameObjectPoolInitializeData(
					aboutToBePlacedParent,
					shownItem));
		}

		public void CancelShown()
		{
			placedItem = null;
			shownItem = null;

			aboutToBePlaceditems.Pool.RemoveAll();
		}


		private void Awake()
		{
			aboutToBePlaceditems = new GameObjectPools(new GameObjectPoolQueries());
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

		private void HandleRoatateItem(Vector3 rotateDirection)
		{
			var t1 = shownItem.transform.rotation.eulerAngles;
			var t2 = placedItem.transform.rotation.eulerAngles;
			shownItem.transform.rotation *= Quaternion.Euler(rotateDirection);
			placedItem.transform.rotation *= Quaternion.Euler(rotateDirection);
			var t3 = shownItem.transform.rotation.eulerAngles;
			var t4 = placedItem.transform.rotation.eulerAngles;
		}

		private void HandleMouseInput()
		{
			if (mouseReader.MouseOneClicked)
			{
				AddPlacedItem(mouseReader.MouseGridPosition);
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
			
			// Should output the index to start updating rather than updating all.
			if (UpdateShownObjectPool(mouseDragPositionToDirection))
			{
				var index = 0;
				foreach ((var position, var direction) in mouseDragPositionToDirection)
				{
					var shownItem = aboutToBePlaceditems.Pool[index];

					shownItem.transform.position = position;
					shownItem.transform.rotation = Quaternion.Euler(direction);
					shownItem.SetActive(true);

					index++;
				}
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
				throw new System.Exception(
					$"DraggedPositions and DridDirections do not align\n" +
					$"DraggedPositions : {draggedPositions.Count}\n" +
					$"GridDirections : {draggedDirections.Count}");
			}

			for(var i = 0; i < draggedPositions.Count; i++)
			{
				AddPlacedItem(draggedPositions[i], draggedDirections[i]);
			}

			aboutToBePlaceditems.Pool.RemoveAll();
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

		private bool UpdateShownObjectPool(
			IEnumerable<(Vector3 position, Vector3 direction)> positionToDirection)
		{
			var diffInObjectPool = positionToDirection.Count() - aboutToBePlaceditems.Pool.Count;

			if (diffInObjectPool < 0)
			{
				aboutToBePlaceditems.Pool.RemoveItems(aboutToBePlaceditems.Pool.Count + diffInObjectPool);
				return false;
			}

			for (var i = 0; i < diffInObjectPool; i++)
			{
				aboutToBePlaceditems.Pool.AddItem(DEFAULT_GAME_OBJECT_INTIALIZE);
			}

			return true;
		}

		private GameObject AddPlacedItem(
			Vector3 position)
			=> GameObjectUtility.Instantiate(
				placedItem,
				placedItemsParent,
				position,
				shown: true);

		private GameObject AddPlacedItem(
			Vector3 position,
			Vector3 rotation)
			=> GameObjectUtility.Instantiate(
				placedItem,
				placedItemsParent,
				position,
				rotation,
				shown : true);

		private void Subscribe()
		{
			mouseReader.OnMouseInWorldSpace += (inWorldSpace, position) => HandleMouseInWorldSpace(
				inWorldSpace,
				position);

			mouseReader.MouseDrag.OnMouseFinishedDrag += () => HandleMouseFinishedDragging();
			keyBoardReader.OnRotateTapped += HandleRoatateItem;
		}

		private void UnSubscribe()
		{
			mouseReader.OnMouseInWorldSpace -= (inWorldSpace, position) => HandleMouseInWorldSpace(
				inWorldSpace,
				position);

			mouseReader.MouseDrag.OnMouseFinishedDrag += () => HandleMouseFinishedDragging();
			keyBoardReader.OnRotateTapped -= HandleRoatateItem;
		}

		private void Destroy()
			=> UnSubscribe();
	}
}