using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PostBattleDisplay
{
    private GameObject _Rewards;
    private bool _Won;
    private int _ExperienceGained;
    
    public void BattleOutcome()
    {
        throw new System.NotImplementedException();
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
        throw new System.NotImplementedException();
        // let the player choose if it wants the reward that will be presented of keep the setup he has
    }
    

}
