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
	public int XpWorth { get; set; }
	public int Damage { get; set; }
	public int Resistance { get; set; }

	//Constructor
	public Enemy(int vit, int str, int dex, int weight)
	{
		Level = vit + str + dex;

		Vit = vit;
		Str = str;
		Dex = dex;

		//calculate the secondary stats
		Health = GameManager.BASEHEALTH + GameManager.HEALTHVITMODIFIER * vit;
		WeightLimit = GameManager.BASEWEIGHTLIMIT + GameManager.WEIGHTLIMITSTRMODIFIER * str;
		MovePoints = (int)Mathf.Floor(GameManager.BASEMOVEPOINTS + dex / GameManager.MOVEPOINTSDEXMODIFIER -
			(weight - WeightLimit) / GameManager.MOVEPOINTSWEIGHTMODIFIER);

		XpWorth = Level * 10;

		//calculate the damage and the resistance
		Damage = (int)Mathf.Floor(Level / 2);
		Resistance = (int)Mathf.Floor(Level / 2);
	}
}