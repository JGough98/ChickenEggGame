using UnityEngine;


public class RunWayPoint : MonoBehaviour
{
	[SerializeField]
	private Transform ground;


	private Vector2 HalfTopDownSize => new Vector2(
		transform.localScale.x/2,
		transform.localScale.z/2);

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


	public Vector3 RandomWayPointPostion
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