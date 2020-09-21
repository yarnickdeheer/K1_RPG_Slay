using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHandler : ICombatHandler
{
    public bool PlayerTurn { get; set; }
    public IWeapon Weapon { get; set; }
    public IPlayer _player;
    public IEnemy _enemy;
    public GameManager _gameManager = GameManager.Instance;
    public CombatDisplay _combatDisplay;
    public int _choice; // word later vervangen met de input van de speler
    public bool _attacked;

    private int _playerPos = 1; 
    private int _enemyPos = 9;
    private int _distance;
    private int _moveSpeed;// set this value when start the battle

    public CombatHandler( int choice , bool attacked , int playerpos,int enemypos, IPlayer player , bool playerturn, IEnemy enemy, CombatDisplay display)
    {
        _choice = choice;
        _attacked = attacked;
        _playerPos = playerpos;
        _enemyPos = enemypos;
        _player = player;
        _enemy = enemy;
        PlayerTurn = playerturn;
        _combatDisplay = display;
        _distance = _enemyPos - _playerPos;
        _moveSpeed = _gameManager._player.MovePoints;
        _combatDisplay.UpdateMoving(_distance, _moveSpeed);
        _combatDisplay.UpdatePlayerHealth(_player.Health);
        _combatDisplay.UpdateEnemyHealth(_enemy.Health);

    }

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
            return;
        }
        if (_moveSpeed <= 0)
        {
            if (Choice !=1)
            {
                Debug.Log("cant walk anuymore");

            }
            else
            {
                Battle(_distance, Choice,_player);
            }
        }
       
        else
        {
            Battle(_distance, Choice, _player);
        }
        //NextTurn();
    }
    public void EndTurn()
    {
        if (_moveSpeed == 0 && _attacked == true)
        {
            _moveSpeed = _gameManager._currentEnemy.MovePoints;
            EnemyBehaviour(_enemy);
        }
        else
        {
           // WhoStarts();
        }

    }

    public void EnemyTurn()
    {
        _distance = _enemyPos - _playerPos;
        //PlayerTurn = true;
        EnemyBehaviour(_gameManager._currentEnemy);

    }

    /// <summary>
    /// wanneer de speler of de AI geen health points meer heeft wordt deze functie aangeroepen die naar de post battle display gaat
    /// </summary>
    public void EndCombat()
    {
        //throw new System.NotImplementedException();
        _gameManager.SceneSwitch();
        // if the player or the enemy is dead 
        // when the player is dead go to post battle display as loser 
        // when the enemy is dead go to post battle display as winner
    }

    /// <summary>
    /// de battle functie kijkt welke keuze de speler of de AI heeft gemaakt op basis daarvan gaat hij kijken of deze actie mogelijk is wanneer niet moet je je keuze opnieuw maken
    /// </summary>
    public void Battle(int Dis, int Choice , ICombatant fighter)
    {
        if (Choice == 1)
        { //(attack)
            if(fighter == _player) 
            { 
                if (_player.Weapon.Range <= Dis)
                {
                    Attack(fighter, _enemy);
                }
                else
                {
                    return;
                }
                if (_attacked == true && _moveSpeed <= 1)
                {
                    _attacked = false;
                    _moveSpeed = _gameManager._currentEnemy.MovePoints;
                    EnemyBehaviour(_enemy);
                }
            }
            else
            {
                if (2 <= Dis)
                {
                    PlayerTurn = true;
                    Attack(fighter, _player);

                }
                else
                {
                    return;
                }
            }
        }    
        else if (Choice == 2)
        { //(vooruit)
            if (Dis != 1)
            {
                if (fighter == _enemy)  
                {
                    Debug.Log("wzijn hier AIe");
                }
                Dis--;
                _moveSpeed--;
                _distance = Dis;
                _combatDisplay.UpdateMoving(Dis,_moveSpeed);
                if (_attacked == true && _moveSpeed <= 1)
                {
                    _attacked = false;
                    _moveSpeed = _gameManager._currentEnemy.MovePoints;
                    EnemyBehaviour(_enemy);
                }
                if (fighter == _enemy)
                {
                    EnemyBehaviour(_enemy);
                    //Debug.Log("wzijn hier AIe");
                }
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
                _distance = Dis;
                _combatDisplay.UpdateMoving(Dis, _moveSpeed);
                // ga terug naar input scherm
                if (_attacked == true && _moveSpeed <= 1)
                {
                    _attacked = false;
                    _moveSpeed = _gameManager._currentEnemy.MovePoints;
                    EnemyBehaviour(_enemy);
                }
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
            Debug.Log(fighter2.Health); 
            fighter2.Health -= Mathf.RoundToInt(_player.Weapon.BaseDamage + (1 * fighter1.Str * _player.Weapon.StrScaling) + (1 * fighter1.Dex * _player.Weapon.DexScaling));
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
            _attacked = true;
            if (fighter2.Health <= 0)
            {
                EndCombat();
            }
            else
            {
                // go back to input


                EnemyBehaviour(_gameManager._currentEnemy);
                //EndTurn();
            }
        }
    }

    /// <summary>
    /// de enemy behaviour gaat kijken wat de keuze gaat zijn voor de AI ennemy 
    /// </summary>
    public void EnemyBehaviour(ICombatant enemy)
    { 

        Debug.Log(_gameManager._currentEnemy.Health);

        Debug.Log(_gameManager._currentEnemy.MovePoints);
        if (_attacked == true)
        {
            Debug.Log("EnemyTurn done");
            _moveSpeed = _player.MovePoints;
            _attacked = false;
            EndTurn();
        }
        if (_distance <= 2 && enemy.Health >= 5 && _attacked ==false)
        {
            _choice = 1;
            Battle(_distance, _choice, _enemy);
        } 
        else if (_distance > 2 && _moveSpeed >=1)
        {
            Debug.Log("walk"); 
            _choice = 2;
            Battle(_distance, _choice, _enemy);
        }
        else if (enemy.Health < 5 && _distance <= 2 && _moveSpeed >= 1)
        {
            _choice = 3;
            Battle(_distance, _choice, _enemy);
        }
    }
}