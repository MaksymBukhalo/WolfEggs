using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberController : MonoBehaviour
{
	public OVRInput.Controller _controller;
	[SerializeField] private GameObject _basket;
	[SerializeField] private GameObject _superCap;
	[SerializeField] private Vector3 _localPositionBasket;
	[SerializeField] private Vector3 _localRotationBasket;
	[SerializeField] private SuperCapTrigger capTrigger;
	private bool _basketInHand = true;

	private Transform _positoInHand;

	private void Start()
	{
		_positoInHand = gameObject.transform;
	}
	private void Update()
	{
		if (_controller == OVRInput.Controller.LTouch)
		{
			if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && _basketInHand)
			{
				_basket.SetActive(true);
			}
			if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
			{
				_basket.SetActive(false);
			}
		}
		if (_controller == OVRInput.Controller.RTouch)
		{
			if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && _basketInHand)
			{
				_basket.SetActive(true);
			}
			if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
			{
				_basket.SetActive(false);
			}
		}
		if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && capTrigger.IsSuperCapActive)
		{
			_superCap.SetActive(true);
			_basket.SetActive(false);
		}
		else
		{
			_superCap.SetActive(false);
		}
	}
}
