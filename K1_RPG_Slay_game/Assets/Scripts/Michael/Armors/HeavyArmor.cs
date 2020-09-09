public class HeavyArmor : IArmor
{
	public int Weight { get; set; }
	public int Resistance { get; set; }
	public HeavyArmor (int weight, int resistance)
	{
		Weight = weight;
		Resistance = resistance;
	}
}
