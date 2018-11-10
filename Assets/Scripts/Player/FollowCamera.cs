using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
    // Use this for initialization
    public Transform target;
    public float camSpeed = 0.125f;
    public Vector3 offset;
	// Update is called once per frame
	void LateUpdate () {
        offset.x = 9;
        offset.z = 9;
        offset.y = 9;
        Vector3 DPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, DPosition, camSpeed);
        transform.position = smoothPosition;
        transform.LookAt(target);
    }
}
