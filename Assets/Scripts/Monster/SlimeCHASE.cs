using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCHASE : SlimeFSMState{
    public override void BeginState()
    {
        base.BeginState();
    }
    // Update is called once per frame
    void Update () {
        Debug.Log("SlimeCHASE");
        
        Vector3 diff = manager.player.position - transform.position;
        diff.y = 0.0f;
        if (diff.magnitude < manager.stat.slimeRange)
        {
            manager.SetState(SlimeState.ATTACK);
        }
    }
}
