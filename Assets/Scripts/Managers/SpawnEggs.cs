using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEggs : MonoBehaviour
{

	public bool IsLeftSide;

	public float ForcePower = 1f;
	[SerializeField]
	private Transform _spawnpoint;
	[SerializeField]
	private GameObject _eggsPrefab;


	public void StartSpawn()
	{
		PushEggs();
	}


	private void PushEggs()
	{
		GameObject newEgg = Instantiate(_eggsPrefab, _spawnpoint.position, _eggsPrefab.transform.rotation);
		newEgg.GetComponent<Rigidbody>().AddForce(Vector3.left * ForcePower, ForceMode.VelocityChange);
		Destroy(newEgg, 5f);
	}
}
