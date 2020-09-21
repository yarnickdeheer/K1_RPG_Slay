using UnityEngine;

public class InputManager
{
	//there are 3 different buttons in our game, so we define those here
	public event System.Action OnLeftButtonPressed;
	public event System.Action OnRightButtonPressed;
	public event System.Action OnSelectButtonPressed;

	//Checks the inputs and calls methods based upon the inputs. For now, depending on the scene the script has different functionality.
	public void UpdateInputs()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			OnLeftButtonPressed?.Invoke();
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			OnRightButtonPressed?.Invoke();
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			OnSelectButtonPressed?.Invoke();
		}
		else
		{
			return;
		}
	}
}