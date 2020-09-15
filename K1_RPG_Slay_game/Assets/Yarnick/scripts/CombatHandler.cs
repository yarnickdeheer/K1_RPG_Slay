using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHandler : IcombatHandler
{
    private int _MovesLeft;
    private bool _TurnConfirmed;
    public bool PlayerTurn { get; set; }
    public GameManager _gameManager;
    //public enemy _currentEnemy;
    public void StartTurn()
    {
        // we need to know speed of player and enemy to see who attacks first
        
        if (_gameManager.player.MovePoints > _gameManager.Currentenemy.MovePoints)
        {
            PlayerTurn = true;
            NextTurn();
        }
        else
        {
            PlayerTurn = false;
            NextTurn();
        }
    }
    public void NextTurn()
    {
        if (PlayerTurn == true)
        {
            // set combat display aan 
            PlayerTurn = false;
            NextTurn();

        }
        else
        {
            // Enemy AI start turn
            PlayerTurn = true;
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
