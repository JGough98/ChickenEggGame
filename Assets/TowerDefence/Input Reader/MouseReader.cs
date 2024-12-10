using UnityEngine;
using UnityEngine.EventSystems;


namespace Assets.TowerDefense.Scripts.InputReader
{
	public class MouseReader : MonoBehaviour
	{
		[SerializeField]
		private GameObject SpawnThing;


		private Ray MouseToCameraPosition => Camera.main.ScreenPointToRay(Input.mousePosition);

		private bool IsOverUI => EventSystem.current.IsPointerOverGameObject();


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

			if (!IsOverUI && Physics.Raycast(
				MouseToCameraPosition,
				out var hit,
				Mathf.Infinity,
				layerMask))
			{
				worldPosition = hit.point;

				return true;
			}

			return false;
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