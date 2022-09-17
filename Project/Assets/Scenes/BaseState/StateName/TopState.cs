public class TopState : IAppState
{
    private ChangeOfStateMachine stateMachine;
    private TopStateComponent topStateComponent;

    public TopState(ChangeOfStateMachine stateMachine, TopStateComponent topStateComponent)
    {
        this.stateMachine = stateMachine;
        this.topStateComponent = topStateComponent;
    }

    public void OnEnter()
    {
        this.topStateComponent.Init(() => this.stateMachine.ChangeState(StateName.MAP));
        this.topStateComponent.OnEnter();

    }

    public void OnUpdate()
    {
        this.topStateComponent.OnUpdate();
    }

    public void OnExit()
    {
        this.topStateComponent.OnExit();
        this.topStateComponent.DisposeAction(null);
    }
}