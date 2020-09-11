using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHandler
{
    private int _TurnId;
    private int _MovesLeft;
    private bool _TurnConfirmed;

    public void NextTurn()
    {
        throw new System.NotImplementedException();
        // if current attacking player is done with his turn swap to the enemy
        if (_TurnConfirmed == true)
        {
           // _TurnId = _turnIdNextCaracter;
        }
    }
    public void EndCombat()
    {
        throw new System.NotImplementedException();
        // if the player or the enemy is dead 
        // when the player is dead go to post battle display as loser 
        // when the enemy is dead go to post battle display as winner
    }
}
