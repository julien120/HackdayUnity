using System;
using UnityEngine;
using UnityEngine.UI;

public class ModalStateComponent : StateComponentBase
{
    [Header("ポップアップ配下Button")]
    [SerializeField] private Button toModalFromCheckButton;
    [SerializeField] private Button toCheckFromModalButton;
    [SerializeField] private Button toMapStateFromModalCloseButton;

    [Header("ModalWindow")]
    [SerializeField] private GameObject checkinGroupObject;
    [SerializeField] private GameObject modalGroupObject;
    public event Action OnChangeMapState;

    public override void Init(Action onUpdateState)
    {
        this.onUpdateState = onUpdateState;
    }

    public override void DisposeAction(Action onUpdateState)
    {
        this.onUpdateState = onUpdateState;
        this.OnChangeMapState = onUpdateState;
    }

    public void OnEnter()
    {
        InitAddLisner();
        modalGroupObject.SetActive(true);
        Debug.Log("modalのsetActive");
    }

    public void OnUpdate()
    {
    }

    public void OnExit()
    {
        checkinGroupObject.SetActive(false);
        modalGroupObject.SetActive(false);
    }

    private void InitAddLisner()
    {
        toModalFromCheckButton.onClick.AddListener(() => ClosedCheckInWindow());
        toCheckFromModalButton.onClick.AddListener(() => OpenCheckInWindow());
        toMapStateFromModalCloseButton.onClick.AddListener(() => this.OnChangeMapState?.Invoke());
    }

    private void ClosedCheckInWindow()
    {
        checkinGroupObject.SetActive(false);
        modalGroupObject.SetActive(true);
    }

    private void OpenCheckInWindow()
    {
        checkinGroupObject.SetActive(true);
        modalGroupObject.SetActive(false);
    }

    private void ChangeARCameraState()
    {
        this.onUpdateState?.Invoke();
    }

    public void ChangeMapState(Action onUpdateState)
    {
        OnChangeMapState = onUpdateState;
    }
}