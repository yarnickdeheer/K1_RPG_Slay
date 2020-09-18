using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHandler : ICombatHandler
{
    private int _MovesLeft;
    private bool _TurnConfirmed;
    public bool PlayerTurn { get; set; }
    public GameManager _gameManager = GameManager.Instance;
    public IWeapon Weapon { get; set; }

    private int _playerPos = 1;
    private int _enemyPos = 6;
    private int _distance;
    public int _choice; // word later vervangen met de input van de speler
    //public enemy _currentEnemy;
    public void WhoStarts()
    {
        _distance = _enemyPos - _playerPos;
        if (_gameManager._player.MovePoints > _gameManager._player.MovePoints)
        {
            PlayerTurn = true;
        }
        else
        {
            PlayerTurn = false;
        }
    }


    public void GetInput()
    {
        NextTurn();
    }
    public void NextTurn()
    {
        _distance = _enemyPos - _playerPos;
        if (PlayerTurn == true)
        {
            // player start turn
            // display options aan
            // eerst moeten we de speler de tijd geven om een keuze te maken 
            Battle(_playerPos,_enemyPos,_distance,_choice);
            PlayerTurn = false;
        }
        else
        {
            // Enemy AI start turn
            // display options uit
            PlayerTurn = true;
            EnemyBehaviour(_gameManager._player);
           
        }


    }
    /// <summary>
    /// wanneer de speler of de AI geen health points meer heeft wordt deze functie aangeroepen die naar de post battle display gaat
    /// </summary>
    public void EndCombat()
    {
        throw new System.NotImplementedException();
        // if the player or the enemy is dead 
        // when the player is dead go to post battle display as loser 
        // when the enemy is dead go to post battle display as winner
    }


    /// <summary>
    /// de battle functie kijkt welke keuze de speler of de AI heeft gemaakt op basis daarvan gaat hij kijken of deze actie mogelijk is wanneer niet moet je je keuze opnieuw maken
    /// </summary>
    public void Battle( int fighter1 , int fighter2 , int Dis, int Choice)
    {


        if (Choice == 1)
        { //(attack)
            if (Weapon.Range <= Dis)
            {
                //  Attack();
            }
            else
            {
                //  miss();
                // retake choice
            }
        }
        else if (Choice == 2)
        { //(vooruit)
            if (Dis != 1)
            {
                fighter1++;


            }
            else
            {
                Debug.Log("fighter1 staat voor de fighter2");
                // retake choice
            }
        }
        else if (Choice == 3)
        { //(achteruit)
            if (Dis < 10)
            {
                fighter1--;
            }
            else
            {
                Debug.Log("fighter1 staat zo ver achteruit als hij kan");
                // retake choice
            }
            if ()
            {
                NextTurn();
            }
        }

    }
    /// <summary>
    /// attack managed de damage die de enemy of de speler krijgt
    /// </summary>
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
        if (fighter2.Health <= 0)
        {
            EndCombat();
        }
        else
        {
            NextTurn();
        }

    }

    /// <summary>
    /// de enemy behaviour gaat kijken wat de keuze gaat zijn voor de AI ennemy 
    /// </summary>
    public void EnemyBehaviour(ICombatant enemy)
    {
        if (_distance < 2)
        {
            _choice = 1;
            Battle(_playerPos, _enemyPos, _distance, _choice);
        }
        else if (_distance > 2)
        {
            _choice = 2;
            Battle(_playerPos, _enemyPos, _distance, _choice);
        }
        else if ( enemy.Health < 5 &&_distance < Weapon.Range)
        {
            _choice = 3;
            Battle(_playerPos, _enemyPos, _distance, _choice);
        }

    }

}
