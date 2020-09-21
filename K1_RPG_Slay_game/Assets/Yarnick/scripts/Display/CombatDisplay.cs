using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatDisplay
{
    public GameManager _gameManager;
    private GameObject _battle_option;
    public CombatHandler _combatHandler;

    private Text _textDistance;
    private Text _textMovepoints;
    private Text _textPlayerHp;
    private Text _textEnemyHp;

    // enemy health bar
    // player health bar

    public void UpdateMoving(int Dis, int Mp)
    {
        _textDistance.text = Dis.ToString();
        _textMovepoints.text = Mp.ToString();
    }

    public void UpdatePlayerHealth(int Hp)
    {
        _textPlayerHp.text = Hp.ToString();
    }

    public void UpdateEnemyHealth(int Hp)
    {
        _textEnemyHp.text = Hp.ToString();
    }
}








//public void ShowId()
//{
//    // show who's turn it is
//    // _textTurnId.text = _turnId.ToString();
//}
//public void ShowBattleOptions()
//{
//    // show battleoptions when it is the player's turn
//    if (_combatHandler.PlayerTurn == true)
//    {
//        _battle_option.SetActive(true);
//    }
//    else
//    {
//        _battle_option.SetActive(false);
//        // quick test
//    }
//}

