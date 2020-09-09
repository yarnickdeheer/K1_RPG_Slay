public class RagsArmor : IArmor
{
	public int Weight { get; set; }
	public int Resistance { get; set; }
	public RagsArmor(int weight, int resistance)
	{
		Weight = weight;
		Resistance = resistance;
	}
}
