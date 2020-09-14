using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingMonobehavior : MonoBehaviour
{
    //DISCUSS: How will we handle the input? (This MonoBehaviour is temporary for testing)

    MapDisplay map = new MapDisplay();
    EncounterManager enc = new EncounterManager();

    private int _selection = 3;

    // Start is called before the first frame update
    void Start()
    {
        enc.CreateNextFloor();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _selection = 0;
            enc.SelectEncounter(_selection);
            enc.DeselectEncounter(1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _selection = 1;
            enc.SelectEncounter(_selection);
            enc.DeselectEncounter(0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _selection != 3)
        {
            enc.ConfirmSelection(_selection);
        }
    }
}
