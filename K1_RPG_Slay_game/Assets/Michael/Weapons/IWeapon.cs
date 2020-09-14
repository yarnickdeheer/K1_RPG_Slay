public interface IWeapon
{
	int Weight { get; set; }
	int BaseDamage { get; set; }
	float StrScaling { get; set; }
	float DexScaling { get; set; }
	int Range { get; set; }
}