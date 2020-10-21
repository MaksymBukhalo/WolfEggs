using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpManager : MonoBehaviour
{
	[SerializeField] private List<TriggerForEggsInGutter> _triggerForEggsInGutters;
	[SerializeField] private List<NestColorAlfa> _nestColorAlfas;


	private Color activeColor;
	private Color deActiveColor;

	private void Start()
	{
		activeColor = _nestColorAlfas[0].ActiveColor;
		deActiveColor = _nestColorAlfas[0].DeActiveColor;
	}

	private void Update()
	{
		ActivateHelp();
	}

	private void ActivateHelp()
	{
		for(int i = 0;i<_triggerForEggsInGutters.Count;i++)
		{
			if(_triggerForEggsInGutters[i].IsEggsInGutter == true)
			{
				_nestColorAlfas[i].ImageOne.color = activeColor;
				_nestColorAlfas[i].ImageTwo.color = activeColor;
			}
			else
			{
				_nestColorAlfas[i].ImageOne.color = deActiveColor;
				_nestColorAlfas[i].ImageTwo.color = deActiveColor;
			}
		}
	}
}
