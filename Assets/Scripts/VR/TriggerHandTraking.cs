using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandTraking : MonoBehaviour
{
	public GameObject Cap;
	public GameObject SuperCap;
	public SuperCapTrigger SuperCapTrigger;

	private void Update()
	{
		if(SuperCapTrigger.IsSuperCapActive)
		{
			Cap.SetActive(false);
			SuperCap.SetActive(true);
		}
		else
		{
			SuperCap.SetActive(false);
			Cap.SetActive(true);
		}
	}
}
