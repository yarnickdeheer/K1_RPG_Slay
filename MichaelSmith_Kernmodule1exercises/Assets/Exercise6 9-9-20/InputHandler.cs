using UnityEngine;

public class InputHandler
{
	private ICommand _XButtonPressed;
	private ICommand _YButtonPressed;

	public InputHandler(ICommand XButtonCommand, ICommand YButtonCommand)
	{
		_XButtonPressed = XButtonCommand;
		_YButtonPressed = YButtonCommand;
	}

	public ICommand HandleInput()
	{
		if (Input.GetKeyDown(KeyCode.X))
		{
			return _XButtonPressed;
		}
		if (Input.GetKeyDown(KeyCode.Y))
		{
			return _YButtonPressed;
		}
		return null;
	}
}