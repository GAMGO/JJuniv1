using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRUN : PlayerFSMState
{
    public Transform marker;
    public float speed = 3.0f;
	// Use this for initialization
	void Start () {
        marker = GameObject.FindGameObjectWithTag("Maker").transform;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("RUN");
        transform.position = Vector3.MoveTowards(transform.position,marker.position,speed*Time.deltaTime);
        if (Vector3.Distance(transform.position,marker.position)<0.01f)
        {
            GetComponent<FSMManager>().SetState(PlayerState.IDLE);
        }
    }
}
