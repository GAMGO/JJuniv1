using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimEvent : MonoBehaviour {

    private SlimeFSMManager manager;
    private void Awake()
    {
        manager = transform.root.GetComponent<SlimeFSMManager>();
    }

    void AttackHitCheck()
    {
        manager.AttackCheck();
    }

}
