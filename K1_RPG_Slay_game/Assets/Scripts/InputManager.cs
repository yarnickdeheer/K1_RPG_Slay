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
        if (Input.GetKeyDown(KeyCode.LeftArrow) && _selection != 0)
        {
            OnLeftButtonPressed?.Invoke();
            _selection -= 1;
            _em.SelectEncounter(_selection);
            _em.DeselectEncounter(1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && _selection <= maxOptions)
        {
            OnRightButtonPressed?.Invoke();
            _selection += 1;
            _em.SelectEncounter(_selection);
            _em.DeselectEncounter(0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _selection != 3)
        {
            OnSelectButtonPressed?.Invoke();
            _em.ConfirmSelection(_selection);
            _selection = 3;
        }
    }
}
