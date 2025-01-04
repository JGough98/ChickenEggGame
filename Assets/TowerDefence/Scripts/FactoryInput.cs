using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	using System.Linq;
	using TriggerEnterExit;


	[RequireComponent(typeof(ConveyorItemFieldOfView))]
	public class FactoryInput : MonoBehaviour
	{
		public event AnimationFinished OnInputProcessed;


		[SerializeField]
		private ConveyorItemFieldOfView conveyorItemFieldOfView;

		private bool recieved;


		public bool Received => recieved;


		public void PerformInputAnimation()
		{
			var nextInput = conveyorItemFieldOfView.Targets.First();

			nextInput.CallDestroy();
			recieved = conveyorItemFieldOfView.Targets.Any();
			OnInputProcessed?.Invoke();
		}


		private void Awake()
		{
			Subscribe();
		}

		private void InputRecieved()
		{
			recieved = true;
		}

		private void Subscribe()
		{
			conveyorItemFieldOfView.OnItemReceived += () => InputRecieved();
		}

		private void UnSubscribe()
		{
			conveyorItemFieldOfView.OnItemReceived -= () => InputRecieved();
		}

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