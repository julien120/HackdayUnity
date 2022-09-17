using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAppState
{
    void OnEnter();
    void OnUpdate();
    void OnExit();
}
