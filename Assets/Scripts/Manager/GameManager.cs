using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    
    public enum State
    {
        MainInit,
        RunTime,
        Ending
    }

    #region data
    [field: Header("Data")]
    [field: SerializeField] public RuntimeDataSO data { get; private set; }
    [field: SerializeField] public State state { get; set; }
    [field: SerializeField] public int[] score { get; private set; }


  
    [field: Header("Object")]
    [SerializeField] private Planet[] planets;
    [SerializeField] private Spawner spawner;
    #endregion

    #region state
    private StateMachine stateMachine;
    public MainInitState mainInitState { get; private set; }
    public RunTimeState runTimeState { get; private set; }
    public EndingState endingState { get; private set; }
    #endregion


    #region public
    public void OnGameStartButton()
    {
        stateMachine?.ChangeState(runTimeState);
    }
    public void InitializePlanet()
    {
        for (int i = 0; i < planets.Length; i++)
        {
            planets[i].Initialize(data.planetData.maxHealth);
        }
    }
    public void IncreaseScore(int index, int add)
    {
        score[index] += add;
    }
    public void GenerateScore()
    {
        for (int i = 0; i < score.Length; i++)
        {
            score[i] = 0;
        }
    }

    public void SetSpawner(bool value)
    {
        spawner.gameObject.SetActive(value);
    }
    #endregion


    #region private
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);

            return;
        }

        instance = this;

        stateMachine = new StateMachine();

        mainInitState = new MainInitState(stateMachine, instance);

        runTimeState = new RunTimeState(stateMachine, instance);

        endingState = new EndingState(stateMachine, instance);
    }
    private void Start()
    {
        stateMachine?.ChangeState(mainInitState);
    }
    private void Update()
    {
        stateMachine?.Execute();
    }
    #endregion
}