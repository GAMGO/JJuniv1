using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//FSM State Perentclass
public class PlayerFSMState : MonoBehaviour {
    public FSMManager manager;
    public virtual void BeginState()
    {

    }
    private void Awake()
    {
        manager = GetComponent<FSMManager>();
    }
}
