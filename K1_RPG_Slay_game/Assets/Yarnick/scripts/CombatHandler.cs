using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHandler : IcombatHandler
{
    private int _MovesLeft;
    private bool _TurnConfirmed;
    public bool PlayerTurn { get; set; }
    public GameManager _gameManager = GameManager.Instance;
    public IWeapon Weapon { get; set; }

    private int _playerPos = 1;
    private int _enemyPos = 6;
    private int _distance;
    public int _choice;
    //public enemy _currentEnemy;
    public void StartTurn()
    {
        // we need to know speed of player and enemy to see who attacks first

        if (_gameManager._player.MovePoints > _gameManager._player.MovePoints)
        {
            _distance = _enemyPos - _playerPos;
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
        _distance = _enemyPos - _playerPos;
        if (PlayerTurn == true)
        {

            Battle(_playerPos,_enemyPos,_distance,_choice);

            // set combat display aan 
            PlayerTurn = false;
            NextTurn();

        }
        else
        {
            // Enemy AI start turn
            
            Battle(_playerPos,_enemyPos, _distance,_choice);
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


    public void Battle( int fighter1 , int fighter2 , int Dis, int Choice){

       
        if (Choice == 1){ //(attack)
             if( Weapon.Range <= Dis)
            {
               //  Attack();
             }
             else{
               //  miss();
             }
        }
        else if(Choice == 2){ //(vooruit)
             if(Dis!= 1){
                 fighter1++;
             }
             else{
                 Debug.Log("fighter1 staat voor de fighter2");
                 return;
            }
        }
           else if(Choice == 3){ //(achteruit)
            if(Dis < 10){
                 fighter1--;
             }
             else{
                 Debug.Log("fighter1 staat zo ver achteruit als hij kan");
                return;
             }
        }

    }
    public void Attack(ICombatant fighter1, ICombatant fighter2)
    {
        if (fighter1 == _gameManager._player)
        {

            fighter2.Health -= Mathf.RoundToInt( Weapon.BaseDamage + (1 * fighter1.Str * Weapon.StrScaling) + (1 * fighter1.Dex * Weapon.DexScaling));
        }
        else
        {
            fighter2.Health -= Mathf.RoundToInt((1 * fighter1.Str) + (1 * fighter1.Dex));

        }

    }

}
