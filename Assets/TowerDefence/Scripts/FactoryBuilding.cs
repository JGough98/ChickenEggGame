using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	public delegate void AnimationFinished();


	public class FactoryBuilding : MonoBehaviour
	{
		[SerializeField]
		private List<FactoryInput> factoryInputs;

		[SerializeField]
		private FactoryOutput factoryOutput;

		private bool processing;

		private int factoryInputCount;

		private int factoryInputsCompleted;


		private bool StartNextItemProcess => !processing && factoryInputs.All(x => x.Received);


		private void Awake()
		{
			factoryInputCount = factoryInputs.Count();
			Subscribe();
		}

		private void Update()
		{
			if(StartNextItemProcess)
				StartInputProcessing();
		}

		private void StartInputProcessing()
		{
			processing = true;
			foreach (var factoryInput in factoryInputs)
			{
				factoryInput.PerformInputAnimation();
			}
		}

		private void AwaitUntilAllInputsProcessed()
		{
			factoryInputsCompleted++;

			if(factoryInputsCompleted == factoryInputCount)
			{
				factoryOutput.PerformOutputAnimation();
				factoryInputsCompleted = 0;
			}
		}

		private void Subscribe()
		{
			foreach (var factoryInput in factoryInputs)
			{
				factoryInput.OnInputProcessed += () => AwaitUntilAllInputsProcessed();
			}
		}

		private void UnSubscribe()
		{
			foreach (var factoryInput in factoryInputs)
			{
				factoryInput.OnInputProcessed -= () => AwaitUntilAllInputsProcessed();
			}
		}

		private void OnDestroy()
			=> UnSubscribe();

		private void Reset()
		{
			factoryInputs = gameObject.GetComponentsInChildren<FactoryInput>().ToList();
			factoryOutput = gameObject.GetComponentInChildren<FactoryOutput>();
		}
	}
}