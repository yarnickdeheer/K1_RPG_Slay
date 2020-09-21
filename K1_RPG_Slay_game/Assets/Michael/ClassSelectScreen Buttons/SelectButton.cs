using UnityEngine;
using System.Collections.Generic;

public class SelectButton
{
	private GameManager gm = GameManager.Instance;

	private int _actionIndex = 0;
	private List<System.Action> _allActions;

	private List<System.Action> _battleActions;
	private Dictionary<int, ClassSelectButton> _buttons;
	

	public Sprite _buttonSelected;
	public Sprite _buttonDeselected;
	public GameObject _button;

	public bool _battle = false;

	/*<summary>
	This script works on the startscreen scene.
	It gets input from inputmanager, and that way you can switch which button to press.
	It executes 'actions' if you press space when a certain button is selected.
	These actions are saved in _allActions.
	</summary>*/

	//constructor
	public SelectButton(Sprite buttonSelected, Sprite buttonDeselected, GameObject button , bool battle)
	{
		_buttonSelected = buttonSelected;
		_buttonDeselected = buttonDeselected;
		_button = button;
		_battle = battle;

		//instantiate the lists
		_allActions = new List<System.Action>();

		_battleActions = new List<System.Action>();
		_buttons = new Dictionary<int, ClassSelectButton>();

		//add the actions
		_allActions.Add(UseVitopButton);
		_allActions.Add(UseStronkButton);
		_allActions.Add(UseDexeusButton);
		_battleActions.Add(Attack);
		_battleActions.Add(MoveForward);
		_battleActions.Add(MoveBack);

		//make 3 new buttons
		CreateButton(0, -10.3f, -5f);
		CreateButton(1, -.3f, -5f);
		CreateButton(2, 9.6f, -5f);
	}

	//method to make a button
	private void CreateButton(int index, float xLocation, float yLocation)
	{ //create a button and add them in the buttons list
		_buttons[index] = new ClassSelectButton(_button, xLocation, yLocation);
	}

	//the input options
	public void SelectedActionRight()
	{ //when you press the right button it picks the next option in the list if possible
		OnDeselect();
		_actionIndex = Mathf.Min(_actionIndex + 1, _allActions.Count - 1);
		OnSelect();
	}

	public void SelectedActionLeft()
	{ //when you press the left button it picks the previous option in the list if possible
		OnDeselect();
		_actionIndex = Mathf.Max(_actionIndex - 1, 0);
		OnSelect();
	}

	public void Use()
	{ //invoke the current action
		if (_battle == true )
		{

			_battleActions[_actionIndex].Invoke();
		} 
		else
		{

			_allActions[_actionIndex].Invoke();
		}
		
	}

	//the actions in allActions
	private void UseVitopButton()
	{
		gm.ChooseClass(PlayerClass.VITOP);
		DestroyButtons();
		gm.SceneSwitch();
	}

	private void UseStronkButton()
	{
		gm.ChooseClass(PlayerClass.STRONK);
		DestroyButtons();
		gm.SceneSwitch();
	}

	private void UseDexeusButton()
	{
		gm.ChooseClass(PlayerClass.DEXEUS);
		DestroyButtons();
		gm.SceneSwitch();
	}

	private void Attack()
	{
		gm._combatHandler._choice = 1;
		gm._combatHandler.GetInput(1);
		//DestroyButtons();

	}

	private void MoveForward()
	{
		gm._combatHandler._choice = 2;
		gm._combatHandler.GetInput(2);
		//DestroyButtons();
	}

	private void MoveBack()
	{
		gm._combatHandler._choice = 3;
		gm._combatHandler.GetInput(3);
		//DestroyButtons();
	}

	//these methods handle the visual aspect of the buttons
	private void OnSelect()
	{
		if (_buttons[_actionIndex]._buttonSR != null)
		{
			_buttons[_actionIndex]._buttonSR.sprite = _buttonSelected;
		}
	}

	private void OnDeselect()
	{
		if (_buttons[_actionIndex]._buttonSR != null)
		{
			_buttons[_actionIndex]._buttonSR.sprite = _buttonDeselected;
		}
	}

	private void DestroyButtons()
	{
		for (int i = _buttons.Count; i == 0; i--)
		{
			Object.Destroy(_buttons[i]._go);
		}
	}
}