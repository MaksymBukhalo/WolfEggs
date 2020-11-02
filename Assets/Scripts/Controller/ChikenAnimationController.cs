using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChikenAnimationController : MonoBehaviour
{
	public Animation WingFlexed;
	public AudioSource ChikenAudio;

	public void StartLayEggs()
	{
		WingFlexed.Play();
		ChikenAudio.Play();
	}
}
