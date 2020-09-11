using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface for pickable selections. For example: Enemies on the map, Reward choices and combat options

public interface IPickable
{
    void OnSelect();
    void OnDeselect();
    void PickSelection();
}
