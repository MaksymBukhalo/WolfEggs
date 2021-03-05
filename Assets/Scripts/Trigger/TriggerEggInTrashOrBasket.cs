using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEggInTrashOrBasket : MonoBehaviour
{
	[SerializeField] private SpawnerEggsList _spawnerEggsList;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 12)
		{
			_spawnerEggsList.DestroyEggs(other.gameObject, 1f);
		}
	}
}
