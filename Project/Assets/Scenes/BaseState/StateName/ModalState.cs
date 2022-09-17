public class ModalState : IAppState
{
    private ChangeOfStateMachine stateMachine;
    private ModalStateComponent modalStateComponent;

    public ModalState(ChangeOfStateMachine stateMachine, ModalStateComponent modalStateComponent)
    {
        this.stateMachine = stateMachine;
        this.modalStateComponent = modalStateComponent;
    }

    public void OnEnter()
    {
        this.modalStateComponent.Init(() => this.stateMachine.ChangeState(StateName.MODAL));
    }

    public void OnUpdate()
    {
        this.modalStateComponent.OnUpdate();
    }

    public void OnExit()
    {
        this.modalStateComponent.OnExit();
        this.modalStateComponent.DisposeAction(null);
    }
}