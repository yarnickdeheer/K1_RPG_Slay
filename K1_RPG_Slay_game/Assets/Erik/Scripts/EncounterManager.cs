using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EncounterManager
{
    public int FloorNumber { get; set; }
    private int _maxEncounterOptions = 2; //The amount of enemies to choose from. If we want more of them, we probably have to change more code. Default is 2

    private MapDisplay _encounterMap;

    private Vector2 _lastEnemyLocation = new Vector2(0,-3.5f);

    private int _amountOfEnemiesInPool = 5; //The amount of each enemy type we will have ready in our enemy pool

    private List<IMapEncounter> _inactiveLightEnemyPool = new List<IMapEncounter>();
    private List<IMapEncounter> _inactiveHeavyEnemyPool = new List<IMapEncounter>();

    private List<IMapEncounter> _activeEnemyPool = new List<IMapEncounter>();

    private List<System.Action> _allActions;
    private int _actionIndex = 0;

    //The enemy pools need to be made when the class is created.
    public EncounterManager()
    {
        CreateEnemyPools();
        SpawnPlayer();
        CreateNextFloor();

        //instantiate _allActions
        _allActions = new List<System.Action>();

        //KEEP BOTH: it's the same method added twice, but based on the _actionIndex it behaves differently. If there's only one _actionIndex can't be higher than one.
        _allActions.Add(ConfirmSelection);
        _allActions.Add(ConfirmSelection);
    }

    public void SpawnPlayer()
    {
        _encounterMap = new MapDisplay();
        _encounterMap.PlacePlayer(); //Communicate with the MapDisplay class to spawn the player.a
    }

    private void CreateEnemyPools()
    {
        for(int i = 0; i < _amountOfEnemiesInPool; i++)
        {
            _inactiveLightEnemyPool.Add(new LightEnemyEncounter());
            _inactiveHeavyEnemyPool.Add(new HeavyEnemyEncounter());
        }
    }

    /// <summary>
    /// To create a floor we still need to clear the enemies that did not get picked and return them to the inactive enemy pool.
    /// After we pick 2 random enemies from a random type.
    /// After we picked our enemies we can spawn the player and the death indicator of the last enemy
    /// Finally we spawn the new enemies on the map.
    /// </summary>
    public void CreateNextFloor()
    {
        ClearLeftOverEncounters();

        for (int i = 0; i < _maxEncounterOptions; i++)
        {
            int randomizer = Random.Range(0, _maxEncounterOptions);

            if (randomizer == 0)
            {
                _activeEnemyPool.Add(_inactiveLightEnemyPool[0]);
                _inactiveLightEnemyPool.RemoveAt(0);
            }
            else
            {
                _activeEnemyPool.Add(_inactiveHeavyEnemyPool[0]);
                _inactiveHeavyEnemyPool.RemoveAt(0);
            }
        }

        CreateKilledEnemy(_lastEnemyLocation);
        _encounterMap.MovePlayer(_lastEnemyLocation);
        _encounterMap.SpawnEnemies(_activeEnemyPool);
    }

    private void CreateKilledEnemy(Vector2 position)
    {
        GameObject _killedMapObject = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/KilledEnemyPrefab"));
        _killedMapObject.transform.position = position;
    }

    public void ClearLeftOverEncounters()
    {
        foreach(IMapEncounter item in _activeEnemyPool)
        {
            item.DisableGameobject();
            if(item.GetDifficulty() == 1)
            {
                _inactiveLightEnemyPool.Add(item);
            }
            else
            {
                _inactiveHeavyEnemyPool.Add(item);
            }
        }
        _activeEnemyPool.Clear();
    }

    public void SelectedEncounterRight()
    { //select the right encounter and also update the visuals
        _activeEnemyPool[_actionIndex].OnDeselect();
        _actionIndex = Mathf.Min(_actionIndex + 1, _allActions.Count - 1);
        _activeEnemyPool[_actionIndex].OnSelect();
    }
    public void SelectedEncounterLeft()
    { //select the left encounter and also update the visuals
        _activeEnemyPool[_actionIndex].OnDeselect();
        _actionIndex = Mathf.Max(_actionIndex - 1, 0);
        _activeEnemyPool[_actionIndex].OnSelect();
    }

    public void Use()
    { //invoke the current action
        _allActions[_actionIndex].Invoke();
    }

    public void ConfirmSelection()
    {
        _lastEnemyLocation = _activeEnemyPool[_actionIndex].GetPosition(); //If the player wins the next combat, the player's new position will be the position of the defeated enemy.

        /*TODO: Create implementation to the combat system instead of making a new floor
         * Options:
            1. The interface IPickable has a function called "PickSelection()". This function can be used for starting the combat system.
            2. This function already knows which enemy is picked. Simply use the information from the enemy to generate a new combat fight (with enemy difficulty)
        */

        _activeEnemyPool[_actionIndex].PickSelection(); //confirm selection of this enemy (currently empty)

        //The floor number and new floor generation can be called later when the combat is over.
        //CreateNextFloor();
        FloorNumber++;
    }
}
