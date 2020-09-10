using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnable
{
    void EnableGameobject(Vector2 position);

    void DisableGameobject();
}
