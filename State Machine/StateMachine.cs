///<summary>
/// Author: Nathan Fan
/// Description: Base state machine script
///</summary>
public abstract class StateMachine
{
    protected IState currentState;
    public void ChangeState(IState newState)
    {
        currentState?.Exit();

        currentState = newState;

        currentState.Enter();
    }
    public void HandleInput()
    {
        currentState?.HandleInput();
    }

    public void Update()
    {
        currentState?.Update();
    }

    public void FixedUpdate()
    {
        currentState?.FixedUpdate();
    }

    public IState GetCurrentState()
    {
        return currentState;
    }
}
