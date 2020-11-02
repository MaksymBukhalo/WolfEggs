using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenuController : MonoBehaviour
{
	public EndGameMenuManager GameOverManager;
	public ScoreManager scoreManager;

	private void Update()
	{
		if(scoreManager.Score >=1000)
		{
			GameOverManager.SetNewRecord(1000);
		}
	}
}
