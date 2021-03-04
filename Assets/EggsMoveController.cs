using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggsMoveController : MonoBehaviour
{

	public Vector3 StartPositionMove;
	public Vector3 EndPositionMove;

	[SerializeField] private AudioSource _eggsMoveAudio;
	[SerializeField] private Rigidbody _eggRigidbody;
	[SerializeField] private float _rotationValue;
	[SerializeField] private float _stepMove;

	private Coroutine _moveEgg;
	private float _count = 0f;


	public void SetSpotsMove(Transform startSpot, Transform endSpot)
	{
		KilleCoroutine();
		_count = 0f;
		StartPositionMove = startSpot.position;		EndPositionMove = endSpot.position;
		_moveEgg =  StartCoroutine(MoveEggCoroutine());
	}

	private IEnumerator MoveEggCoroutine()
	{
		float value = 0f;
		_eggRigidbody.isKinematic = true;
		while (_count < 1f)
		{
			_count += _stepMove;
			transform.position = Vector3.Lerp(StartPositionMove, EndPositionMove, _count);
			transform.Rotate(_rotationValue, 0f, 0f);
			if (value < _count)
			{
				_eggsMoveAudio.Play();
				value += 0.25f;
			}
			yield return new WaitForEndOfFrame();
		}
		_eggRigidbody.isKinematic = false;
		yield break;
	}

	private void KilleCoroutine()
	{
		if(_moveEgg!=null)
		{
			StopCoroutine(_moveEgg);
			_moveEgg = null;
		}
	}
}
