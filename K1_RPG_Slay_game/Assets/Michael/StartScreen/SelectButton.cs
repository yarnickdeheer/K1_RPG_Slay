using UnityEngine;
using System.Collections.Generic;

public class SelectButton
{
	Sprite _buttonSelected;
	Sprite _buttonDeselected;
	List <GameObject> _buttons;

	public void OnSelect()
	{
		_buttons[]._buttonSR = _buttonSelected;
	}

	public void OnDeselect()
	{
		_buttons[].sprite = _buttonDeselected;
	}

	protected void OnCreateButton(GameObject button)
	{
		_buttons[].Add = button;
		_buttonSelected = Resources.Load<Sprite>("Sprites/PlayerSelect");
		_buttonDeselected = Resources.Load<Sprite>("Sprites/PlayerDeselect");
	}
}