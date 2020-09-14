using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager
{
    //TODO: Check code conventions

    public int FloorNumber { get; set; }
    private int _maxEncounterOptions = 2;

    private MapDisplay _encounterMap = new MapDisplay();

    private List<IMapEncounter> _possibleEncounters = new List<IMapEncounter>();

    public void CreateNextFloor()
    {
        //which encounters? and how many encounters?
        for(int i = 0; i < _maxEncounterOptions; i++)
        {
            int randomizer = Random.Range(0, _maxEncounterOptions);

            if (randomizer == 0)
            {
                _possibleEncounters.Add(new LightEnemyEncounter());
            }
            else
            {
                _possibleEncounters.Add(new HeavyEnemyEncounter());
            }
        }

        _encounterMap.PlacePlayer();
        _encounterMap.SpawnEnemies(_possibleEncounters);
    }

    public void SelectEncounter(int id)
    {
        _possibleEncounters[id].OnSelect();
    }

    public void DeselectEncounter(int id)
    {
        _possibleEncounters[id].OnDeselect();
    }

    public void ConfirmSelection(int id)
    {
        _possibleEncounters[id].PickSelection();
    }
}
