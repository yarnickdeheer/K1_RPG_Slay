using UnityEngine;

public class InputManager
{
	//there are 3 different inputs in our game, so we define those here
	public event System.Action OnLeftButtonPressed;
	public event System.Action OnRightButtonPressed;
	public event System.Action OnSelectButtonPressed;

	//Checks the inputs and calls methods (system.actions) based upon the inputs.
	public void UpdateInputs()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			//OnLeftButtonPressed?.Invoke();
			EventManager.RaiseEvent(EventType.ON_LEFT);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			//OnRightButtonPressed?.Invoke();
			EventManager.RaiseEvent(EventType.ON_RIGHT);
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//OnSelectButtonPressed?.Invoke();
			EventManager.RaiseEvent(EventType.ON_USE);
		}
		else
		{
			return;
		}
	}
}
