using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartMenuController : MonoBehaviour
{
	[SerializeField] private TextMeshPro _bestScore;
	[SerializeField] private GameObject _startMenu;
	[SerializeField] private GameObject _helpMenu;
	[SerializeField] private EggsSpawnManager _spawnerManager;

	private SaveRecords save = new SaveRecords();

	private string _key = "Score";

	private void Start()
	{
		if (PlayerPrefs.HasKey(_key))
		{
			save = JsonUtility.FromJson<SaveRecords>(PlayerPrefs.GetString(_key));
			_bestScore.text = "Best Score: "+ save.record;
		}
	}

	public void StartGameClikButton()
	{
		_helpMenu.SetActive(true);
		_spawnerManager.StartGame();
		_startMenu.SetActive(false);
	}

}
