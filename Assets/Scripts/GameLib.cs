﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//GameLibary_C_Sharp
public static class GameLib{
    public static void JJMove(CharacterController cc, Transform target, CharacterStat stat)
    {
        Transform transform = cc.transform;
        Vector3 dir = target.position - transform.position;
        dir.y = 0.0f;
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), stat.rs * Time.deltaTime);
        }
        Vector3 deltaMove = Vector3.MoveTowards(transform.position, target.position,stat.s * Time.deltaTime) - transform.position;
        deltaMove.y = -stat.fall * Time.deltaTime;
        cc.Move(deltaMove);
    }
}