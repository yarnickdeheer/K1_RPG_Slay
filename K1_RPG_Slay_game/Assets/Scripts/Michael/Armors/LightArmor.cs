public class LightArmor : IArmor
{
	public int Weight { get; set; }
	public int Resistance { get; set; }
	public LightArmor (int weight, int resistance)
	{
		Weight = weight;
		Resistance = resistance;
	}
}
