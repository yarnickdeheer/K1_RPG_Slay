using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHandler : ICombatHandler
{
    public bool PlayerTurn { get; set; }
    public IWeapon Weapon { get; set; }
    public GameManager _gameManager = GameManager.Instance;
    public CombatDisplay _combatDisplay;
    public int _choice; // word later vervangen met de input van de speler
    public bool _attacked;

    private int _playerPos = 1;
    private int _enemyPos = 9;
    private int _distance;
    private int _moveSpeed;// set this value when start the battle

    //public enemy _currentEnemy;
    public void WhoStarts()
    {
        _distance = _enemyPos - _playerPos;
        _moveSpeed = _gameManager._player.MovePoints;
        if (_gameManager._player.MovePoints > _gameManager._player.MovePoints)
        {
            PlayerTurn = true;
            // choose in woth the buttons
        }
        else
        {
            PlayerTurn = false;
            EnemyBehaviour(_gameManager._currentEnemy);
        }
    }

    public void GetInput(int Choice)
    {
        if (_attacked == true && Choice == 1)
        {
            //ga terug naar input scherm
        }
        if (_moveSpeed <= 0)
        {
            if (Choice !=1)
            {
                Debug.Log("cant walk anuymore");
            }
            else
            {
                Battle(_distance, Choice);
            }
        }
        else
        {
            Battle(_distance, _choice);
        }

        
        //NextTurn();
    }
    public void EndTurn()
    {
        if (_moveSpeed == 0 && _attacked == true)
        {
            EnemyTurn();
        }
        else
        {
            if (PlayerTurn == true)
            {
                // go to input
            }
            else
            {
                EnemyBehaviour(_gameManager._currentEnemy);
            }
        }

    }
    public void EnemyTurn()
    {
        _distance = _enemyPos - _playerPos;
        PlayerTurn = true;
        EnemyBehaviour(_gameManager._currentEnemy);

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
    public void Battle(int Dis, int Choice)
    {


        if (Choice == 1)
        { //(attack)
            if (Weapon.Range <= Dis)
            {
                Attack(_gameManager._player,_gameManager._currentEnemy);
            }
            else
            {
                //  miss();
                // retake choice
                // ga terug naar input scherm
            }
        }
        else if (Choice == 2)
        { //(vooruit)
            if (Dis != 1)
            {
                Dis--;
                _moveSpeed--;
                _combatDisplay.UpdateMoving(Dis,_moveSpeed);
                // ga terug naar input scherm
                EndTurn();
            }
            else
            {
                Debug.Log("fighter1 staat voor de fighter2");
                // ga terug naar input scherm
                EndTurn();
            }
        }
        else if (Choice == 3)
        { //(achteruit)
            if (Dis < 10)
            {
                Dis++;
                _moveSpeed--;
                _combatDisplay.UpdateMoving(Dis, _moveSpeed);
                // ga terug naar input scherm
                EndTurn();
            }
            else
            {
                Debug.Log("fighter1 staat zo ver achteruit als hij kan");

                // ga terug naar input scherm
                EndTurn();
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
            _attacked = true;
            _combatDisplay.UpdateEnemyHealth(fighter2.Health);


            if (fighter2.Health <= 0)
            {
                EndCombat();
            }
            else
            {
                // go back to input
                EndTurn();
            }
        }
        else
        {
            fighter2.Health -= Mathf.RoundToInt((1 * fighter1.Str) + (1 * fighter1.Dex));
            _combatDisplay.UpdatePlayerHealth(fighter2.Health);
            if (fighter2.Health <= 0)
            {
                EndCombat();
            }
            else
            {
                // go back to input
                EndTurn();
            }
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
            Battle(_distance, _choice);
        }
        else if (_distance > 2)
        {
            _choice = 2;
            Battle(_distance, _choice);
        }
        else if (enemy.Health < 5 && _distance < Weapon.Range)
        {
            _choice = 3;
            Battle(_distance, _choice);
        }

    }

}

 
    

