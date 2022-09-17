using System;
using UnityEngine;

public abstract class StateComponentBase : MonoBehaviour
{
    protected Action onUpdateState;


    public abstract void Init(Action onUpdateState);

    public abstract void DisposeAction(Action onUpdateState);
}
