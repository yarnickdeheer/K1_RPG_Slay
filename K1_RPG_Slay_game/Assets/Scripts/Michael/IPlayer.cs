public interface IPlayer : ICombatant
{
	string PlayerClass { get; set; }
	int Xp { get; set; }

	void LevelUp(int xp);
}