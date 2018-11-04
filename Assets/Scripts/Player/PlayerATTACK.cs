using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerATTACK : PlayerFSMState {
    public override void BeginState()
    {
        base.BeginState();
        manager.ani.CrossFade("KK_Attack");
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("ATTACK");
    }
}
