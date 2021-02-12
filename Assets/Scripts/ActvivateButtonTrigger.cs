using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.EventSystems
{
	public class ActvivateButtonTrigger : MonoBehaviour
	{
		public OVRInputModule inputModule;
		public GameObject SecondFinger;

		private bool isCliked;
		private void Update()
		{
			float distanceFingerClik = Vector3.Distance(SecondFinger.transform.position, gameObject.transform.position);
			if (distanceFingerClik < 0.04)
			{
				inputModule.isEnter = true;
				isCliked = true;
			}
			else if (distanceFingerClik > 0.04 && isCliked)
			{
				inputModule.isExit = true;
				isCliked = false;
			}
		}
	}
}
