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
    public int _choice;
    public bool _attacked;

    private int _playerPos = 1; 
    private int _enemyPos = 8;
    private int _distance;
    private int _moveSpeed;

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
        _moveSpeed = _player.MovePoints;
        _combatDisplay.UpdateMoving(_distance, _moveSpeed);
        _combatDisplay.UpdatePlayerHealth(_player.Health);
        _combatDisplay.UpdateEnemyHealth(_enemy.Health);

    }

    public void WhoStarts()
    {
        _distance = _enemyPos - _playerPos;
        _moveSpeed = _player.MovePoints;
      
        if (_player.MovePoints > _enemy.MovePoints)
        {
            PlayerTurn = true;
        }
        else
        {
            PlayerTurn = false; 
            EnemyBehaviour(_enemy);
        }
    }

    public void GetInput(int Choice)
    {
        Debug.Log("bo");
        if (_attacked == true && Choice == 1)
        {
            Debug.Log("hier gat het fout line59");
            return;
        }
        if (_moveSpeed <= 0)
        {
            if (Choice !=1)
            {
                return;
            }
            else
            {
                Debug.Log("hier gat het fout line70");
                Battle(_distance, Choice,_player);
            }
        }
       
        else
        {
            Debug.Log("hier gat het fout line75");
            Battle(_distance, Choice, _player);
        }
    }
    public void EndTurn(ICombatant fighter)
    {

        if (fighter == _player)
        {
            Debug.Log("movepoints "+_moveSpeed + " _attacked " + _attacked);
           
            if (_attacked == true) 
            {
                _moveSpeed = _enemy.MovePoints;
                _combatDisplay.UpdateMoving(_distance, _moveSpeed);
                Debug.Log("player heeft aangevallen");
                _combatDisplay.UpdateMoving(_distance, _moveSpeed);
                _attacked = false;
                EnemyBehaviour(_enemy);
            }
            if (_moveSpeed <= 0 && _distance > _player.Weapon.Range)
            {
                _moveSpeed = _enemy.MovePoints;
                _combatDisplay.UpdateMoving(_distance, _moveSpeed);
                Debug.Log("end player turn op basis van mP");
                EnemyBehaviour(_enemy);
            }
        }
        else if (fighter == _enemy)
        {
            if (_attacked == true)
            {
                Debug.Log("enemyendturn");
                _moveSpeed = _player.MovePoints;
                _combatDisplay.UpdateMoving(_distance, _moveSpeed);
                _attacked = false;
                return;
            }
            else
            {
                EnemyBehaviour(_enemy);
            }
        }
    }

    public void EnemyTurn()
    {
        _distance = _enemyPos - _playerPos;

        EnemyBehaviour(_enemy);

    }

    public void EndCombat()
    {
        _gameManager.SceneSwitch();
    }

    public void Battle(int Dis, int Choice , ICombatant fighter)
    {
        if (Choice == 1)
        {
            if(fighter == _player) 
            {
                Debug.Log("range: " + _player.Weapon.Range + " distance: " + Dis);
                if (Dis <=_player.Weapon.Range && _attacked == false )
                {
                    Attack(fighter, _enemy);
                }
                else
                {
                    Debug.Log("hij staat op true");
                    return;
                }
            }
            else
            {
                if (Dis <= 2) 
                {
                    Debug.Log("enemy probeert aantevallen");
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
        { // vooruit
            if (Dis != 1)
            {
                Dis--;
                _moveSpeed--;
                _distance = Dis;
                _combatDisplay.UpdateMoving(Dis,_moveSpeed);
                if (_attacked == true && _moveSpeed <= 1)
                {
                    _attacked = false;
                    _moveSpeed = _enemy.MovePoints;
                }
                if (fighter == _enemy)
                {
                    EndTurn(_enemy);
                }
                EndTurn(_player);
            }
            else
            {
                EndTurn(_player);
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
                if (_attacked == true && _moveSpeed <= 1)
                {
                    _attacked = false;
                    _moveSpeed = _enemy.MovePoints;
                }
                if (fighter == _enemy)
                {

                    EndTurn(_enemy);
                }
                EndTurn(_player);
            }
            else
            {
                EndTurn(_player);
            }
        }
    }

    /// <summary>
    /// attack managed de damage die de enemy of de speler krijgt
    /// </summary>
    public void Attack(ICombatant fighter1, ICombatant fighter2) 
    {
        if (fighter1 == _player)
        {
            fighter2.Health -= Mathf.RoundToInt(_player.Weapon.BaseDamage + (1 * fighter1.Str * _player.Weapon.StrScaling) + (1 * fighter1.Dex * _player.Weapon.DexScaling));
            _attacked = true;
            _combatDisplay.UpdateEnemyHealth(fighter2.Health);

            if (fighter2.Health <= 0)
            {
                EndCombat();
            }
            else
            {
                EndTurn(_player);
            }
        }
        else
        {
            fighter2.Health -= Mathf.RoundToInt((1 * fighter1.Str) + (1 * fighter1.Dex));
            Debug.Log("enemy damage: " + Mathf.RoundToInt((1 * fighter1.Str) + (1 * fighter1.Dex)));
            _combatDisplay.UpdatePlayerHealth(fighter2.Health);
            _attacked = true;
            if (fighter2.Health <= 0)
            {
                EndCombat();
            }
            else
            {
                EndTurn(_enemy);
            }
        }
    }

    public void EnemyBehaviour(ICombatant enemy)
    {
        Debug.Log("enemy turn"); 
        if (_attacked == true)
        {
            _moveSpeed = _player.MovePoints;
            _attacked = false;
            EndTurn(_enemy);
        }
        if (_distance <= 2 && enemy.Health >= 5 && _attacked ==false)
        {
            Debug.Log("enemy Atack"); 
            _choice = 1;
            Battle(_distance, _choice, _enemy);
        } 
        else if (_distance > 2 && _moveSpeed >=1)
        {
            _choice = 2;
            Debug.Log("enemy loopt naar voren");
            Battle(_distance, _choice, _enemy);
        }
        else if (enemy.Health < 5 && _distance <= 2 && _moveSpeed >= 1)
        {
            _choice = 3;
            Debug.Log("enemy  loopt naar achteren"); 
            Battle(_distance, _choice, _enemy);
        }
    }
}