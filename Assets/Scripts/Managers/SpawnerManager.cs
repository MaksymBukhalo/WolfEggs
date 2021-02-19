using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerManager : MonoBehaviour
{
	public Text text;
	public bool GameIsRunning;
	public float EggsSpwanCoolDown = 5;
	public int ActiveGutterNow = 4;

	[SerializeField] private List<SpawnEggs> _gutterList;
	[SerializeField] private List<ChikenAnimationController> _chikenControllers;
	[SerializeField] private List<ChikenAnimationController> _ostrichControllers;
	[SerializeField] private List<int> _flagsInstatiateNewSpawnTime;
	[SerializeField] private List<float> _eggsSpwanCoolDownLevel;
	[SerializeField] private ScoreManager _scoreManag;
	[SerializeField] private LifeManager _lifeManager;
	[SerializeField] private LevelDifficultyManager _difficultyManager;
	[SerializeField] private List<int> _activeGutter;

	private int _spawnerProcentChikenEggs = 85;
	private int _spawnerProcentOstrichEggs = 100;
	private int _spawnerProcentChikenFailedEggs = 95;
	private float _valueDecreaseCoolDown = 0.98f;
	private float _eggsMinSpwanCoolDown = 2f;
	private float _sizeValueInstatiateNewFoarse = 25;
	private float _dificulty = 0;
	private float optimalForse = 4f;
	private bool _isGameRestart = false;
	private bool _activateSwithCutter = false;
	private float _switchGutterSpwanCoolDown = 10f;
	private float _spanwCoolDownResert = -1;


	private float _minSpawnCoollDown = 0f;
	private float _maxSpawnCoollDown = 0f;
	private float _deltaSpeed;

	private void Update()
	{
		if (_activateSwithCutter)
		{
			ActiveGutter(ActiveGutterNow);
			_activateSwithCutter = false;
		}
	}

	public void StartGame()
	{
		_dificulty = _sizeValueInstatiateNewFoarse;
		StartCoroutine(SpawnerEggs());
	}

	private IEnumerator SpawnerEggs()
	{
		StartCoroutine(SwitchGutterActive());
		SetSpawnCoolDown();
		yield return new WaitForSeconds(3f);
		while (GameIsRunning)
		{
			int eggsSpaw = Random.Range(0, 100);
			if (eggsSpaw < _spawnerProcentChikenEggs)
			{
				int NumberGutterList = ReturnIndexGutterFromSpawn();
				_gutterList[NumberGutterList].StartSpawnChikenEggs();
				_chikenControllers[NumberGutterList].StartLayEggs();
				yield return new WaitForSeconds(EggsSpwanCoolDown);
			}
			else if (eggsSpaw > _spawnerProcentChikenEggs && eggsSpaw < _spawnerProcentChikenFailedEggs)
			{
				int NumberGutterList = ReturnIndexGutterFromSpawn();
				_gutterList[NumberGutterList].StartSpawnFailedEggs();
				_chikenControllers[NumberGutterList].StartLayEggs();
				yield return new WaitForSeconds(EggsSpwanCoolDown);
			}
			else if (eggsSpaw > _spawnerProcentChikenFailedEggs && eggsSpaw < _spawnerProcentOstrichEggs)
			{
				int NumberGutterList = ReturnIndexGutterFromSpawn();
				_ostrichControllers[NumberGutterList].gameObject.SetActive(true);
				_chikenControllers[NumberGutterList].gameObject.SetActive(false);
				_gutterList[NumberGutterList].StartSpawnOstrichEggs();
				_ostrichControllers[NumberGutterList].StartLayEggs();
				yield return new WaitForSeconds(EggsSpwanCoolDown);
				_ostrichControllers[NumberGutterList].gameObject.SetActive(false);
				_chikenControllers[NumberGutterList].gameObject.SetActive(true);
			}
			GameDifficultyLevel();
		}
	}

	private void GameDifficultyLevel()
	{

		//if (_gutterList[0].ForcePower < optimalForse && _scoreManag.Score >= _dificulty)
		//{
		//	_difficultyManager.NewDifficultyLevel(_scoreManag.Score, ref _eggsMinSpwanCoolDown, ref _isGameRestart, ref EggsSpwanCoolDown, ref _flagsInstatiateNewSpawnTime, ref _eggsSpwanCoolDownLevel);
		//	if (_isGameRestart)
		//	{
		//		RestartTimeAndForce();
		//		_isGameRestart = false;
		//	}
		//	for (int i = 0; i < _gutterList.Count; i++)
		//	{
		//		_gutterList[i].ForcePower *= 1.3f;
		//	}
		//}
		//SetSpawnCoolDown();
		//if (EggsSpwanCoolDown > _eggsMinSpwanCoolDown)
		//{
		//	EggsSpwanCoolDown = EggsSpwanCoolDown * _valueDecreaseCoolDown;
		//	text.text = "Time" + EggsSpwanCoolDown;
		//}
	}

	private void SetSpawnCoolDown()
	{
		int score = _scoreManag.Score;
		if (score > _spanwCoolDownResert)
		{
			if (score < _flagsInstatiateNewSpawnTime[0])
			{
				_dificulty = _eggsSpwanCoolDownLevel[0];
				_eggsMinSpwanCoolDown = _eggsSpwanCoolDownLevel[0];
				ActiveGutterNow = 4;
				_spawnerProcentOstrichEggs = 95;
				_valueDecreaseCoolDown = 1;
				_switchGutterSpwanCoolDown = 5f;
				_spanwCoolDownResert = _flagsInstatiateNewSpawnTime[0] - 1;
				EggsSpwanCoolDown = _eggsSpwanCoolDownLevel[0];
			}
			else if (score > _flagsInstatiateNewSpawnTime[0] && score < _flagsInstatiateNewSpawnTime[1])
			{
				_dificulty = _flagsInstatiateNewSpawnTime[1];
				_eggsMinSpwanCoolDown = _eggsSpwanCoolDownLevel[1];
				ActiveGutterNow = 2;
				_spawnerProcentOstrichEggs = 95;
				_valueDecreaseCoolDown = 0.9f;
				_switchGutterSpwanCoolDown = 5f;
				_spanwCoolDownResert = _flagsInstatiateNewSpawnTime[1] - 1;
				EggsSpwanCoolDown = 4f;
			}
			else if (score > _flagsInstatiateNewSpawnTime[1] && score < _flagsInstatiateNewSpawnTime[2])
			{
				_dificulty = _flagsInstatiateNewSpawnTime[2];
				_eggsMinSpwanCoolDown = _eggsSpwanCoolDownLevel[2];
				ActiveGutterNow = 2;
				_spawnerProcentOstrichEggs = 97;
				_valueDecreaseCoolDown = 0.99f;
				_switchGutterSpwanCoolDown = 15f;
				_spanwCoolDownResert = _flagsInstatiateNewSpawnTime[2] - 1;
				EggsSpwanCoolDown = _eggsSpwanCoolDownLevel[1];
			}
			else if (score > _flagsInstatiateNewSpawnTime[2] && score < _flagsInstatiateNewSpawnTime[3])
			{
				_dificulty = _flagsInstatiateNewSpawnTime[3];
				_eggsMinSpwanCoolDown = _eggsSpwanCoolDownLevel[3];
				ActiveGutterNow = 3;
				_spawnerProcentOstrichEggs = 100;
				_valueDecreaseCoolDown = 0.98f;
				_switchGutterSpwanCoolDown = 25f;
				_spanwCoolDownResert = _flagsInstatiateNewSpawnTime[3] - 1;
				EggsSpwanCoolDown = _eggsSpwanCoolDownLevel[2];
			}
			else
			{
				ActiveGutterNow = 4;
				_eggsMinSpwanCoolDown = _eggsSpwanCoolDownLevel[4];
				_spawnerProcentOstrichEggs = 100;
				_valueDecreaseCoolDown = 0.98f;
				_switchGutterSpwanCoolDown = 30f;
			}
		}
	}

	public void RestartGame()
	{
		_sizeValueInstatiateNewFoarse = 25;
		_dificulty = _sizeValueInstatiateNewFoarse;
		_scoreManag.Score = 0;
		RestartTimeAndForce();
		StartCoroutine(SpawnerEggs());
	}

	private void RestartTimeAndForce()
	{
		EggsSpwanCoolDown = 5.5f;
		for (int i = 0; i < _gutterList.Count; i++)
		{
			if (i < 2)
			{
				_gutterList[i].ForcePower = 1f;
			}
			else
			{
				_gutterList[i].ForcePower = -1f;
			}
			GameIsRunning = true;
		}
		_lifeManager.ActivateLife();
	}

	private int ReturnIndexGutterFromSpawn()
	{
		int returnIndex = Random.Range(0, _activeGutter.Count);
		return _activeGutter[returnIndex];
	}
	private void ActiveGutter(int gutterValue)
	{
		_activeGutter = new List<int>();
		int i = 0;
		while (i < gutterValue)
		{
			int gutterActiveNumber = Random.Range(0, 4);
			if (_activeGutter == null || _activeGutter.IndexOf(gutterActiveNumber) == -1)
			{
				_activeGutter.Add(gutterActiveNumber);
				i++;
			}
		}
	}
	private IEnumerator SwitchGutterActive()
	{
		while (true)
		{
			_activateSwithCutter = true;
			yield return new WaitForSeconds(_switchGutterSpwanCoolDown);
		}
	}
	//private void SetActiveGutter()
	//{
	//	for(int i = 0;i<_activeGutter.Count;i++)
	//	{
	//		_gutterList[_activeGutter[i]].IsEctive = true;
	//	}
	//}

	//private void DeActiveGutter()
	//{
	//	for (int i = 0; i < _gutterList.Count; i++)
	//	{
	//		_gutterList[i].IsEctive = false;
	//	}
	//}

	//private void RandomOstrichValue()
	//{
	//	randomSpawnOstrichEggs = Random.Range(5, 10);
	//	randomSpawnOstrichEggs = _scoreManag.Score + randomSpawnOstrichEggs;
	//}

}
