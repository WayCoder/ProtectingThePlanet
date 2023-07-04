using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    protected StateMachine StateMachine;

    public State(StateMachine stateMachine)
    {
        StateMachine = stateMachine;    
    }

    public abstract void Check();

    public abstract void Enter();

    public abstract void Execute();

    public abstract void Exit();
}
