public class LeatherArmor : IArmor
{
	public int Weight { get; set; }
	public int Resistance { get; set; }
	public LeatherArmor (int weight, int resistance)
	{
		Weight = weight;
		Resistance = resistance;
	}
}
