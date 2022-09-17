public class MapState : IAppState
{
    private ChangeOfStateMachine stateMachine;
    private MapStateComponent mapStateComponent;

    public MapState(ChangeOfStateMachine stateMachine, MapStateComponent mapStateComponent)
    {
        this.stateMachine = stateMachine;
        this.mapStateComponent = mapStateComponent;
    }

    public void OnEnter()
    {
        this.mapStateComponent.Init(() => this.stateMachine.ChangeState(StateName.MODAL));
        this.mapStateComponent.OnEnter();
    }

    public void OnUpdate()
    {
        this.mapStateComponent.OnUpdate();
    }

    public void OnExit()
    {
        this.mapStateComponent.OnExit();
        this.mapStateComponent.DisposeAction(null);
    }
}