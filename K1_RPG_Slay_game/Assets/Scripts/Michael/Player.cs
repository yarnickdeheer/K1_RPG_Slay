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
}