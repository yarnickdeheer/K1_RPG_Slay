public interface IPlayer : ICombatant
{
	//the class of the player
	PlayerClass PlayerClass { get; set; }

	//the total xp of the player
	int TotalXp { get; set; }

	//the formula for handling getting xp and levelling up
	void GetXp (int xp);

	//the equipped weapon and armor of a player
	IWeapon Weapon { get; set; }
	IArmor Armor { get; set; }
}