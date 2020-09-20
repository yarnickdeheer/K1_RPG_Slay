using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemyEncounter : EnemyEncounter, IMapEncounter, ISpawnable
{
    //DISCUSS: Can this be done better? Does the code from EnemyEncounter need to be moved to this class instead? And are these overrides even needed here?

    public HeavyEnemyEncounter()
    {
        OnEnemyCreate(EnemyType.HEAVY_ENEMY);
        base.SetDifficulty(2);
    }

    public override int GetDifficulty()
    {
        return base.GetDifficulty();
    }

    public override void OnSelect()
    {
        base.OnSelect();
    }

    public override void OnDeselect()
    {
        base.OnDeselect();
    }

    public override void PickSelection()
    {
        base.PickSelection();
    }

    public override void OnEnemyCreate(EnemyType enemyType)
    {
        base.OnEnemyCreate(enemyType);
    }

    public override void EnableGameobject(Vector2 position)
    {
        base.EnableGameobject(position);
    }

    public override void DisableGameobject()
    {
        base.DisableGameobject();
    }
}
