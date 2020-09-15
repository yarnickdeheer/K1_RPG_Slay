public interface IWeapon
{
	//<summary> any weapon has a few stats which are specifically defined in the game manager.
	//The player can communicate with these weapons via IWeapon
	int Weight { get; set; }
	int BaseDamage { get; set; }
	float StrScaling { get; set; }
	float DexScaling { get; set; }
	int Range { get; set; }
}