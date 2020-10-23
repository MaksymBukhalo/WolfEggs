using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
	public List<SpawnEggs> GutterList;
	public ScoreManager ScoreManag;
	public bool GameIsRunning;
	public float _eggsSpwanCoolDown = 3;
	private float _sizeValueInstatiateNewFoarse = 10;
	private float _valueDecreaseCoolDown = 0.99f;
	private float optimalForse = 2.5f;

	private void Start()
	{
		StartCoroutine(SpawnerEggs());
	}

	private IEnumerator SpawnerEggs()
	{
		yield return new WaitForSeconds(5f);
		while (GameIsRunning)
		{
			int NumberGutterList = Random.Range(0, 4);
			GutterList[NumberGutterList].StartSpawn();
			yield return new WaitForSeconds(_eggsSpwanCoolDown);
			GameDifficultyLevel();
		}
	}

	private void GameDifficultyLevel()
	{
		if (_eggsSpwanCoolDown > 0.5f)
		{
			_eggsSpwanCoolDown = _eggsSpwanCoolDown * _valueDecreaseCoolDown;
		}
		if (ScoreManag.Score > _sizeValueInstatiateNewFoarse && GutterList[0].ForcePower < optimalForse)
		{
			for (int i = 0; i < GutterList.Count; i++)
			{
				GutterList[i].ForcePower *= 1.3f;
			}
			_sizeValueInstatiateNewFoarse += _sizeValueInstatiateNewFoarse;
		}
	}

	public void RestartGame()
	{
		for (int i = 0; i < GutterList.Count; i++)
		{
			GutterList[i].ForcePower = 1f;
			_eggsSpwanCoolDown = 3f;
			GameIsRunning = true;
		}
		StartCoroutine(SpawnerEggs());
	}
}
