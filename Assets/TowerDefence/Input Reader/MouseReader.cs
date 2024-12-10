using UnityEngine;


namespace Assets.TowerDefense.Scripts.InputReader
{
	public class MouseReader : MonoBehaviour
	{
		[SerializeField]
		private GameObject SpawnThing;


		/// <summary>
		/// Return the position of the Mouse in Pixels.
		/// </summary>
		private Vector2 PixelMousePosition
		{
			get
			{
				var mousePosition = Input.mousePosition;
				return new Vector2(mousePosition.x, mousePosition.y);
			}
		}

		/// <summary>
		/// Returns the mouse position where it can range from (-1,-1) to (1,1)
		/// </summary>
		private Vector2 RelativeMousePosition
		{
			get
			{
				var screenResolution = Screen.currentResolution;

				var halfScreenWidth = screenResolution.width / 2;
				var halfScreenHeight = screenResolution.height / 2;
				var midPoint = new Vector2(halfScreenWidth, halfScreenHeight);

				var mouseDiffrenceToMidPoint = PixelMousePosition - midPoint;

				return new Vector2(
					mouseDiffrenceToMidPoint.x / halfScreenWidth,
					mouseDiffrenceToMidPoint.y / halfScreenHeight);
			}
		}

		// I GPT'd this, would be very handy to learn though.
		private Vector3 MouseCameraDirection
		{
			get
			{
				var relativeMousePosition = RelativeMousePosition;
				var facingDirection = transform.forward;

				// Find two perpendicular vectors to facingDirection
				var right = Vector3.Cross(Vector3.up, facingDirection).normalized;

				if (right == Vector3.zero)
					right = Vector3.Cross(Vector3.forward, facingDirection).normalized;

				var up = Vector3.Cross(facingDirection, right).normalized;

				// Map MousePosition.x to right and MousePosition.y to up, and include the facingDirection
				var result = facingDirection + relativeMousePosition.x * right + relativeMousePosition.y * up;

				// Normalize the resulting vector if required
				return result.normalized;
			}
		}


		public bool MouseWorldPosition(
			string [] masks,
			out Vector3 worldPosition)
			=> MouseWorldPosition(
				LayerMask.GetMask(masks),
				out worldPosition);

		public bool MouseWorldPosition(
			LayerMask layerMask,
			out Vector3 worldPosition)
		{
			worldPosition = Vector3.zero;
			RaycastHit hit;

			var hitObject = Physics.Raycast(
				transform.position,
				MouseCameraDirection,
				out hit,
				Mathf.Infinity,
				layerMask);

			if (hitObject)
			{
				Debug.Log(hit.collider.transform.name);
				worldPosition = hit.point;
			}

			return hitObject;
		}


		public void Update()
		{
			if(Input.GetMouseButtonDown(0))
			{
				var hitSomeithign = MouseWorldPosition(new string[] { "Ground" }, out var mousePos);
				if (hitSomeithign)
				{
					GameObject.Instantiate(SpawnThing, mousePos, SpawnThing.transform.rotation);
				}
			}
		}
	}
}