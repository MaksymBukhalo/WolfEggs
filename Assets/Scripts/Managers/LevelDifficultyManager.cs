using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDifficultyManager : MonoBehaviour
{
	public AudioSource MusicGame;
	public AudioClip Clip1;
	public AudioClip Clip2;
	private float _timeDificaltelevel1 = 1f;
	private float _timeDificaltelevel2 = 0.5f;
	private bool _isNewLevel = true;
	private int level1 = 200;
	private int level2 = 500;
	private int _compliteGameScore = 1000;

	public void NewDifficultyLevel(float levelValue,ref float newFoarseValue, ref float eggsMinSpawnCoolDown,ref bool isgGameRestart,ref float cooldown)
	{
		if(levelValue >=level1 && levelValue < level2 && _isNewLevel)
		{
			MusicGame.clip = Clip2;
			MusicGame.Play();
			newFoarseValue = 50f;
			eggsMinSpawnCoolDown = _timeDificaltelevel1;
			cooldown = 3f;
			isgGameRestart = true;
			_isNewLevel = false;
		}
		else if (levelValue >= level2 && !_isNewLevel)
		{
			MusicGame.clip = Clip1;
			MusicGame.Play();
			newFoarseValue = 50f;
			cooldown = 3f;
			eggsMinSpawnCoolDown = _timeDificaltelevel2;
			isgGameRestart = true;
			_isNewLevel = true;
		}
	}
}
