using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IColletable
{
    //int Weight { get; set; }
    int Rarity { get; set; }
    int ItemId { get; set; }
    void CollectItem();
}
