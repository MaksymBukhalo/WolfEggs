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
	public int level1 = 200;
	public int level2 = 500;
	private int _compliteGameScore = 1000;

	public void NewDifficultyLevel(float levelValue, ref float eggsMinSpawnCoolDown,ref bool isgGameRestart,ref float cooldown,ref List<int> newTimeList,ref List<float> _eggsSpwanCoolDownLevel)
	{
		if(levelValue >=level1 && levelValue < level2 && _isNewLevel)
		{
			MusicGame.clip = Clip2;
			MusicGame.Play();
			eggsMinSpawnCoolDown = _timeDificaltelevel1;
			cooldown = 3f;
			isgGameRestart = true;
			_isNewLevel = false;
			for(int i = 0;i<newTimeList.Count;i++)
			{
				newTimeList[i] = newTimeList[i] + level1;
			}
			for (int i = 0; i < _eggsSpwanCoolDownLevel.Count; i++)
			{
				_eggsSpwanCoolDownLevel[i] -=0.5f;
			}

		}
		else if (levelValue >= level2 && !_isNewLevel)
		{
			MusicGame.clip = Clip1;
			MusicGame.Play();
			cooldown = 3f;
			eggsMinSpawnCoolDown = _timeDificaltelevel2;
			isgGameRestart = true;
			_isNewLevel = true;

			for (int i = 0; i < newTimeList.Count; i++)
			{
				newTimeList[i] = newTimeList[i] + level2;
			}
		}
	}
}
