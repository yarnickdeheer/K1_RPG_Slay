using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ActorBase
{
    public override void Move()
    {
        Debug.Log("MOVING NORMAL ENEMY");
    }

    public override void Attack()
    {
        Debug.Log("ATTACK NORMAL ENEMY");
    }

    public override void TakeDamage()
    {
        Debug.Log("TAKE DAMAGE NORMAL ENEMY");
    }
}
