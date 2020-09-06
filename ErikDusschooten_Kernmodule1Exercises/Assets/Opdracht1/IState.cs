using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    StateMachine owner { get; set; }
    void OnUpdate();
    void OnEnter();
    void OnExit();
}
