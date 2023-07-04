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
    #endregion

    #region state
    private StateMachine stateMachine;
    public MainInitState mainInitState { get; private set; }
    public RunTimeState runTimeState { get; private set; }
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