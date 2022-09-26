using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFixedOffsetFollow : MonoBehaviour
{
    public Vector3 FollowOffset = Vector3.back * 4.0f + Vector3.up * 3.0f;
    private Transform _cam;
    public Transform FollowTarget;
    void Start()
    {
        _cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        _cam.position = FollowTarget.position + FollowOffset;
        _cam.LookAt(FollowTarget);
    }
}
