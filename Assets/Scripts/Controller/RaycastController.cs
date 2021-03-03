using System;
using System.Collections.Generic;

namespace UnityEngine.EventSystems
{
	public class RaycastController : MonoBehaviour
	{
		public OVRInputModule inputModule;
		public GameObject ControllerRighthandTraking;
		public GameObject RaycastStartPoin;
		private void LateUpdate()
		{
			if (ControllerRighthandTraking.activeSelf)
			{
				inputModule.rayTransform = RaycastStartPoin.transform;
			}
		}
	}
}
