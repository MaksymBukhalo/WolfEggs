using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerForEggsInBasket : MonoBehaviour
{
	public AudioSource aggsinGutter;
	public ScoreManager ScoreManag;
	public int AddScoreValue = 1;

	[SerializeField] private Transform _startPointSpawnTextScoreTextScore;
	[SerializeField] private TextMeshPro _textScore;
	[SerializeField] private LifeManager _lifeManager;
	[SerializeField] private Transform _basket;
	[SerializeField] private EggsSpawnManager _spawnerManager;
	[SerializeField] private SpawnerEggsList _spawnerEggsList;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 11)
		{ 
			other.gameObject.layer = 12;
			ScoreManag.Score += AddScoreValue ;
			InstatiateScore("+" + AddScoreValue);
			_spawnerManager.SetNewCoolDown();
			ScoreManag.ScoreText.text = "Score: " + ScoreManag.Score;
			aggsinGutter.Play();
			_spawnerEggsList.DestroyEggs(other.gameObject, 1f);
		}
		else if(other.gameObject.layer == 19)
		{
			other.gameObject.layer = 12;
			_spawnerManager.EggsSpwanCoolDown *= 0.95f;
			aggsinGutter.Play();
			_spawnerEggsList.DestroyEggs(other.gameObject, 1f);
		}
		else if (gameObject.layer == 15 && other.gameObject.layer == 14)
		{
			other.gameObject.layer = 12;
			ScoreManag.Score += AddScoreValue*5;
			InstatiateScore("+" + AddScoreValue*5);
			ScoreManag.ScoreText.text = "Score: " + ScoreManag.Score;
			aggsinGutter.Play();
			_lifeManager.AddLife(2);
			_spawnerEggsList.DestroyEggs(other.gameObject,1f);
			_spawnerManager.EggsSpwanCoolDown *= 1.15f;
		}
	}

	private void InstatiateScore(string scoreText)
	{
		_textScore.text = scoreText;
		GameObject instatiateScore = Instantiate(_textScore.gameObject);
		instatiateScore.transform.position = _startPointSpawnTextScoreTextScore.position;
		instatiateScore.transform.rotation = _startPointSpawnTextScoreTextScore.rotation;
		Destroy(instatiateScore, 1f);
	}
}
