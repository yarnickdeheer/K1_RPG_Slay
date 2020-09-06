using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : Istate
{
    
    public IdleState(StateMachine owner)
    {
        this.owner = owner;
    }

    protected StateMachine owner;
    
    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
        
    }

    public void OnStart()
    {
        
    }
}
