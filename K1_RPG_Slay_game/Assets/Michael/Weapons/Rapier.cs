public class Rapier : IWeapon
{
	public int Weight { get; set; }
	public int BaseDamage { get; set; }
	public float StrScaling { get; set; }
	public float DexScaling { get; set; }
	public int Range { get; set; }

	public Rapier(int weight, int baseDamage, float strScaling, float dexScaling, int range)
	{
		Weight = weight;
		BaseDamage = baseDamage;
		StrScaling = strScaling;
		DexScaling = dexScaling;
		Range = range;
	}
}