using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerState
{
    IDLE = 0,
    RUN,
    CHASE,
    ATTACK
}
public class FSMManager: MonoBehaviour {

    public PlayerState currentState;
    public PlayerState startState;
    public Transform marker;
    public Animation ani;
    public CharacterStat stat;
    Dictionary<PlayerState, PlayerFSMState> states = new Dictionary<PlayerState, PlayerFSMState>();
    private void Awake()
    {
        marker = GameObject.FindGameObjectWithTag("Marker").transform;
        ani = GetComponentInChildren<Animation>();
        stat = GetComponent<CharacterStat>();
        states.Add(PlayerState.IDLE,GetComponent<PlayerIDLE>());
        states.Add(PlayerState.RUN,GetComponent<PlayerRUN>());
        states.Add(PlayerState.CHASE,GetComponent<PlayerCHASE>());
        states.Add(PlayerState.ATTACK,GetComponent<PlayerATTACK>()); 
    }
    public void SetState(PlayerState newState)
    {
        //too long to type all States So, we should make it simple.
        //Initialization All the States with 'foreach' code.
        foreach (PlayerFSMState fsm in states.Values)
        {
            fsm.enabled = false;
        }
        //Start newState.
        states[newState].enabled = true;
        states[newState].BeginState();
    }
    void Start () {
        SetState(startState);
    }
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(r,out hit,1000)){
                marker.position = hit.point;
                /*Initialization All the States in new veriable and change PlayerStates to Suitable State.*/
                SetState(PlayerState.RUN);
            }
        }
    }
}