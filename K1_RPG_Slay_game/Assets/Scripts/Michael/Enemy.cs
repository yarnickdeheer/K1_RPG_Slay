using UnityEngine;

public class Enemy : IEnemy
{
	//ICombatant Implementation
	public int Level { get; set; }

	public int Vit { get; set; }
	public int Str { get; set; }
	public int Dex { get; set; }

	public int Health { get; set; }
	public int WeightLimit { get; set; }
	public int MovePoints { get; set; }

	//IEnemy Implementation

	//Constructor
	public Enemy(int vit, int str, int dex, int weight)
	{
		Level = vit + str + dex;

		Vit = vit;
		Str = str;
		Dex = dex;

		Health = 10 + 2 * vit;
		WeightLimit = 20 + 2 * str;
		MovePoints = (int)Mathf.Floor(5 + dex / 5 - (weight - WeightLimit) / 10);
	}

	public void TakeDamage()
	{

	}
	
}
