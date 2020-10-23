using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerForEggsInBasket : MonoBehaviour
{
	public AudioSource aggsinGutter;
	public ScoreManager ScoreManag;
	[SerializeField] private Transform Basket;

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.layer == 8)
		{
			other.transform.parent = Basket;
			ScoreManag.Score++;
			ScoreManag.ScoreText.text = "Score: " + ScoreManag.Score;
			aggsinGutter.Play();		
		}
	}
}
