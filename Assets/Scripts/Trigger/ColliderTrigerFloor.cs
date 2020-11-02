using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigerFloor : MonoBehaviour
{
	public LifeManager lifeManager;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 11)
		{
			lifeManager.EggsDestroy();
			other.gameObject.layer = 8;
		}
		else if(other.gameObject.layer == 14)
		{
			lifeManager.isOsctrichEggs = true;
			lifeManager.EggsDestroy();
			lifeManager.isOsctrichEggs = false;
			other.gameObject.layer = 8;
		}
	}
}
