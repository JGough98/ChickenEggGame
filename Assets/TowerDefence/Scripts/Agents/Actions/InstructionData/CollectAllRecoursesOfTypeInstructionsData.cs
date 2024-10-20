using UnityEngine.AI;

namespace Assets.TowerDefence.Scripts.Agents.Actions.InstructionData
{
	public struct CollectAllRecoursesOfTypeInstructionsData
	{
		public ERecourseType RecouseToCollect
		{
			get;
			private set;
		}

		public NavMeshAgent Agent
		{
			get;
			private set;
		}
	}
}