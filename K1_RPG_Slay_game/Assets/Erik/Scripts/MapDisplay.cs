using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay
{
    //DISCUSS: Should enemies have only 2 spawning positions? Or should the enemy spawning be expanded more?

    private Vector2 _firstEcounterPosition = new Vector2(-3.5f,0);
    private Vector2 _secondEcounterPosition = new Vector2(3.5f, 0);

    private Vector2 _playerPosition = new Vector2(0, -3.5f);

    private GameObject _playerObj;

    private int _amountOfEnemiesInPool = 5;

    //DISCUSS: Should enemies on the map be spawned from an object pool? Otherwise remove experimental code.
    
    /*private List<ISpawnable> _inactiveEnemyPool = new List<ISpawnable>();
    private List<ISpawnable> _activeEnemyPool = new List<ISpawnable>();
    

    public void CreateEnemyPool()
    {
        for(int i = 0; i < _amountOfEnemiesInPool; i++)
        {
            _inactiveEnemyPool.Add(new LightEnemyEncounter());
        }

        for (int i = 0; i < _amountOfEnemiesInPool; i++)
        {
            _inactiveEnemyPool.Add(new HeavyEnemyEncounter());
        }
    }*/

    public void PlacePlayer()
    {
        //DISCUSS: Will this be the way we instantiate the gameobjects? Or should we instantiate everything once and reuse it every time we get back to the map?
        _playerObj = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/PlayerPrefab"));

        _playerObj.transform.position = _playerPosition;
    }

    /*public void PlaceEnemies()
    {
        int random_1 = Random.Range(0, _inactiveEnemyPool.Count - 1);
        PlaceEnemy(random_1, _firstEcounterPosition);

        int random_2 = Random.Range(0, _inactiveEnemyPool.Count - 1);
        PlaceEnemy(random_2, _secondEcounterPosition);
    }

    private void PlaceEnemy(int listID, Vector2 position)
    {
        _activeEnemyPool.Add(_inactiveEnemyPool[listID]);
        _inactiveEnemyPool[listID].EnableGameobject(position);
        _inactiveEnemyPool.RemoveAt(listID);
    }*/

    public void SpawnEnemies(List<IMapEncounter> enemies)
    {
        enemies[0].EnableGameobject(_firstEcounterPosition);
        enemies[1].EnableGameobject(_secondEcounterPosition);
    }
}
