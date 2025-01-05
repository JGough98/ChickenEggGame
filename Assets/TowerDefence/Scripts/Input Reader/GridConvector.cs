using UnityEngine;


namespace Assets.TowerDefense.Scripts.InputReader
{
	public class GridConvector : MonoBehaviour
	{
		[SerializeField]
		private float gridXSize;
		[SerializeField]
		private float gridZSize;
		private float halfGridXSize;
		private float halfGridZSize;


		private void Awake()
		{
			halfGridXSize = gridXSize / 2;
			halfGridZSize = gridZSize / 2;
		}


		public Vector3 ConvertToWorldPosition(
			Vector3 position)
			=> new Vector3(
				WorldCordinate(
					position.x,
					gridXSize,
					halfGridXSize),
				position.y,
				WorldCordinate(
					position.z,
					gridZSize,
					halfGridZSize));

		private float WorldCordinate(
			float postion,
			float gridSize,
			float halfGridSize)
			=> postion >= 0
				? (((int)(postion / gridSize) + 1) * gridSize) - halfGridSize
				: (((int)(postion / gridSize) - 1) * gridSize) + halfGridSize;
		}
	}
