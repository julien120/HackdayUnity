using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ChangeOfStateMachine : MonoBehaviour
{
    private Dictionary<StateName, IAppState> stateNode;
    private IAppState current = null;

    [SerializeField]
    private TopStateComponent topStateComponent;
    [SerializeField]
    private MapStateComponent mapStateComponent;
    [SerializeField]
    private ModalStateComponent modalStateComponent;
    [SerializeField]
    private ArcameraStateComponent arcameraStateComponent;


    /// <summary>
    /// State切り替え時に前回のstateのOnExitを呼び出し、次のOnEnterを呼び出す
    /// </summary>
    /// <param name="type">引数に格納したStateに変遷する</param>
    public void ChangeState(StateName type)
    {
        this.current.OnExit();
        this.current = this.stateNode[type];
        Debug.Log("ChangeState呼び出し" + type);
        this.current.OnEnter();
    }

    /// <summary>
    /// 各Stateに対応する継承クラスと実装クラスを登録し、2番目をcurrentに登録する
    /// </summary>
    private void Start()
    {
        this.stateNode = new Dictionary<StateName, IAppState>()
            {
                { StateName.TOP, new TopState(this, this.topStateComponent) },
                { StateName.MAP, new MapState(this, this.mapStateComponent) },
                { StateName.MODAL, new ModalState(this, this.modalStateComponent) },
                { StateName.ARCAMERA, new ArcameraState(this, this.arcameraStateComponent) },
            };

        // TODO:MapStateを見るために
        this.current = this.stateNode.Values.ToList()[1];
        this.current.OnEnter();
        Debug.Log(this.current);
    }

    private void Update()
    {
       this.current.OnUpdate();
    }
}
