using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameLib
{
    public static bool DetectCharacter(Camera sight, CharacterController cc)
    {
        Plane[] ps = GeometryUtility.CalculateFrustumPlanes(sight);
        return GeometryUtility.TestPlanesAABB(ps, cc.bounds);
    }

    public static void JJRotate(Transform transform, Vector3 destination, CharacterStat stat)
    {
        // B-A는 A에서 B로 향하는 벡터.
        Vector3 dir = destination - transform.position;
        dir.y = 0.0f;
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    Quaternion.LookRotation(dir),
                    stat.rs * Time.deltaTime
                );
        }
    }
    public static void JJRotate(Transform transform, Vector3 destination, SlimeStat stat)
    {
        // B-A는 A에서 B로 향하는 벡터.
        Vector3 dir = destination - transform.position;
        dir.y = 0.0f;
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    Quaternion.LookRotation(dir),
                    stat.slimeRotat* Time.deltaTime
                );
        }
    }

    public static void JJMove(CharacterController cc, Vector3 destination, CharacterStat stat)
    {
        Transform transform = cc.transform;

        JJRotate(transform, destination, stat);

        Vector3 deltaMove = Vector3.MoveTowards(
            transform.position,
            destination,
            stat.s * Time.deltaTime) - transform.position;

        deltaMove.y = -stat.fall * Time.deltaTime;

        cc.Move(deltaMove);
    }
    public static void JJMove(CharacterController scc, Vector3 destination, SlimeStat stat)
    {
        Transform transform = scc.transform;

        JJRotate(transform, destination, stat);

        Vector3 deltaMove = Vector3.MoveTowards(
            transform.position,
            destination,
            stat.slimeSpeed * Time.deltaTime) - transform.position;

        deltaMove.y = -stat.slimeFall * Time.deltaTime;

        scc.Move(deltaMove);
    }

    public static void JJMove(CharacterController cc, Transform target, CharacterStat stat)
    {
        Transform transform = cc.transform;
        JJMove(cc, target.position, stat);
    }
    public static void JJMove(CharacterController scc, Transform target, SlimeStat stat)
    {
        Transform transform = scc.transform;
        JJMove(scc, target.position, stat);
    }

}
