using UnityEngine;

public class InputManager
{
    public event System.Action OnLeftButtonPressed;
    public event System.Action OnRightButtonPressed;
    public event System.Action OnSelectButtonPressed;

    private EncounterManager _em;
    private int _selection = 3;

    public void AddEm()
	{
        _em = GameManager.Instance._em;
    }

    public void UpdateInputs(int maxOptions)
    {
        //TODO: Fix encountermap(_em) input, if you need reference check SelectButton and ClassSelectButton
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            OnLeftButtonPressed?.Invoke();
            //_em.SelectEncounter(_selection);
            //_em.DeselectEncounter(1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            OnRightButtonPressed?.Invoke();
            //_em.SelectEncounter(_selection);
            //_em.DeselectEncounter(0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSelectButtonPressed?.Invoke();
            //_em.ConfirmSelection(_selection);
        }
    }
}
