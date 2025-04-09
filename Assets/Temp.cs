using Assets.TowerDefense.Scripts.Agents;
using Assets.TowerDefense.Scripts.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
	private Timer timer;

	private ConveyorItem ConveyorItem;

	private void Awake()
	{
		ConveyorItem = GetComponent<ConveyorItem>();
		timer = new Timer();
		timer.Start(8);
	}

	private void Update()
	{
		if(timer.Finished)
		{
			ConveyorItem.SafeDestroy();
		}
	}
}
