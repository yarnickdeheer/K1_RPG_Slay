public class SoldierArmor : IArmor
{
	public int Weight { get; set; }
	public int Resistance { get; set; }
	public SoldierArmor (int weight, int resistance)
	{
		Weight = weight;
		Resistance = resistance;
	}
}
