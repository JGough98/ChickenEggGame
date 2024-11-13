using UnityEngine.AI;


namespace Assets.TowerDefence.Scripts.Agents.Actions.InstructionData
{
	using Enums;


	public struct CollectAllRecoursesOfTypeInstructions
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


		public CollectAllRecoursesOfTypeInstructions(
			ERecourseType recouseToCollect,
			NavMeshAgent agent)
		{
			this.RecouseToCollect = recouseToCollect;
			this.Agent = agent;
		}
	}
}