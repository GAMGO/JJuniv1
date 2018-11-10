using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCHASE : PlayerFSMState {
    public override void BeginState()
    {
        base.BeginState();
    }
	void Update () {
        Debug.Log("CHASE");
        GameLib.JJMove(manager.cc, manager.target, manager.stat);
        Vector3 diff = manager.target.position - transform.position;
        diff.y = 0.0f;
        if (diff.magnitude < manager.stat.attackR)
        {
            manager.SetState(PlayerState.ATTACK);
        }
    }
}
