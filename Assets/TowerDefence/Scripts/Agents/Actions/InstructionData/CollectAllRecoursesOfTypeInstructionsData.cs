using UnityEngine.AI;


namespace Assets.TowerDefence.Scripts.Agents.Actions.InstructionData
{
	using Enums;


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


		public CollectAllRecoursesOfTypeInstructionsData(
			ERecourseType recouseToCollect,
			NavMeshAgent agent)
		{
			this.RecouseToCollect = recouseToCollect;
			this.Agent = agent;
		}
	}
}