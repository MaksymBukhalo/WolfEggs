using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct Gesture
{
	public string name;
	public List<Vector3> FingerDatas;
	public UnityEvent onRecongnized;
}

public class GesturDetector : MonoBehaviour
{
	public float threshold = 0.1f;
	public OVRSkeleton Skeleton;
	public List<Gesture> Gestures;
	public bool debugMode = true;
	private List<OVRBone> _fingerBones;
	private Gesture _previousGesture;

	private void Start()
	{
		_fingerBones = new List<OVRBone>(Skeleton.Bones);
		_previousGesture = new Gesture();
	}

	private void Update()
	{
		_fingerBones = new List<OVRBone>(Skeleton.Bones);
		_previousGesture = new Gesture();
		if (debugMode && Input.GetKeyDown(KeyCode.Space))
		{
			SaveBones();
		}

		Gesture currentGesture = Recognize();
		bool hasRecohniser = !currentGesture.Equals(new Gesture());
		if(hasRecohniser && currentGesture.Equals(_previousGesture))
		{
			Debug.Log("New Gesture" + currentGesture.name);
			_previousGesture = currentGesture;
			currentGesture.onRecongnized.Invoke();
		}
	}

	private void SaveBones()
	{
		_fingerBones = new List<OVRBone>(Skeleton.Bones);
		Gesture g = new Gesture();
		g.name = "New Gesture";
		List<Vector3> data = new List<Vector3>();
		foreach (var bone in _fingerBones)
		{
			data.Add(Skeleton.transform.InverseTransformPoint(bone.Transform.position));
		}
		g.FingerDatas = data;
		Gestures.Add(g);
	}

	private Gesture Recognize()
	{
		Gesture currentGesture = new Gesture();
		float currentMin = Mathf.Infinity;

		foreach(var gesture in Gestures)
		{
			float sumDistance = 0;
			bool isDscared = false;
			for(int i = 0;i<_fingerBones.Count;i++)
			{
				Vector3 currentData = Skeleton.transform.InverseTransformPoint(_fingerBones[i].Transform.position);
				float distance = Vector3.Distance(currentData, gesture.FingerDatas[i]);
				if(distance>threshold)
				{
					isDscared = true;
					break;
				}
				sumDistance += distance;
			}

			if(!isDscared && sumDistance<currentMin)
			{
				currentMin = sumDistance;
				currentGesture = gesture;
			}
		}

		return currentGesture;
	}
}
