public class Player : ICombatant
{
	public int Health { get; set; }
	public int Level { get; set; }
	public int Vit { get; set; }
	public int Str { get; set; }
	public int Dex { get; set; }

	public Player(int health, int level, int vit, int str, int dex)
	{
		Health = health;
		Level = level;
		Vit = vit;
		Str = str;
		Dex = dex;
	}

	public void TakeDamage()
	{

	}
}