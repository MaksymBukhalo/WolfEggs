using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenuManager : MonoBehaviour
{
	[SerializeField] private GameObject _score;
	[SerializeField] private Text _youScore;
	[SerializeField] private Text _bestScore;
	[SerializeField] private GameObject _gameOverMenu;
	[SerializeField] private SpawnerManager _spawnerManager;
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
		_youScore.text = "You Score: " +newRecord;
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
		_score.SetActive(false);
		_spawnerManager.GameIsRunning = false;
	}


	//private void OnApplicationQuit()
	//{
	//	PlayerPrefs.SetString(_key, JsonUtility.ToJson(_record));
	//}
}
