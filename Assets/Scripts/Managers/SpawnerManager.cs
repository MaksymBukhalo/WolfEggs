using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerManager : MonoBehaviour
{
	public List<SpawnEggs> GutterList;
	public List<ChikenAnimationController> ChikenControllers;
	public List<ChikenAnimationController> OstrichControllers;
	public ScoreManager ScoreManag;
	public LifeManager lifManager;
	public Text text;
	public LevelDifficultyManager DifficultyManager;
	public bool GameIsRunning;
	public float _eggsSpwanCoolDown = 4;
	private float _eggsMinSpwanCoolDown = 1.5f;
	private float _sizeValueInstatiateNewFoarse = 25;
	private float _dificulty = 0;
	private float _valueDecreaseCoolDown = 0.97f;
	private float optimalForse = 2.5f;
	private int randomSpawnOstrichEggs;
	private bool _isGameRestart =false;

	public void StartGame()
	{
		RandomOstrichValue();
		_dificulty = _sizeValueInstatiateNewFoarse;
		StartCoroutine(SpawnerEggs());
	}

	private IEnumerator SpawnerEggs()
	{
		yield return new WaitForSeconds(3f);
		while (GameIsRunning)
		{
			if (ScoreManag.Score == randomSpawnOstrichEggs)
			{
				int NumberGutterList = Random.Range(0, 4);
				OstrichControllers[NumberGutterList].gameObject.SetActive(true);
				ChikenControllers[NumberGutterList].gameObject.SetActive(false);
				GutterList[NumberGutterList].StartSpawnOstrichEggs();
				OstrichControllers[NumberGutterList].StartLayEggs();
				yield return new WaitForSeconds(3f);
				OstrichControllers[NumberGutterList].gameObject.SetActive(false);
				ChikenControllers[NumberGutterList].gameObject.SetActive(true);
				RandomOstrichValue();
			}
			else
			{
				int NumberGutterList = Random.Range(0, 4);
				GutterList[NumberGutterList].StartSpawnChikenEggs();
				ChikenControllers[NumberGutterList].StartLayEggs();
				yield return new WaitForSeconds(_eggsSpwanCoolDown);
			}
			GameDifficultyLevel();
			if(randomSpawnOstrichEggs< ScoreManag.Score)
			{
				RandomOstrichValue();
			}
		}
	}

	private void GameDifficultyLevel()
	{
		if (_eggsSpwanCoolDown > _eggsMinSpwanCoolDown)
		{
			_eggsSpwanCoolDown = _eggsSpwanCoolDown * _valueDecreaseCoolDown;
			text.text = "Time" + _eggsSpwanCoolDown;
		}
		if (GutterList[0].ForcePower < optimalForse  && ScoreManag.Score >= _dificulty)
		{
			DifficultyManager.NewDifficultyLevel(_dificulty, ref _sizeValueInstatiateNewFoarse, ref _eggsMinSpwanCoolDown,ref _isGameRestart, ref _eggsSpwanCoolDown);
			if(_isGameRestart)
			{
				RestartTimeAndForce();
				RandomOstrichValue();
				_isGameRestart = false;
			}
			for (int i = 0; i < GutterList.Count; i++)
			{
				GutterList[i].ForcePower *= 1.3f;
			}
			_dificulty += _sizeValueInstatiateNewFoarse;
			_sizeValueInstatiateNewFoarse = _sizeValueInstatiateNewFoarse * 2;
		}
	}

	public void RestartGame()
	{
		_sizeValueInstatiateNewFoarse = 25;
		_dificulty = _sizeValueInstatiateNewFoarse;
		ScoreManag.Score = 0;
		RestartTimeAndForce();
		RandomOstrichValue();
		StartCoroutine(SpawnerEggs());
	}

	private void RestartTimeAndForce()
	{
		_eggsSpwanCoolDown = 4;
		for (int i = 0; i < GutterList.Count; i++)
		{
			if (i < 2)
			{
				GutterList[i].ForcePower = 1f;
			}
			else
			{
				GutterList[i].ForcePower = -1f;
			}
			GameIsRunning = true;
		}
		lifManager.ActivateLife();
	}

	private void RandomOstrichValue()
	{
		randomSpawnOstrichEggs = Random.Range(5, 10);
		randomSpawnOstrichEggs = ScoreManag.Score + randomSpawnOstrichEggs;
	}
}
