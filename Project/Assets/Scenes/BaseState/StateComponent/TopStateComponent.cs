using System;
using UnityEngine;

public class TopStateComponent : StateComponentBase
{
    [SerializeField] private GameObject topCanvasGrop;
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
        topCanvasGrop.SetActive(true);
    }

    public void OnUpdate()
    {

    }

    private void ChangeMapState()
    {
        this.onUpdateState?.Invoke();
    }


    public void OnExit()
    {
    }
}