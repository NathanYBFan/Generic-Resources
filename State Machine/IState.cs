///<summary>
/// Author: Nathan Fan
/// Description: Base state interface
///</summary>
public interface IState
{
    public void Enter();
    public void Exit();
    public void HandleInput();
    public void Update();
    public void FixedUpdate();
}
