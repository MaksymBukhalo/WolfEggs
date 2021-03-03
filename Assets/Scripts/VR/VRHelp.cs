using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHelp : MonoBehaviour
{
	/// <summary>
	/// The root GameObject that represents the Oculus Touch for Quest And RiftS Controller model (Left).
	/// </summary>
	public GameObject m_modelOculusTouchQuestAndRiftSLeftController;
	/// <summary>
	/// The root GameObject that represents the Oculus Touch for Quest And RiftS Controller model (Right).
	/// </summary>
	public GameObject m_modelOculusTouchQuestAndRiftSRightController;
	/// <summary>
	/// The root GameObject that represents the Oculus Touch for Rift Controller model (Left).
	/// </summary>
	public GameObject m_HandTracingLeft;
	///// <summary>
	///// The root GameObject that represents the Oculus Touch for Rift Controller model (Right).
	///// </summary>
	public GameObject m_HandTracingRight;
	///// <summary>
	/// The controller that determines whether or not to enable rendering of the controller model.
	/// </summary>
	public OVRInput.Controller m_controller;
	private enum ControllerType
	{
		QuestAndRiftS = 1,
		Rift = 2,
	}
	private ControllerType activeControllerType = ControllerType.Rift;
	private bool m_prevControllerConnected = false;
	private bool m_prevControllerConnectedCached = false;
	void Start()
	{
		OVRPlugin.SystemHeadset headset = OVRPlugin.GetSystemHeadsetType();
		switch (headset)
		{
			case OVRPlugin.SystemHeadset.Rift_CV1:
				activeControllerType = ControllerType.Rift;
				break;
			default:
				activeControllerType = ControllerType.QuestAndRiftS;
				break;
		}
		Debug.LogFormat("OVRControllerHelp: Active controller type: {0} for product {1}", activeControllerType, OVRPlugin.productName);
	}
	void Update()
	{
		bool controllerConnected = OVRInput.IsControllerConnected(m_controller);
		if ((controllerConnected != m_prevControllerConnected) || !m_prevControllerConnectedCached)
		{
			if (activeControllerType == ControllerType.Rift)
			{
				m_modelOculusTouchQuestAndRiftSLeftController.SetActive(false);
				m_modelOculusTouchQuestAndRiftSRightController.SetActive(false);
			}
			else if (activeControllerType == ControllerType.QuestAndRiftS)
			{
				m_modelOculusTouchQuestAndRiftSLeftController.SetActive(controllerConnected && (m_controller == OVRInput.Controller.LTouch));
			}
			m_prevControllerConnected = controllerConnected;
			m_prevControllerConnectedCached = true;
			if (m_modelOculusTouchQuestAndRiftSLeftController.activeSelf)
			{
				m_modelOculusTouchQuestAndRiftSRightController.SetActive(true);
				m_HandTracingLeft.SetActive(false);
				m_HandTracingRight.SetActive(false);
			}
			else
			{
				m_modelOculusTouchQuestAndRiftSRightController.SetActive(false);
				m_HandTracingLeft.SetActive(true);
				m_HandTracingRight.SetActive(true);
			}
		}
	}
}
