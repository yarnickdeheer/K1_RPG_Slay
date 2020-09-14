using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardChoice : Icolletable
{
   public int Rarity { get; set; }
   public int ItemId { get; set; }
   public IWeapon Weapon { get; set; }
   public IPlayer Player { get; set; }
   public GameManager _gameManager;

    public RewardChoice( int rarity, int itemId, IWeapon weapon, IPlayer player)
   {
      Rarity = rarity;
      ItemId = itemId; 
      Weapon = weapon;
      Player = player;
   }
   
   
   public void CollectItem()
   {
      // get choice id   
      //quick test
      if (Input.GetKeyDown(KeyCode.Space))
      {
        // _gameManager.player.MovePoints
         Player.Weapon = Weapon;
         // ga terug naar encouter/map
      }
      
    
      // collect the item if the player chooses so 
      // drop current gear in that possition if it has something in that position
      
      // we need to know what it has right now
      // we need to know the reward 
      // we need to swap what the player has for the new item
      // (pure trough stats)
      // we give the player the stats of the new item
      // then the stats need to swap the current stats for the new stats
   }
}
