using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigerFloor : MonoBehaviour
{
	public LifeManager lifeManager;

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.layer ==8)
		{
			lifeManager.EggsDestroy();
		}
	}
}
