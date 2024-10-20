using System;
using UnityEngine;


[Flags]
public enum ERecourseType
{
	IRON = 1 >> 0,
	SULFUR = 1 >> 1,
}


public class DepositDropOffData : ScriptableObject
{
	// Make this a flag of allowed recourses
	[SerializeField]
	public readonly ERecourseType AcceptedRecourses;
}

public class DepositDropOff : MonoBehaviour
{
	[SerializeField]
	private DepositDropOffData depositDropOffData;


	public bool AcceptsRecourse(ERecourseType recourseType)
		=> depositDropOffData.AcceptedRecourses.HasFlag(recourseType);
}


public class RecourseDepositData : ScriptableObject
{
	[SerializeField]
	public readonly ERecourseType Type;

	[SerializeField]
	public readonly float TimeTakenToCollect;

	[SerializeField]
	public readonly float QuantityGathered;

	[SerializeField]
	public readonly int StackCount;
}


public class RecourseDeposit : MonoBehaviour
{
	[SerializeField]
	private RecourseDepositData recourseDeposit;

	private int recoursesTaken;
	private int claimOnRecourse;


	private int RecoursesRemaning => recourseDeposit.StackCount - recoursesTaken;


	public bool CanStartCollecting => RecoursesRemaning - claimOnRecourse > 0;

	public float TimeTakenToCollect => recourseDeposit.TimeTakenToCollect;
	public float QuantityGathered => recourseDeposit.QuantityGathered;

	public ERecourseType Type => recourseDeposit.Type;


	public void StartCollecting()
	{
		claimOnRecourse++;
	}

	public void CancleCollecting()
	{
		claimOnRecourse++;
	}

	public void RemoveRecourse()
	{
		recoursesTaken++;
	}
}