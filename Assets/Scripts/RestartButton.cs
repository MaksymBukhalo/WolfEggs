using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
	public ScoreManager scoreManager;
	public SpawnerManager SpawnerManagers;
	public LifeManager lifeManager;
	public GameObject canvas;
	public GameObject Score;
	public void RestartGame()
	{
		SpawnerManagers.RestartGame();
		lifeManager.ActivateLife();
		canvas.SetActive(false);
		Score.SetActive(true);
		scoreManager.Score = 0;
	}
}
