using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerForEggsInBasket : MonoBehaviour
{
	public AudioSource aggsinGutter;
	public ScoreManager ScoreManag;
	public int AddScoreValue =1;
	[SerializeField] private Transform Basket;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 11)
		{
			other.transform.parent = Basket;
			other.gameObject.layer = 12;
			ScoreManag.Score += AddScoreValue ;
			ScoreManag.ScoreText.text = "Score: " + ScoreManag.Score;
			aggsinGutter.Play();
			Destroy(other.gameObject, 1f);
		}
		else if (gameObject.layer == 15 && other.gameObject.layer == 14)
		{
			other.transform.parent = Basket;
			other.gameObject.layer = 12;
			ScoreManag.Score += AddScoreValue*10;
			ScoreManag.ScoreText.text = "Score: " + ScoreManag.Score;
			aggsinGutter.Play();
			Destroy(other.gameObject, 1f);
		}
	}
}
