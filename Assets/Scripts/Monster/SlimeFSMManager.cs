using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SlimeState
{
    IDLE = 0,
    PATROL,
    CHASE,
    ATTACK
}

public class SlimeFSMManager : MonoBehaviour {
    public Animator slani;
    public SlimeState startState;
    public SlimeState currentState;
    public SlimeStat stat;
    public Transform player;
    public CharacterController scc;
    public Camera sight;

   Dictionary<SlimeState,SlimeFSMState> states = new Dictionary<SlimeState, SlimeFSMState>();
   private void Awake()
   {
        slani = GetComponentInChildren<Animator>();
        stat = GetComponent<SlimeStat>();
        states.Add(SlimeState.IDLE, GetComponent<SlimeIDLE>());
        states.Add(SlimeState.PATROL, GetComponent<SlimePATROL>());
        states.Add(SlimeState.CHASE, GetComponent<SlimeCHASE>());
        states.Add(SlimeState.ATTACK, GetComponent<SlimeATTACK>());
        scc = GetComponent<CharacterController>();
        sight = GetComponentInChildren<Camera>();
    }

    public void SetState(SlimeState newState)
    {
        foreach(SlimeFSMState fsm in states.Values){
            fsm.enabled = false;
        }
        states[newState].enabled = true;
        states[newState].BeginState();
        currentState = newState;
        slani.SetInteger("CurrentState",(int)currentState);
    }
    void Start () {
        SetState(startState);
	}
	
	// Update is called once per frame
	void Update () {
	}
    private void OnDrawGizmos()
    {
        if(sight!= null)
        {
            Matrix4x4 temp = Gizmos.matrix;
            Gizmos.color = Color.red;
            Gizmos.matrix = Matrix4x4.TRS(sight.transform.position, sight.transform.rotation,Vector3.one);
            Gizmos.DrawFrustum(sight.transform.position,sight.fieldOfView,sight.farClipPlane,sight.nearClipPlane,sight.aspect);
            Gizmos.matrix = temp;
        }
    }
}
