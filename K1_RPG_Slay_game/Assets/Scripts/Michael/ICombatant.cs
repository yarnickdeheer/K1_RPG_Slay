public interface ICombatant : IDamageable
{
    int Health { get; set; }
	int Level { get; set; }
	int Vit { get; set; }
	int Str { get; set; }
	int Dex { get; set; }
}