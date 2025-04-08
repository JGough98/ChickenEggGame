using System.Linq;
using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	using Agents;
	using TriggerEnterExit;


	public delegate void OnRecourseReceived(FactoryInput factoryInput);

	[RequireComponent(typeof(ConveyorItemFieldOfView))]
	public class FactoryInput : MonoBehaviour
	{
		[SerializeField]
		private ConveyorItemFieldOfView conveyorItemFieldOfView;

		private ConveyorItem recieved;


		public event AnimationFinished OnInputProcessed;

		public event OnRecourseReceived OnInputReceived;


		public ConveyorItem Received => recieved;


		public void PerformInputAnimation()
		{
			// Do the animation here.
			conveyorItemFieldOfView.Targets.First().SafeDestroy();
			OnInputProcessed?.Invoke();
		}


		private void Awake()
		{
			Subscribe();
		}

		private void InputRecieved(ConveyorItem conveyorItem)
		{
			recieved = conveyorItem;
			OnInputReceived?.Invoke(this);
		}

		private void Subscribe()
			=> conveyorItemFieldOfView.OnTargetFound += (ci) => InputRecieved(ci);

		private void UnSubscribe()
			=> conveyorItemFieldOfView.OnTargetFound -= (ci) => InputRecieved(ci);

		private void OnDestroy()
		{
			UnSubscribe();
		}

		private void Reset()
		{
			conveyorItemFieldOfView = gameObject.GetComponent<ConveyorItemFieldOfView>();
		}
	}
}