using UnityEngine.AI;


namespace Assets.TowerDefense.Scripts.Agents.Actions.InstructionData
{
	using Enums;


	public struct CollectAllRecoursesOfTypeInstructions
	{
		public ERecourseType RecourseToCollect
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
			ERecourseType recourseToCollect,
			NavMeshAgent agent)
		{
			this.RecourseToCollect = recourseToCollect;
			this.Agent = agent;
		}
	}
}