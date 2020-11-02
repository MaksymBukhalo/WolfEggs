using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCapTrigger : MonoBehaviour
{
	public bool IsSuperCapActive = false;

	private void OnTriggerStay(Collider other)
	{
		if(other.gameObject.layer ==10)
		{
			IsSuperCapActive = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == 10)
		{
			IsSuperCapActive = false;
		}
	}
}
