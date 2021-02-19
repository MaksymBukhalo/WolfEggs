using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggsSpawnManager : MonoBehaviour
{
	public Text text;
	public bool GameIsRunning;
	public float EggsSpwanCoolDown = 5;
	public int ActiveGutterNow = 4;

	[SerializeField] private List<SpawnEggs> _gutterList;
	[SerializeField] private List<ChikenAnimationController> _chikenControllers;
	[SerializeField] private List<ChikenAnimationController> _ostrichControllers;
	[SerializeField] private List<int> _flagsInstatiateNewSpawnTime;
	//[SerializeField] private List<float> _eggsSpwanCoolDownLevel
	[SerializeField] private ScoreManager _scoreManag;
	[SerializeField] private LifeManager _lifeManager;
	[SerializeField] private LevelDifficultyManager _difficultyManager;
	[SerializeField] private List<int> _activeGutter;
	[SerializeField] private SpawnerEggsList _spawnerEggsList;
	[SerializeField] private float _maxTimeCoolDown = 4f;
	[SerializeField] private float _minTimeCoolDown = 2f;


	private int _HowManyEggsInScene;
	private int _spawnerProcentChikenEggs = 85;
	private int _spawnerProcentOstrichEggs = 100;
	private int _spawnerProcentChikenFailedEggs = 95;
	private float _valueDecreaseCoolDown = 0.98f;
	private float _sizeValueInstatiateNewFoarse = 25;
	private float optimalForse = 4f;
	private bool _isGameRestart = false;
	private bool _activateSwithCutter = false;
	private float _switchGutterSpwanCoolDown = 10f;
	private float _spanwCoolDownResert = -1;
	private List<GameObject> _eggsList;
	private int _valueRestartDificulty = 100;
	private int _deltaScore = 30;
	private float _deltaTime = 0.3f;

	private void Start()
	{
		ActiveGutter(4);
		_eggsList = _spawnerEggsList.EggsList;
	}

	private void Update()
	{
		//if (_activateSwithCutter)
		//{
		//	ActiveGutter(ActiveGutterNow);
		//	_activateSwithCutter = false;
		//}
	}

	public void StartGame()
	{
		StartCoroutine(SpawnerEggs());
	}

	private IEnumerator SpawnerEggs()
	{
		//StartCoroutine(SwitchGutterActive());
		yield return new WaitForSeconds(3f);
		while (GameIsRunning)
		{
			int eggsSpaw = Random.Range(0, 100);
			if (_eggsList.Count > _HowManyEggsInScene && eggsSpaw < _spawnerProcentChikenEggs)
			{
				int NumberGutterList = ReturnIndexGutterFromSpawn();
				_gutterList[NumberGutterList].StartSpawnChikenEggs();
				_chikenControllers[NumberGutterList].StartLayEggs();
				yield return new WaitForSeconds(EggsSpwanCoolDown);
			}
			else if (_eggsList.Count > _HowManyEggsInScene && eggsSpaw > _spawnerProcentChikenEggs && eggsSpaw < _spawnerProcentChikenFailedEggs)
			{
				int NumberGutterList = ReturnIndexGutterFromSpawn();
				_gutterList[NumberGutterList].StartSpawnFailedEggs();
				_chikenControllers[NumberGutterList].StartLayEggs();
				yield return new WaitForSeconds(EggsSpwanCoolDown);
			}
			else if (_eggsList.Count > _HowManyEggsInScene && eggsSpaw > _spawnerProcentChikenFailedEggs && eggsSpaw < _spawnerProcentOstrichEggs)
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
			else
			{
				yield return new WaitForSeconds(EggsSpwanCoolDown);
			}
			NewCoolDown();
		}
	}

	public void SetNewCoolDown()
	{
		Debug.Log("3    " + EggsSpwanCoolDown);
		Debug.Log("4	" + _minTimeCoolDown);
		if (EggsSpwanCoolDown >= _minTimeCoolDown)
		{
			Debug.Log(5);
			EggsSpwanCoolDown = EggsSpwanCoolDown * _valueDecreaseCoolDown;
			text.text = "Time" + EggsSpwanCoolDown;
		}
	}

	public void RestartGame()
	{
		_sizeValueInstatiateNewFoarse = 25;
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

	private void NewLevelDificalt()
	{
		int score = _scoreManag.Score;
		if (score > _spanwCoolDownResert)
		{
			if (score < _flagsInstatiateNewSpawnTime[0])
			{
				_HowManyEggsInScene = 45;
				ActiveGutterNow = 4;
				_spawnerProcentOstrichEggs = 95;
				_valueDecreaseCoolDown = 0.8f;
				_switchGutterSpwanCoolDown = 5f;
				_spanwCoolDownResert = _flagsInstatiateNewSpawnTime[0] - 1;
				EggsSpwanCoolDown = _maxTimeCoolDown * _valueDecreaseCoolDown;
			}
			else if (score > _flagsInstatiateNewSpawnTime[0] && score < _flagsInstatiateNewSpawnTime[1])
			{
				_HowManyEggsInScene = 40;
				ActiveGutterNow = 2;
				_spawnerProcentOstrichEggs = 95;
				_valueDecreaseCoolDown = 0.9f;
				_switchGutterSpwanCoolDown = 5f;
				_spanwCoolDownResert = _flagsInstatiateNewSpawnTime[1] - 1;
				EggsSpwanCoolDown = _maxTimeCoolDown * _valueDecreaseCoolDown;
				_minTimeCoolDown *= _valueDecreaseCoolDown;
			}
			else if (score > _flagsInstatiateNewSpawnTime[1] && score < _flagsInstatiateNewSpawnTime[2])
			{
				_HowManyEggsInScene = 30;
				ActiveGutterNow = 2;
				_spawnerProcentOstrichEggs = 97;
				_valueDecreaseCoolDown = 0.95f;
				_switchGutterSpwanCoolDown = 15f;
				_spanwCoolDownResert = _flagsInstatiateNewSpawnTime[2] - 1;
				EggsSpwanCoolDown = _maxTimeCoolDown * _valueDecreaseCoolDown;
				_minTimeCoolDown *= _valueDecreaseCoolDown;
			}
			else if (score > _flagsInstatiateNewSpawnTime[2] && score < _flagsInstatiateNewSpawnTime[3])
			{
				_HowManyEggsInScene = 20;
				ActiveGutterNow = 3;
				_spawnerProcentOstrichEggs = 100;
				_valueDecreaseCoolDown = 0.97f;
				_switchGutterSpwanCoolDown = 25f;
				_spanwCoolDownResert = _flagsInstatiateNewSpawnTime[3] - 1;
				EggsSpwanCoolDown = _maxTimeCoolDown * _valueDecreaseCoolDown;
				_minTimeCoolDown *= _valueDecreaseCoolDown;
			}
			else
			{
				_HowManyEggsInScene = 10;
				ActiveGutterNow = 4;
				_spawnerProcentOstrichEggs = 100;
				_valueDecreaseCoolDown = 0.98f;
				_switchGutterSpwanCoolDown = 30f;
			}
		}
	}

	private void NewCoolDown()
	{
		int score = _scoreManag.Score;
		if (score > _spanwCoolDownResert)
		{
			if (score < _flagsInstatiateNewSpawnTime[0])
			{
				Debug.Log(1);
				_HowManyEggsInScene = 48;
				_spawnerProcentOstrichEggs = 95;
				_valueDecreaseCoolDown = 0.95f;
				_maxTimeCoolDown = 5f;
				_minTimeCoolDown = 3.5f;
				_spanwCoolDownResert = _flagsInstatiateNewSpawnTime[0] - 1;
				EggsSpwanCoolDown = _maxTimeCoolDown;
			}
			else if (score > _flagsInstatiateNewSpawnTime[0] && score < _flagsInstatiateNewSpawnTime[1])
			{
				Debug.Log(2);
				_HowManyEggsInScene = 40;
				_spawnerProcentOstrichEggs = 95;
				_valueDecreaseCoolDown = 0.96f;
				EggsSpwanCoolDown = _minTimeCoolDown;
				_maxTimeCoolDown -= 1f;
				_minTimeCoolDown -= 1f;
				_spanwCoolDownResert = _flagsInstatiateNewSpawnTime[1] - 1;
				_deltaScore = 30;
				_deltaTime = 0.3f;
			}
			else if(score>_valueRestartDificulty)
			{
				_HowManyEggsInScene = 30;
				_spawnerProcentOstrichEggs = 97;
				_valueDecreaseCoolDown = 0.96f;
				_maxTimeCoolDown = 3.5f;
				_minTimeCoolDown = 2.5f;
				EggsSpwanCoolDown = _maxTimeCoolDown;
				_deltaScore = 20;
				_spanwCoolDownResert = _valueRestartDificulty;
				_deltaTime += 0.1f;
			}
			else if (score > _spanwCoolDownResert+_deltaScore)
			{
				Debug.Log(3);
				_HowManyEggsInScene = 30;
				_spawnerProcentOstrichEggs = 97;
				_valueDecreaseCoolDown = 0.98f;
				EggsSpwanCoolDown = _minTimeCoolDown;
				_maxTimeCoolDown -= _deltaTime;
				_minTimeCoolDown -= _deltaTime;
				_spanwCoolDownResert += _deltaScore;
			}
		}
	}

	private int ReturnIndexGutterFromSpawn()
	{
		int returnIndex = Random.Range(0, 4);
		return _activeGutter[returnIndex];
	}

	public void EggsDestroty()
	{
		_spawnerEggsList.DestroyAllEggs();
		EggsSpwanCoolDown = _maxTimeCoolDown;
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
}
