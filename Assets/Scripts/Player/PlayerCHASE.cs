using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCHASE : PlayerFSMState {
    public override void BeginState()
    {
        base.BeginState();
        manager.ani.CrossFade("KK_Run");
    }
    // Use this for initialization
    void Start () {
		
	}
	void Update () {
        Debug.Log("CHASE");
    }
}
