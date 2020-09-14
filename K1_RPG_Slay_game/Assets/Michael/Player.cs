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
	public PlayerClass PlayerClass { get; set; }

	public int TotalXp { get; set; }

	public IWeapon Weapon { get; set; }
	public IArmor Armor { get; set; }

	//Constructor
	public Player(int vit, int str, int dex, PlayerClass playerClass, IWeapon weapon, IArmor armor)
	{
		Level = vit + str + dex;

		Vit = vit;
		Str = str;
		Dex = dex;

		Weapon = weapon;
		Armor = armor;
		int weight = Armor.Weight + weapon.Weight;

		//TODO: Put numbers in constants
		Health = 10 + 2 * vit;
		WeightLimit = 20 + 2 * str;
		MovePoints = (int) Mathf.Floor(5 + dex / 5 - (weight - WeightLimit) / 10);

		PlayerClass = playerClass;
	}

	public void TakeDamage()
	{

	}

	public void GetXp(int xp)
	{
		TotalXp += xp;
		int newXp = TotalXp;
		int i = 1;
		int currLevel = Level;

		do
		{
			newXp -= i * 12;
			i++;
		}
		while (newXp > 0);

		Level = i + 7;

		if (Level > currLevel)
		{
			AllocateStats(Level - currLevel);
		}
	}

	private void AllocateStats(int points)
	{

	}
}