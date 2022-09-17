using System;
using UnityEngine;
using UnityEngine.UI;
using Scene.MapBox;


public class MapStateComponent : StateComponentBase
{
    [SerializeField] private Button pinButton;
    [SerializeField] private ApplyLocationMap applyLocationMap;

    [SerializeField] private GameObject mapGroupObject;
    [SerializeField] private Button komariButton;
    [SerializeField] private DetactClick detactClick;


    public override void Init(Action onUpdateState)
    {
        this.onUpdateState = onUpdateState;
    }

    public override void DisposeAction(Action onUpdateState)
    {
        this.onUpdateState = onUpdateState;
    }

    /// <summary>
    /// 1.現在地取得
    /// 2.現在地のマップを表示
    /// 3.現在地周辺の困りごとピンを描画する
    /// </summary>
    public void OnEnter()
    {
        InitAddLisner();
        applyLocationMap.CalcCurrentLocation();
        Debug.Log("MapStateOnEnter");
        
    }

    public void OnUpdate()
    {
    }

    public void OnExit()
    {
        Debug.Log("MapStateOnExit");
        detactClick.ClickPinMaker(null, null);
    }

    private void ChangeInGameState()
    {
        this.onUpdateState?.Invoke();
    }

    private void InitAddLisner()
    {
        Debug.Log("MapStateAddlistner");
        detactClick.ClickPinMaker(pinButton,ChangeInGameState);
        //TODO:困りごとボタン
        //komariButton.onClick.AddListener(() => );
        mapGroupObject.SetActive(true);
    }

    private void Start()
    {
        Debug.Log("start");
        
    }
}