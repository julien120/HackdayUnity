using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class DetactClick : MonoBehaviour
{
    //[SerializeField] private Button button;
    private IObservable<Unit> mouseDown;

    private void Start()
    {
        
    }

    public void ClickPinMaker(Button button,Action OnOpenModalWindow)
    {
        Debug.Log("juliボタン押された");
        if (!button) return;
        mouseDown = button.onClick.AsObservable();

        mouseDown
            .Buffer(mouseDown.Throttle(TimeSpan.FromMilliseconds(500)))
            .Where(x => x.Count == 2)
            .Subscribe(_ =>
            {
                OnOpenModalWindow?.Invoke();
                return;
            });

        mouseDown
            .Buffer(mouseDown.Throttle(TimeSpan.FromMilliseconds(500)))
            .Where(x => x.Count == 1)
            .Subscribe(_ =>
            {
                Debug.Log("クリックされました");
                return;
            });
    }
}
