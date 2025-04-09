using Assets.TowerDefense.Scripts.Utility;
using Assets.TowerDefense.Scripts.Utility.GO;
using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	public struct NaturalRecourseMinerSetup
	{
		public GameObject Object { get; }

		public float WaitTime { get; }


		public NaturalRecourseMinerSetup(GameObject @object, float waitTime)
		{
			this.Object = @object;
			this.WaitTime = waitTime;
		}
	}

	public class NaturalRecourseMiner : MonoBehaviour
	{
		[SerializeField]
		private RecourseOutput output;

		private ITimer timer;

		private NaturalRecourseMinerSetup naturalRecourse;


		public void Setup(NaturalRecourseMinerSetup naturalRecourseMinerSetup)
		{
			this.naturalRecourse = naturalRecourseMinerSetup;
			StartTimer();
		}


		private void Awake()
		{
			timer = new Timer();
		}

		private void Update()
		{
			if(timer.Finished)
			{
				StartTimer();

				GameObjectUtility.Instantiate(
					naturalRecourse.Object,
					output.OutputPosition.transform.position,
					SpawnType.RECOURSE,
					true);
			}
		}

		private void StartTimer()
		{
			timer.Start(naturalRecourse.WaitTime);
		}

		private void Reset()
		{
			output = gameObject.GetComponent<RecourseOutput>();
		}
	}
}