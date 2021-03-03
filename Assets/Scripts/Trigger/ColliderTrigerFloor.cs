using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigerFloor : MonoBehaviour
{
	public GameObject EggsDestroy;
	public LifeManager lifeManager;
	public AudioSource DestroedAggsAudio;

	[SerializeField] private HelpManager _helpManager;
	[SerializeField] private SpawnerEggsList _eggsList;
	[SerializeField] private EggsSpawnManager _spawnManager;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 11)
		{
			DestroedAggsAudio.Play();
			lifeManager.EggsDestroy();
			other.gameObject.layer = 8;
			SwithEggsOnEggsDestroy(other.gameObject);
			_spawnManager.EggsDestroty();
			_helpManager.DeactivateColor();
		}
		else if(other.gameObject.layer == 14)
		{
			DestroedAggsAudio.Play();
			lifeManager.isOsctrichEggs = true;
			lifeManager.isOsctrichEggs = false;
			other.gameObject.layer = 8;
			EggsDestroy.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
			SwithEggsOnEggsDestroy(other.gameObject);
			EggsDestroy.transform.localScale = new Vector3(1f, 1f, 1f);
		}
		else if(other.gameObject.layer == 19)
		{
			DestroedAggsAudio.Play();
			other.gameObject.layer = 8;
			SwithEggsOnEggsDestroy(other.gameObject);
		}
	}

	private void SwithEggsOnEggsDestroy(GameObject eggs)
	{
		GameObject eggsDestroy = Instantiate(EggsDestroy, eggs.transform.position, Quaternion.identity);
		ListEggsDestroy listEggsDestroy = eggsDestroy.GetComponent<ListEggsDestroy>();
		listEggsDestroy.EggsDestroyedParts.transform.rotation = eggs.transform.rotation;
		List<MeshRenderer> EggsDestroedList = listEggsDestroy.EggsDestroyList;
		Material eggsMaterial= eggs.GetComponent<MeshRenderer>().material;
		for (int i = 0;i<EggsDestroedList.Count; i++)
		{
			EggsDestroedList[i].material = eggsMaterial;
		}
		_eggsList.DestroyEggs(eggs);
		Destroy(eggsDestroy, 7);
	}
}
