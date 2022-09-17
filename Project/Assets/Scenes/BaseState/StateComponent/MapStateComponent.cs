using System;

public class MapStateComponent : StateComponentBase
{
    public override void Init(Action onUpdateState)
    {
        this.onUpdateState = onUpdateState;
    }

    public override void DisposeAction(Action onUpdateState)
    {
        this.onUpdateState = onUpdateState;
    }

    public void OnUpdate()
    {
    }

    public void OnExit()
    {
    }
}