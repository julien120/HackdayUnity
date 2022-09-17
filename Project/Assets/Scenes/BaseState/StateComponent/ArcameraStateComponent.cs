using System;

public class ArcameraStateComponent : StateComponentBase
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