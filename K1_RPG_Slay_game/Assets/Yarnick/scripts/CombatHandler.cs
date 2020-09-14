using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHandler : ICombatHandler
{
    private int _MovesLeft;
    private bool _TurnConfirmed;
    public bool _playerturn { get; set; }

    public void StartTurn(){
        // we need to know speed of player and enemy to see who attacks first
      ///  if (Player.MovePoints > Enemy.Moveponts)
     ///   {
      ///      _playerturn = true;
      ///      NextTurn();
     ///   }
    ///    else
    ///    {
    ///        _playerturn = false;
     ///       NextTurn();
     ///   }
    }
    public void NextTurn()
    {
        if (_playerturn == true)
        {
            // set combat display aan 
            _playerturn = false;
            NextTurn();
			
        }
        else
        {
            // Enemy AI start turn
            _playerturn = true;
            NextTurn();
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
