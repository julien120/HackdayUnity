using System;
using UnityEngine;

public class TopStateComponent : StateComponentBase
{
    public override void Init(Action onUpdateState)
    {
        this.onUpdateState = onUpdateState;
    }

    public override void DisposeAction(Action onUpdateState)
    {
        this.onUpdateState = onUpdateState;
    }

    public void OnEnter()
    {
        ChangeInGameState();
        Debug.Log("OnEnter");
    }

    public void OnUpdate()
    {

    }

    private void ChangeInGameState()
    {
        this.onUpdateState?.Invoke();
    }


    public void OnExit()
    {
    }
}