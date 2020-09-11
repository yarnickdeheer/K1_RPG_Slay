using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Discuss: Does this interface NEED to also implement the IPickable and Ispawnable interfaces? Or can they be merged somehow?

public interface IMapEncounter: IPickable, ISpawnable
{
    int Difficulty { get; set; }
}
