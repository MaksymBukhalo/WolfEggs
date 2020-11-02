using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEggs : MonoBehaviour
{

	public bool IsLeftSide;
	public List<Material> MaterialsEggs;
	public float ForcePower = 1f;
	[SerializeField] private Transform _spawnpoint;
	public  GameObject _eggsPrefab;
	private float _timeLifeEggs =10f;
	private Transform _ostrichEggs;
	private MeshRenderer _eggsMeshRender;

	private void Start()
	{
		_eggsMeshRender = _eggsPrefab.GetComponent<MeshRenderer>();
		_ostrichEggs = _eggsPrefab.transform;
	}

	public void StartSpawnChikenEggs()
	{
		RandomNewColorEggs();
		PushEggs();
	}

	public void StartSpawnOstrichEggs()
	{
		_eggsMeshRender.material = MaterialsEggs[0];
		_ostrichEggs.localScale = new Vector3(5, 5, 5);
		PushEggs();
		_ostrichEggs.localScale = new Vector3(2, 2, 2);
	}

	private void PushEggs()
	{
		
		GameObject newEgg = Instantiate(_eggsPrefab, _spawnpoint.position, _eggsPrefab.transform.rotation);
		if (IsLeftSide)
		{
			newEgg.GetComponent<Rigidbody>().AddForce(Vector3.up * ForcePower, ForceMode.VelocityChange);
		}
		else
		{
			newEgg.GetComponent<Rigidbody>().AddForce(Vector3.down * ForcePower, ForceMode.VelocityChange);
		}
		Destroy(newEgg, _timeLifeEggs);
	}

	private void RandomNewColorEggs()
	{
		int i = Random.Range(0, MaterialsEggs.Count);
		_eggsMeshRender.material = MaterialsEggs[i];
	}
}
