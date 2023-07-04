using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RunTimeState : State
{
    private GameManager gameManager;

    public RunTimeState(StateMachine stateMachine, GameManager gameManager) : base(stateMachine)
    {
        this.gameManager = gameManager;
    }
    public override void Check()
    {

    }
    public override void Enter()
    {
        gameManager.state = GameManager.State.RunTime;


    }
    public override void Execute()
    {

    }
    public override void Exit()
    {

    }
}