using UnityEngine;

public class InputManager
{
	//there are 3 different buttons in our game, so we define those here
    public event System.Action OnLeftButtonPressed;
    public event System.Action OnRightButtonPressed;
    public event System.Action OnSelectButtonPressed;

	//encountermanager logic
    private EncounterManager _em;
    private int _selection = 3;

    public void AddEm()
	{
        _em = GameManager.Instance._em;
    }

	//Checks the inputs and calls methods based upon the inputs. For now, depending on the scene the script has different functionality.
	//TODO: Make encountermap(_em) input like startscreen input, if you need reference check SelectButton and ClassSelectButton.
	public void UpdateInputs(int scene)
	{
		if (scene == 0 || scene == 2 || scene == 3)
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
		}
        if (scene == 1)
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				_em.SelectEncounter(_selection);
				_em.DeselectEncounter(1);
			}
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				_em.SelectEncounter(_selection);
				_em.DeselectEncounter(0);
			}
			if (Input.GetKeyDown(KeyCode.Space))
			{
				_em.ConfirmSelection(_selection);
			}
		}
		else
		{
			return;
		}
    }
}
