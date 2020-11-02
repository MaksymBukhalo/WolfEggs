using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
	public Color ActiveColor;
	public Color DeActiveColor;
	public List<Image> LifeImages;
	public bool isOsctrichEggs;
	public EndGameMenuManager GameOverManager;
	public ScoreManager scoreManager;

	private int _numberLife = 0;

	public void EggsDestroy()
	{
		if (!isOsctrichEggs)
		{
			TakingAwayLife(1);
		}
		else
		{
			TakingAwayLife(2);
		}
	}

	private void TakingAwayLife(int numbersLife)
	{
		if (_numberLife < LifeImages.Count)
		{
			for (int i = 0; i < numbersLife; i++)
			{
				if (_numberLife < LifeImages.Count)
				{
					LifeImages[_numberLife].color = DeActiveColor;
					_numberLife++;
				}
			}
			if (_numberLife == LifeImages.Count)
			{
				GameOverManager.SetNewRecord(scoreManager.Score);
			}
		}
	}

	public void ActivateLife()
	{
		for (int i = 0; i < LifeImages.Count; i++)
		{
			LifeImages[i].color = ActiveColor;
		}
		_numberLife = 0;
	}
}
