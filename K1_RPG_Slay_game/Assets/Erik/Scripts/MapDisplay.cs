using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay
{
    private float _spacing = 3.5f;

    private Vector2 _firstEcounterPosition = new Vector2(-3.5f,0);
    private Vector2 _secondEcounterPosition = new Vector2(3.5f, 0);

    private Vector2 _playerPosition = new Vector2(0, -3.5f);

    private GameObject _playerObj;
    private Camera mainCam;

    public MapDisplay()
    {
        mainCam = Camera.main;
    }

    public void PlacePlayer()
    {
        _playerObj = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/PlayerPrefab"));

        MovePlayer(_playerPosition);
    }

    //The player will be placed on the position of the last defeated enemy.
    public void MovePlayer(Vector2 pos)
    {
        _playerObj.transform.position = pos;
        mainCam.transform.position = new Vector3(pos.x, (pos.y + _spacing), -10);
        _playerPosition = pos;
    }

    public void SpawnEnemies(List<IMapEncounter> enemies)
    {
        CalculateNewEnemyPositions();

        enemies[0].EnableGameobject(_firstEcounterPosition);
        enemies[1].EnableGameobject(_secondEcounterPosition);

        enemies[0].OnDeselect();
        enemies[1].OnDeselect();
    }

    private void CalculateNewEnemyPositions()
    {
        _firstEcounterPosition = new Vector2((_playerPosition.x - _spacing), (_playerPosition.y + _spacing));
        _secondEcounterPosition = new Vector2((_playerPosition.x + _spacing), (_playerPosition.y + _spacing));
    }
}
