using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Assets.TowerDefense.Scripts
{
	using Agents;
	using Utility;


	public delegate void AnimationFinished();


	public partial class FactoryBuilding : MonoBehaviour
	{
		[SerializeField]
		private FactoryProduction factoryProduction;

		[SerializeField]
		private List<FactoryInput> factoryInputs;

		[SerializeField]
		private FactoryOutput factoryOutput;

		private List<ConveyorItemType> recourses;

		private int inputsProcessed;

		private bool processing;


		private void Awake()
		{
			recourses = new List<ConveyorItemType>();
#if UNITY_EDITOR
			Guard.GuardAgainstNull(factoryProduction);
#endif
			factoryProduction.Initialize(gameObject, factoryOutput.OutputPosition);
			Subscribe();
		}

		private void AwaitUntilAllInputsProcessed()
		{
			inputsProcessed++;
			if (inputsProcessed != recourses.Count)
				return;

			var nextRecourse = factoryProduction.CreateRecourse(recourses);
			factoryOutput.PerformOutputAnimation(nextRecourse);
		}

		private void HandleNextFactoryInput(FactoryInput factoryInput)
		{
			var nextRecourse = factoryInput.Received.ConveyorItemRecourseType;

			if (factoryProduction.ShouldReject(recourses, nextRecourse))
			{
				factoryInput.Received.SafeDestroy();
				return;
			}

			recourses.Add(nextRecourse);

			if (recourses.Count == factoryProduction.TotalInputsRequired)
			{
				foreach(var fi in factoryInputs)
				{
					fi.PerformInputAnimation();
				}
			}
		}

		private void Subscribe()
		{
			foreach (var factoryInput in factoryInputs)
			{
				factoryInput.OnInputReceived += (fi) => HandleNextFactoryInput(fi);
				factoryInput.OnInputProcessed += () => AwaitUntilAllInputsProcessed();
			}
		}

		private void UnSubscribe()
		{
			foreach (var factoryInput in factoryInputs)
			{
				factoryInput.OnInputReceived -= (fi) => HandleNextFactoryInput(fi);
				factoryInput.OnInputProcessed -= () => AwaitUntilAllInputsProcessed();
			}
		}


		private void OnDestroy()
			=> UnSubscribe();

		private void Reset()
		{
			factoryProduction = gameObject.GetComponent<FactoryProduction>();
			factoryInputs = gameObject.GetComponentsInChildren<FactoryInput>().ToList();
			factoryOutput = gameObject.GetComponentInChildren<FactoryOutput>();
		}
	}
}