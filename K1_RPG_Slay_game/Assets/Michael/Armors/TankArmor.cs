public class TankArmor : IArmor
{
	public int Weight { get; set; }
	public int Resistance { get; set; }
	public TankArmor (int weight, int resistance)
	{
		Weight = weight;
		Resistance = resistance;
	}
}
