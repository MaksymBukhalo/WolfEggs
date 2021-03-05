using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEggs : MonoBehaviour
{
	//public bool IsEctive;
	public bool IsLeftSide;
	public List<Material> MaterialsEggs;
	//public float ForcePower = 1f;
	public string _nameDefaultEggs = "ChikenEgg";
	public string _nameOstrichEggs = "OstrichEgg";
	public string _nameFailEggs = "FailEgg";
	public float SpeedEggs;
	public float RotationDirection;
	[SerializeField] private Vector3 _rotationEggMove;
	[SerializeField] private Transform _spawnPoint;
	[SerializeField] private Transform _endPoint;
	[SerializeField] private Material _failledEggsMaterial;
	[SerializeField] private SpawnerEggsList _eggsList;

	private Transform _ostrichEggs;
	private MeshRenderer _eggsMeshRender;
	private Rigidbody _eggRigidbody;

	public void StartSpawnChikenEggs()
	{
		GameObject egg = SetEggSetings();
		RandomNewColorEggs();
		egg.name = _nameDefaultEggs;
		egg.GetComponent<EggsMoveController>().SetSpotsMove(_spawnPoint, _endPoint, _rotationEggMove, RotationDirection, SpeedEggs);
		//PushEggs(egg);
	}

	public void StartSpawnOstrichEggs()
	{
		GameObject egg = SetEggSetings();
		_ostrichEggs = egg.transform;
		_eggsMeshRender.material = MaterialsEggs[0];
		_ostrichEggs.localScale = new Vector3(5, 5, 5);
		egg.name = _nameOstrichEggs;
		egg.GetComponent<EggsMoveController>().SetSpotsMove(_spawnPoint, _endPoint, _rotationEggMove, RotationDirection, SpeedEggs);
		//PushEggs(egg);
	}

	public void StartSpawnFailedEggs()
	{
		GameObject egg = SetEggSetings();
		_eggsMeshRender.material = _failledEggsMaterial;
		egg.name = _nameFailEggs;
		egg.GetComponent<EggsMoveController>().SetSpotsMove(_spawnPoint, _endPoint, _rotationEggMove, RotationDirection, SpeedEggs);
		//PushEggs(egg);
	}

	private void PushEggs(GameObject egg)
	{
		//egg.transform.position = _spawnpoint.position;
		//egg.transform.rotation = _spawnpoint.rotation;
		//if (IsLeftSide)
		//{
		//	_eggRigidbody.AddForce(Vector3.up * ForcePower, ForceMode.VelocityChange);
		//}
		//else
		//{
		//	_eggRigidbody.AddForce(Vector3.down * ForcePower, ForceMode.VelocityChange);
		//}
	}

	private void RandomNewColorEggs()
	{
		int i = Random.Range(0, MaterialsEggs.Count);
		_eggsMeshRender.material = MaterialsEggs[i];
	}

	private GameObject SetEggSetings()
	{
		GameObject egg = _eggsList.IntstatiateEggs();
		_eggsMeshRender = egg.GetComponent<MeshRenderer>();
		//_eggRigidbody = egg.GetComponent<Rigidbody>();
		return egg;
	}
}
