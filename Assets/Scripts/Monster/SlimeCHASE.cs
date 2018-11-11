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

        if (!GameLib.DetectCharacter(manager.sight, manager.PlayerCc))
        {
            manager.SetState(SlimeState.IDLE);
            return;
           
        }
        GameLib.JJMove(manager.scc, manager.PlayerCc.transform, manager.stat);
        if (Vector3.Distance(transform.position, manager.PlayerCc.transform.position) < manager.stat.slimeRange)
        {
            manager.SetState(SlimeState.ATTACK);
            return;
        }
    }
}
