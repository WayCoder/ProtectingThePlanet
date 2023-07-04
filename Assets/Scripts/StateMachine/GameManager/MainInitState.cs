using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MainInitState : State
{

    private GameManager gameManager;

    public MainInitState(StateMachine stateMachine, GameManager gameManager) : base(stateMachine)
    {
        this.gameManager = gameManager;
    }

    public override void Check()
    {
       
    }

    public override void Enter()
    {
        gameManager.state = GameManager.State.MainInit;



    }

    public override void Execute()
    {
        
    }

    public override void Exit()
    {
       

    }
}
