public interface IEnemy : ICombatant
{
	//the xp an enemy is worth
	int XpWorth { get; set; }

	//instead of having a weapon and armor, the enemy has basedamage and resistance dependant on the level
	int Damage { get; set; }
	int Resistance { get; set; }
}