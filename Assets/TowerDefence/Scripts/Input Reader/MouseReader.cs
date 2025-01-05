using UnityEngine;
using UnityEngine.EventSystems;


namespace Assets.TowerDefense.Scripts.InputReader
{
	public delegate void MouseSwitchedWorldSpace(
		bool inWorldSpace,
		Vector3 position);


	public class MouseReader : MonoBehaviour
	{
		public event MouseSwitchedWorldSpace OnMouseInWorldSpace;

		[SerializeField]
		private GridConvector gridConvector;

		[SerializeField]
		private Camera mainCamera;

		[SerializeField]
		private LayerMask layer;


		private MouseDrag mouseDrag;

		private bool mouseInWorldSpace;

		private bool mouseClicked;

		private Vector3 mouseWorldPosition;

		private Vector3 mouseGridPosition;


		private Ray MouseToCameraPosition => Camera.main.ScreenPointToRay(Input.mousePosition);


		public Vector3 MouseGridPosition => mouseGridPosition;

		public Vector3 MouseWorldPosition => mouseWorldPosition;

		public bool MouseOneClicked => mouseClicked;

		public MouseDrag MouseDrag => mouseDrag;


		/// <summary>
		/// Gets the position of the first GameObject in which the ray intersects with.
		/// </summary>
		/// <param name="layerMask">The layer masks the ray can collide with.</param>
		/// <param name="mouseWorldPosition">The found colliding world position.</param>
		/// <returns></returns>
		public bool MousePositionInWorldSpace(
			LayerMask layerMask,
			out Vector3 mouseWorldPosition)
		{
			var hitSoemthingInWorldspace = Physics.Raycast(
				MouseToCameraPosition,
				out var hit,
				Mathf.Infinity,
				layerMask);

			mouseWorldPosition = hit.point.Round();

			return hitSoemthingInWorldspace;
		}


		private void Awake()
		{
			mouseDrag = new MouseDrag();
		}

		private void Update()
		{
			var mouseHoveringOverUI = EventSystem.current.IsPointerOverGameObject();
			var mouseHoveringOverWorldObject = MousePositionInWorldSpace(
				layer,
				out mouseWorldPosition);

			mouseGridPosition = gridConvector.ConvertToWorldPosition(mouseWorldPosition);

			HandleMouseSwitchedBetweenWorldAndUI(
				mouseHoveringOverWorldObject,
				mouseHoveringOverUI);

			mouseClicked = Input.GetMouseButtonDown(0) && !mouseHoveringOverUI;

			mouseDrag.UpdateDrag(
				mouseGridPosition,
				(mouseClicked || mouseDrag.MouseInDrag) && !Input.GetMouseButtonUp(0));
		}

		private void HandleMouseSwitchedBetweenWorldAndUI(
			bool mouseHoveringOverWorldObject,
			bool mouseHoveringOverUI)
		{
			var nextMouseInWorldSpace = mouseHoveringOverWorldObject && !mouseHoveringOverUI;

			if (nextMouseInWorldSpace != mouseInWorldSpace)
			{
				mouseInWorldSpace = nextMouseInWorldSpace;

				OnMouseInWorldSpace?.Invoke(
					mouseInWorldSpace,
					mouseWorldPosition);
			}
		}
	}
}