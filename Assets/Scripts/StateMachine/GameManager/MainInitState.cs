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

        for (int index = 0; index < gameManager.data.objectData.garbages.Length; index++)
        {
            ObjectManager.instance.CreateGarbage(index, gameManager.data.gamestateData.createGarbageCount);
        }


    }

    public override void Execute()
    {
        
    }

    public override void Exit()
    {
       
    }
}