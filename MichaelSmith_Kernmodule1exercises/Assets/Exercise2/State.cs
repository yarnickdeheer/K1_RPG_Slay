public abstract class State
{
	public State(StateMachine owner)
	{
		this.owner = owner;
	}
	protected StateMachine owner;
	public abstract void OnEnter();
	public abstract void OnExit();
	public abstract void OnStart();
}