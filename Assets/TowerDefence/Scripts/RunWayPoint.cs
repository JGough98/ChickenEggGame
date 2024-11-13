using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	// TODO - Would be nice to set the Ground reference on reset,
	// could do this by searching for nav mesh agents checking their navmesh type.
	public class RunWayPoint : MonoBehaviour
	{
		[SerializeField]
		private Transform ground;


		private Vector2 HalfTopDownSize => new Vector2(
			transform.localScale.x / 2,
			transform.localScale.z / 2);

		private Vector2 RandomTopDownsize
		{
			get
			{
				var halfTopDownSize = HalfTopDownSize;

				return new Vector2(
					Random.Range(
						-halfTopDownSize.x,
						halfTopDownSize.x),
					Random.Range(
						-halfTopDownSize.y,
						halfTopDownSize.y));
			}
		}


		public Vector3 RandomWayPointPosition
		{
			get
			{
				var randomTopDownSize = RandomTopDownsize;

				return new Vector3(
					transform.position.x + randomTopDownSize.x,
					ground.position.y,
					transform.position.z + randomTopDownSize.y);
			}
		}
	}
}