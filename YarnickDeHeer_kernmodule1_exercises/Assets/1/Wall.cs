using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : IDamageable
{
    public int Health {get; set;}
    public void TakeDamage(int damage)
    {
        throw new System.NotImplementedException();
    }
}
