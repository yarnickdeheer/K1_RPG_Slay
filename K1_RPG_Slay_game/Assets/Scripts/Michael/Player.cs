using UnityEngine;

public class Player : IPlayer
{
	//ICombatant Implementation
	public int Level { get; set; }

	public int Vit { get; set; }
	public int Str { get; set; }
	public int Dex { get; set; }

	public int Health { get; set; }
	public int WeightLimit { get; set; }
	public int MovePoints { get; set; }

	//IPlayer Implementation
	public string PlayerClass { get; set; }

	public int Xp { get; set; }

	//Constructor
	public Player(int vit, int str, int dex, string playerClass)
	{
		Level = vit + str + dex;

		Vit = vit;
		Str = str;
		Dex = dex;
		
		Health = 10 + 2 * vit;
		WeightLimit = 20 + 2 * str;
		//This formula is incomplete and will not work correctly until I implement a method for getting the weapon and armor referenced in this class
		MovePoints = (int) Mathf.Floor(5 + dex / 5 - (/*Weight - */WeightLimit) / 10);

		PlayerClass = playerClass;
	}

	public void TakeDamage()
	{

	}

	public void LevelUp(int xp)
	{
		//this doesn't work, i give up for now
		Level = (int) Mathf.Floor((Xp + xp) / 12) + 7;

		//Shenanigans to display the correct amount of xp
		int currentLevelXp = 0;
		int nextLevelXp = 0;

		//Xp = 30;
		//xp = 10;
		//40 xp
		//Level = 9

		for (int i = Level; i <= 7; i--)
		{
			nextLevelXp += (i - 6) * 12;
			currentLevelXp += (i - 7) * 12;
		}

		if (Xp + xp > nextLevelXp - currentLevelXp)
		{
			Xp = xp + Xp - nextLevelXp + currentLevelXp;
		}
		else
		{
			Xp += xp;
		}
	}
}