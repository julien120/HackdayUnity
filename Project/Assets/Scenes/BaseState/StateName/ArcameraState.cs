public class ArcameraState : IAppState
{
    private ChangeOfStateMachine stateMachine;
    private ArcameraStateComponent arcameraStateComponent;

    public ArcameraState(ChangeOfStateMachine stateMachine, ArcameraStateComponent arcameraStateComponent)
    {
        this.stateMachine = stateMachine;
        this.arcameraStateComponent = arcameraStateComponent;
    }

    public void OnEnter()
    {
        this.arcameraStateComponent.Init(() => this.stateMachine.ChangeState(StateName.MAP));
    }

    public void OnUpdate()
    {
        this.arcameraStateComponent.OnUpdate();
    }

    public void OnExit()
    {
        this.arcameraStateComponent.OnExit();
        this.arcameraStateComponent.DisposeAction(null);
    }
}