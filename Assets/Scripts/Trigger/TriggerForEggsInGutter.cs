using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForEggsInGutter : MonoBehaviour
{
	public bool IsEggsInGutter;
	int i = 0;

	[SerializeField] private AudioSource _audioEggs;

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
			if (other.gameObject.transform.localScale.x == 5)
			{
				other.gameObject.layer = 14;
			}
			else
			{
				other.gameObject.layer = 11;
			}
		}
	}
}
