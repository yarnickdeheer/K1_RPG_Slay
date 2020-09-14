public interface ICombatant : IDamageable
{
	//the level of the combatant
	int Level { get; set; }

	//primary stats
	int Vit { get; set; }
	int Str { get; set; }
	int Dex { get; set; }

	//secondary stats
	int Health { get; set; }
	int WeightLimit { get; set; }
	int MovePoints { get; set; }
}