using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class RunTimeState : State
{
    private GameManager gameManager;

    private float remainingTime;

    public RunTimeState(StateMachine stateMachine, GameManager gameManager) : base(stateMachine)
    {
        this.gameManager = gameManager;
    }
    public override void Check()
    {
        if (remainingTime <= 0f)
        {
            stateMachine.ChangeState(gameManager.endingState);

            return;
        }
    }
    public override void Enter()
    {
        gameManager.state = GameManager.State.RunTime;

        remainingTime = gameManager.data.gamestateData.gameplayTime;


    }
    public override void Execute()
    {


        remainingTime -= Time.deltaTime;
    }
    public override void Exit()
    {



    }
}