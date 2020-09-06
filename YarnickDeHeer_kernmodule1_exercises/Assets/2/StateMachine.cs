using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private State CurrentS;
    private Dictonary<System.Type,State> states = new Dictonary<System.Type,State>();
     Start is called before the first frame update
    void OnStart()
    {
       AddState(new IdleState(this));
       AddState(new Attackstate(this));
    }

    // Update is called once per frame
    void OnUpdate()
    {
        CurrentS?.OnUpdate();
    }

    public void SwitchState()
    {
        CurrentS?.OnExit();
        CurrentS = states[type];
        CurrentS?.OnEnter();
    }

    public void AddState()
    {
       states.Add(states.GetType(), state);
    }
}
