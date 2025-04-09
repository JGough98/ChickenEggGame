using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	public class NaturalRecourseMinerPlaced : NaturalRecourseMiner
	{
		[SerializeField]
		private GameObject @object;

		[SerializeField]
		private float waitTime;


		private void Start()
		{
			Setup(new NaturalRecourseMinerSetup(
				@object,
				waitTime));
		}
	}
}