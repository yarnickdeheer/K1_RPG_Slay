using UnityEngine;

public class InputManager
{
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
            _selection -= 1;
            _em.SelectEncounter(_selection);
            _em.DeselectEncounter(1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && _selection <= maxOptions)
        {
            _selection += 1;
            _em.SelectEncounter(_selection);
            _em.DeselectEncounter(0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _selection != 3)
        {
            _em.ConfirmSelection(_selection);
            _selection = 3;
        }
    }
}
