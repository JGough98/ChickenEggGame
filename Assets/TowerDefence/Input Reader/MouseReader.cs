using UnityEngine;
using UnityEngine.EventSystems;


namespace Assets.TowerDefense.Scripts.InputReader
{
	public delegate void MouseIsInWorldSpace(
		bool inWorldSpace,
		Vector3 position);


	public class MouseReader : MonoBehaviour
	{
		public event MouseIsInWorldSpace OnMouseIsInWorldSpace;


		[SerializeField]
		private Camera mainCamera;

		[SerializeField]
		private LayerMask layer;

		private bool mouseInWorldSpace = true;

		private Vector3 mouseWorldPosition;


		private bool MouseOverUI => EventSystem.current.IsPointerOverGameObject();

		private Ray MouseToCameraPosition => Camera.main.ScreenPointToRay(Input.mousePosition);


		public Vector3 MouseWorldPosition => mouseWorldPosition;

		public bool MouseOneClicked => Input.GetMouseButtonDown(0) && !MouseOverUI;


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

			mouseWorldPosition = hit.point;

			return hitSoemthingInWorldspace;
		}


		private void Update()
		{
			var currentlyInWorldSpace = MousePositionInWorldSpace(layer, out mouseWorldPosition)
				&& !MouseOverUI;

			if (currentlyInWorldSpace != mouseInWorldSpace)
			{
				mouseInWorldSpace = currentlyInWorldSpace;
				OnMouseIsInWorldSpace?.Invoke(mouseInWorldSpace, mouseWorldPosition);
			}
		}
	}
}