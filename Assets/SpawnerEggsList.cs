using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEggsList : MonoBehaviour
{
	public List<GameObject> EggsList;
	[SerializeField] private int _howManyEggs;
	[SerializeField] private GameObject _eggsPrefabs;
	[SerializeField] private List<GameObject> _eggsInSceneList;

	private void Start()
	{
		_eggsPrefabs.SetActive(false);
		StartInstatiateEggs();
	}

	private void StartInstatiateEggs()
	{
		for (int i = 0; i < _howManyEggs; i++)
		{
			EggsList.Add(Instantiate(_eggsPrefabs, transform));
		}
	}

	public GameObject IntstatiateEggs()
	{
		GameObject egg = EggsList[0];
		EggsList.RemoveAt(0);
		egg.SetActive(true);
		_eggsInSceneList.Add(egg);
		return egg;
	}

	public void DestroyEggs(GameObject egg)
	{
		egg.transform.localScale = new Vector3(2f, 2f, 2f);
		_eggsInSceneList.Remove(egg);
		EggsList.Add(egg);
		egg.SetActive(false);
		egg.transform.position = transform.position;
	}

	public void DestroyEggs(GameObject egg, float time)
	{
		StartCoroutine(WaitBeforeDestroy(time));
		egg.transform.localScale = new Vector3(2f, 2f, 2f);
		_eggsInSceneList.Remove(egg);
		EggsList.Add(egg);
		egg.SetActive(false);
		egg.transform.position = transform.position;
	}

	private IEnumerator WaitBeforeDestroy(float time)
	{
		yield return new WaitForSeconds(time);
	}

	public void DestroyAllEggs()
	{
		while(_eggsInSceneList.Count >0)
		{
			GameObject egg = _eggsInSceneList[0];
			_eggsInSceneList.RemoveAt(0);
			EggsList.Add(egg);
		}
	}
}
