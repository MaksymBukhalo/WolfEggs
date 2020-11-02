using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StopMenuManager : MonoBehaviour
{
	public ScoreManager ScoreManag;
	public TextMeshPro YourScore;
	public SpawnerManager SpawnerManagerValue;
	public GameObject StopMenu;
	void Update()
	{
		if (OVRInput.Get(OVRInput.Button.Start))
		{
			Time.timeScale = 0;
			StopMenu.SetActive(true);
			YourScore.text = "You Score: " +ScoreManag.Score;
		}
	}

	public void ContinueButton()
	{
		StopMenu.SetActive(false);
		Time.timeScale = 1;
	}

	public void RestartButton()
	{
		StopMenu.SetActive(false);
		Time.timeScale = 1;
		SpawnerManagerValue.RestartGame();
	}
}
