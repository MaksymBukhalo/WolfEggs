using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameMenuManager : MonoBehaviour
{
	[SerializeField] private GameObject _infoMenu;
	[SerializeField] private TextMeshPro _youScore;
	[SerializeField] private TextMeshPro _bestScore;
	[SerializeField] private TextMeshPro _youWin;
	[SerializeField] private GameObject _gameOverMenu;
	[SerializeField] private EggsSpawnManager _spawnerManager;
	private int _record;
	private SaveRecords save = new SaveRecords();

	private string _key = "Score";

	private void Start()
	{
		if (PlayerPrefs.HasKey(_key))
		{
			save = JsonUtility.FromJson<SaveRecords>(PlayerPrefs.GetString(_key));
			_record = save.record;
		}
	}
	public void SetNewRecord(int newRecord)
	{
		if (newRecord < 1000)
		{
			_youScore.text = "You Score: " + newRecord;
		}
		else 
		{
			_youScore.gameObject.SetActive(false);
			_youWin.gameObject.SetActive(true);
		}
		_gameOverMenu.SetActive(true);
		if (newRecord > _record)
		{
			_record = newRecord;
			_bestScore.text = "Best Score: " + _record;
			save.record = _record;
			PlayerPrefs.SetString(_key, JsonUtility.ToJson(save));
		}
		else
		{
			_bestScore.text = "Best Score: " + _record;
		}
		_infoMenu.SetActive(false);
		_spawnerManager.GameIsRunning = false;
		_infoMenu.SetActive(false);
	}
}
