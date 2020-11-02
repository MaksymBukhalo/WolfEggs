using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandTraking : MonoBehaviour
{
	public GameObject Cap;
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.layer == 16 || other.gameObject.layer == 17)
		{
			Cap.SetActive(true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == 16 || other.gameObject.layer == 17)
		{
			Cap.SetActive(false);
		}
	}
}
