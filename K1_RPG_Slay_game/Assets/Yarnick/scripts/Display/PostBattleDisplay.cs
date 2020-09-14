using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PostBattleDisplay : IdisplayItem
{
 
    /// <summary>
    ///  this display wil show after the battle
    /// check if you won
    /// if so start generate rewards
    /// else restart scene
    ///
    /// when the reward is generated get the rewards from the rewardchoice class
    ///  
    /// </summary>

    public Image _ItemImage { get; set; }
    public int _ItemId { get; set; }
    
    public IWeapon Weapon { get; set; }
    public IPlayer Player { get; set; }

    public int _Rewards;
    private bool _Won;
    private int _ExperienceGained;
    


    public PostBattleDisplay( int _itemId , Image _itemImage ,IWeapon weapon,IPlayer player)
    {
        _ItemImage = _itemImage;
        _ItemId = _itemId;
        Weapon = weapon;
        Player = player;
    }
    public void BattleOutcome()
    {
       // throw new System.NotImplementedException();
        // needs to know who won to decide if the player gets rewards
        if (_Won == true)
        {
            //add xp to stats
            GenerateRewards();
        }
        else
        {
            //reset game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void GenerateRewards()
    {
        
        Player.GetXp(10);
        // let the player choose if it wants the reward that will be presented of keep the setup he has
    }
    

}
