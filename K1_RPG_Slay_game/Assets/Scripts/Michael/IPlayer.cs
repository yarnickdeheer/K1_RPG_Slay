public interface IPlayer : ICombatant
{
	PlayerClass PlayerClass { get; set; }
	int TotalXp { get; set; }

	void GetXp (int xp);

	IWeapon Weapon { get; set; }
	IArmor Armor { get; set; }
}