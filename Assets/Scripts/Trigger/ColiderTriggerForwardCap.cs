using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderTriggerForwardCap : MonoBehaviour
{
	[SerializeField] private Transform _trashBinSpot;
	[SerializeField] private EggsSpawnManager _spawnerManager;
	private Vector3 _startPoint;

	private void OnCollisionEnter(Collision collision)
	{
		//if (collision.gameObject.layer == 19)
		//{
		//	_spawnerManager.SetNewCoolDown();
		//	collision.gameObject.layer = 12;
		//	_startPoint = collision.gameObject.transform.position;
		//	collision.gameObject.GetComponent<EggsMoveController>().SetEggFailPathInTrashBin(_startPoint, _trashBinSpot.position);
		//}
	}

}
