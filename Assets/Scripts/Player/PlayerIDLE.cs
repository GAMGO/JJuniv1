﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIDLE : PlayerFSMState
{

    public override void BeginState()
    {
        base.BeginState();
        manager.marker.gameObject.SetActive(false);
    }

    void Update () {
        Debug.Log("IDLE");

    }
}
