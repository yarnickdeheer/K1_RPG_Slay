using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatDisplay
{
    public GameManager _gameManager;
    public CombatHandler _combatHandler;

    private Dictionary<int, DisplayText> _texts;
    private Text _textDistance;
    private Text _textMovepoints;
    private Text _textPlayerHp;
    private Text _textEnemyHp;
    public GameObject _canvas;

    // enemy health bar
    // player health bar
    public CombatDisplay(GameObject textDistance, GameObject textMovepoints, GameObject textPlayerHp, GameObject textEnemyHp, GameObject canvas)
    {
        _texts = new Dictionary<int, DisplayText>();

        _canvas = Object.Instantiate(canvas, canvas.transform.position, Quaternion.identity);
        createText(0, textDistance, _canvas ,1.68f, 3.68f);
        createText(1, textMovepoints, _canvas , -0.1f, 3.57f);
        createText(2, textPlayerHp, _canvas , -1.82f , -2.2f);
        createText(3, textEnemyHp, _canvas , 7.01f, 1.45f);
    }

    public void createText(int index , GameObject gameObject, GameObject parent , float xpos, float ypos)
    {
        _texts[index] = new DisplayText(gameObject, parent, xpos, ypos);
        switch(index)
		{
            case 0:
                _textDistance = _texts[index]._objectText;
                break;
            case 1:
                _textMovepoints = _texts[index]._objectText;
                break;
            case 2:
                _textPlayerHp = _texts[index]._objectText;
                break;
            case 3:
                _textEnemyHp = _texts[index]._objectText;
                break;
        }
    }

    public void UpdateMoving(int dis, int mp)
    {
        _textDistance.text = "D: " + dis.ToString();
        _textMovepoints.text = "MP: " + mp.ToString();
    }

    public void UpdatePlayerHealth(int hp)
    {
        _textPlayerHp.text = "HP: " + hp.ToString();
    }

    public void UpdateEnemyHealth(int hp)
    {
        Debug.Log("help " + _textEnemyHp.gameObject.name); 
        _textEnemyHp.text = "HP: "+ hp.ToString(); 
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