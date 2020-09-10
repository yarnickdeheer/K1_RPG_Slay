public class MagicArmor : IArmor
{
	public int Weight { get; set; }
	public int Resistance { get; set; }
	public MagicArmor(int weight, int resistance)
	{
		Weight = weight;
		Resistance = resistance;
	}
}
