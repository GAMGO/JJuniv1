using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeATTACK : SlimeFSMState {
    public override void BeginState()
    {
        base.BeginState();
    }
    
    void Update () {
        GameLib.JJRotate(transform, manager.PlayerCc.transform.position, manager.stat);

        if (Vector3.Distance(transform.position, manager.PlayerCc.transform.position) >= manager.stat.slimeRange)
        {
            manager.SetState(SlimeState.CHASE);
            return;
        }
    }
}
