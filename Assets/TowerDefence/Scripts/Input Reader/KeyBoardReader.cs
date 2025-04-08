using UnityEngine;


namespace Assets.TowerDefense.Scripts.InputReader
{
	public delegate void Roatate(Vector3 rotateDirection);


	public class KeyBoardReader : MonoBehaviour
	{
		public event Roatate OnRotateTapped;


		[SerializeField]
		private KeyCode RotateLeft;

		[SerializeField]
		private KeyCode RotateRight;

		private readonly Vector3 right = new Vector3(0, 90, 0);
		private readonly Vector3 left = new Vector3(0, -90, 0);


		void Update()
		{
			if (Input.GetKeyDown(RotateRight))
				OnRotateTapped?.Invoke(right);
			else if (Input.GetKeyDown(RotateLeft))
				OnRotateTapped?.Invoke(left);
		}
	}
}