using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCHASE : PlayerFSMState {
    public override void BeginState()
    {
        base.BeginState();
        manager.ani.CrossFade("KK_Run");
    }
	void Update () {
        Debug.Log("CHASE");
        Vector3 dir = manager.target.position - transform.position;
        dir.y = 0.0f;
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), manager.stat.rs * Time.deltaTime);
        }
        Vector3 deltaMove = Vector3.MoveTowards(transform.position, manager.target.position, manager.stat.s * Time.deltaTime) - transform.position;
        deltaMove.y = -manager.stat.fall * Time.deltaTime;
        manager.cc.Move(deltaMove);
        Vector3 diff = manager.target.position - transform.position;
        diff.y = 0.0f;
        if (diff.magnitude < 0.1f)
        {
            manager.SetState(PlayerState.IDLE);
        }
    }
}
