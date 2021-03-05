using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1C : MonoBehaviour
{

    public GameObject Cube;
    public GameObject Spot1;
    public GameObject Spot2;
    public float count;

    private Vector3 _startPosition;
    private float _progress = 0.005f;
    private bool _isFirstPoint = true;

    private List<Vector3> point = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        point.Add(transform.position);
        point.Add(Spot1.transform.position);
        point.Add(Spot2.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (count < 1.0f)
        {
            count += _progress;

            Vector3 m1 = Vector3.Lerp(point[0], point[1], count);
            Vector3 m2 = Vector3.Lerp(point[1], point[2], count);
            Cube.transform.position = Vector3.Lerp(m1, m2, count);
        }
    }
}
