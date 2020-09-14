using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatDisplay
    {
        public IcombatHandler Combathandler { get; set; }
        private GameObject _battle_option;
        private Text _textTurnId;
        private int _PlayerId;
        
        public void ShowId()
        {
            // show who's turn it is
           // _textTurnId.text = _turnId.ToString();
        }
        public void ShowBattleOptions()
        {
            // show battleoptions when it is the player's turn
            if (Combathandler._playerturn == true)
            {
                _battle_option.SetActive(true);
            }
            else
            {
                _battle_option.SetActive(false);
                // quick test
            }
        }
    }
