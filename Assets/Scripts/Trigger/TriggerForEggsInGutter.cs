using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForEggsInGutter : MonoBehaviour
{
	public bool IsEggsInGutter;

	[SerializeField] private AudioSource _audioEggs;
	[SerializeField] private SpawnEggs _spawnEggs;
	private int i = 0;

	public void RestartAudio()
	{
		IsEggsInGutter = false;
		_audioEggs.Stop();
		i = 0;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 8)
		{
			_audioEggs.Play();
			i++;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 8)
		{
			IsEggsInGutter = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == 8)
		{
			IsEggsInGutter = false;
			i--;
			if (i == 0)
			{
				_audioEggs.Stop();
			}
			if (other.gameObject.name == _spawnEggs._nameOstrichEggs)
			{
				other.gameObject.layer = 14;
			}
			else if (other.gameObject.name == _spawnEggs._nameFailEggs)
			{
				other.gameObject.layer = 19;
			}
			else
			{
				other.gameObject.layer = 11;
			}
		}
	}
}
