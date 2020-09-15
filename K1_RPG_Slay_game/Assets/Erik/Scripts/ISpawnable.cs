using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The interface for items that are able to be spawned on the map
/// </summary>

public interface ISpawnable
{
    Vector2 ObjectPos { get; set; } 

    void EnableGameobject(Vector2 position);

    Vector2 GetPosition();

    void DisableGameobject();
}
