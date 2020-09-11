using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemyEncounter : IMapEncounter, ISpawnable
{
    //Discuss: Most likely would be better to use inheritance for enemy encounter types since a lot of functions are (alsmost) the same.

    //TODO: Double check code conventions.
    
    public int Difficulty { get; set; }
    private GameObject _enemyMapObject;

    public HeavyEnemyEncounter()
    {
        OnEnemyCreate();
    }

    public void OnSelect()
    {
        //TODO: Selection of encounter
        Debug.Log("SELECTING HEAVY ENEMY");
    }

    public void OnDeselect()
    {
        //TODO: Selection of encounter
        Debug.Log("Deselecting HEAVY ENEMY");
    }

    public void PickSelection()
    {
        //TODO: Confirmation Selection of encounter
        Debug.Log("PICKING HEAVY ENEMY FOR FIGHT");
    }

    private void OnEnemyCreate()
    {
        _enemyMapObject = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/HeavyEnemyPrefab"));
        DisableGameobject();
    }

    public void EnableGameobject(Vector2 position)
    {
        _enemyMapObject.SetActive(true);
        _enemyMapObject.transform.position = position;
    }

    public void DisableGameobject()
    {
        _enemyMapObject.SetActive(false);
    }
}
