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
            gameManager.CheckScoreWinner();

            stateMachine.ChangeState(gameManager.endingState);

            return;
        }

        if (gameManager.planets[0].health <= 0f || gameManager.planets[1].health <= 0f)
        {
            if (gameManager.planets[0].health > gameManager.planets[1].health)
            {
                gameManager.result = GameManager.Result.Planet_A;
            }
            else if (gameManager.planets[0].health == gameManager.planets[1].health)
            {
                gameManager.result = GameManager.Result.Draw;
            }
            else
            {
                gameManager.result = GameManager.Result.Planet_B;
            }

            stateMachine.ChangeState(gameManager.endingState);

            return;
        }
    }
    public override void Enter()
    {
        gameManager.state = GameManager.State.RunTime;

        gameManager.result = GameManager.Result.Draw;

        gameManager.spawner.gameObject.SetActive(true);

        gameManager.GenerateScore();

        gameManager.InitializePlanet();

        remainingTime = gameManager.data.gamestateData.gameplayTime;

        UIManager.instance.SetTimerUI(true, remainingTime / gameManager.data.gamestateData.gameplayTime, (int)remainingTime);

        for(int i = 0; i < gameManager.planets.Length; i++)
        {
            gameManager.planets[0].health = gameManager.data.planetData.maxHealth;

            UIManager.instance.SetHealthBarUI(true, i, gameManager.planets[i].health, gameManager.data.planetData.maxHealth);

            UIManager.instance.SetScoreTextUI(true, i, 0);
        }

    }
    public override void Execute()
    {
        UIManager.instance.SetTimerUI(true, remainingTime / gameManager.data.gamestateData.gameplayTime, (int)remainingTime);

        remainingTime -= Time.deltaTime;
    }
    public override void Exit()
    {
        gameManager.spawner.gameObject.SetActive(false);

        UIManager.instance.SetHealthBarUI(false);

        UIManager.instance.SetTimerUI(false);
    }
}