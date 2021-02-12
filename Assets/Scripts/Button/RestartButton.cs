using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
	[SerializeField] private List<TriggerForEggsInGutter> _triggerEggs;
	[SerializeField] private SpawnerEggsList _eggsList;
	[SerializeField] private ScoreManager _scoreManager;
	[SerializeField] private EggsSpawnManager _spawnerManagers;
	[SerializeField] private GameObject _gameEndUI;
	[SerializeField] private GameObject _gameStopUI;
	[SerializeField] private GameObject _uIHelp;

	public void RestartGame()
	{
		ReSetTriggerEggs();
		_eggsList.DestroyAllEggs();
		_spawnerManagers.RestartGame();
		_gameEndUI.SetActive(false);
		_gameStopUI.SetActive(false);
		_uIHelp.SetActive(true);
		_scoreManager.Score = 0;
		Time.timeScale = 1;
	}

	private void ReSetTriggerEggs()
	{
		for(int i = 0;i<_triggerEggs.Count;i++)
		{
			_triggerEggs[i].RestartAudio();
		}
	}
}
