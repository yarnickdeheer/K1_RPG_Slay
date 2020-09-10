using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnemyEncounter : IMapEncounter, ISpawnable
{
    //Discuss: Most likely would be better to use inheritance for enemy encounter types since a lot of functions are (alsmost) the same.

    //TODO: Double check code conventions.

    public int Difficulty { get; set; }
    private GameObject enemyMapObject;

    public LightEnemyEncounter()
    {
        OnEnemyCreate();
    }

    public void OnSelect()
    {
        //TODO: Selection of encounter
        Debug.Log("SELECTING LIGHT ENEMY");
    }

    public void OnDeselect()
    {
        Debug.Log("Deselecting LIGHT ENEMY");
    }

    public void PickSelection()
    {
        //TODO: Confirmation Selection of encounter
        Debug.Log("PICKING LIGHT ENEMY FOR FIGHT");
    }

    private void OnEnemyCreate()
    {
        enemyMapObject = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/LightEnemyPrefab"));
        DisableGameobject();
    }

    public void EnableGameobject(Vector2 position)
    {
        enemyMapObject.SetActive(true);
        enemyMapObject.transform.position = position;
    }

    public void DisableGameobject()
    {
        enemyMapObject.SetActive(false);
    }
}
