using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EndingState : State
{
    private GameManager gameManager;

    public EndingState(StateMachine stateMachine, GameManager gameManager) : base(stateMachine)
    {
        this.gameManager = gameManager;
    }

    public override void Check()
    {
       
    }

    public override void Enter()
    {
        gameManager.state = GameManager.State.Ending;

        gameManager.SetSpawner(false);

        ObjectManager.instance.AllUnactivate();

        UIManager.instance.SetTitlePanelUI(true, gameManager.data.uiData.endingText, gameManager.data.uiData.retryText);



    }

    public override void Execute()
    {
     
        


    }

    public override void Exit()
    {
        UIManager.instance.SetTitlePanelUI(false);
    }
}
