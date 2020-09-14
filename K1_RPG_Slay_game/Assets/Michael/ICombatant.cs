	public interface ICombatant : IDamageable
{
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