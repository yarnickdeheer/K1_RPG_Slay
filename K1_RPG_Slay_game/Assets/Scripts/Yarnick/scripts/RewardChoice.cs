using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardChoice : Icolletable
{
   public int Rarity { get; set; }
   public void CollectItem()
   {
      throw new System.NotImplementedException();
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
