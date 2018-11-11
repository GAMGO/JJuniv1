using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeIDLE : SlimeFSMState {
    public float idleTime = 5.0f;
    public float elapsedTime = 0;

    public override void BeginState()
    {
        base.BeginState();
        elapsedTime = 0;
    }
    // Update is called once per frame
    void Update () {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= idleTime)
        {
            manager.SetState(SlimeState.PATROL);
            Debug.Log("?");
        }
        if (GameLib.DetectCharacter(manager.sight, manager.PlayerCc))
        {
            manager.SetState(SlimeState.CHASE);
            return;
        }
    }
}
