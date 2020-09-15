public interface IArmor
{
	//<summary> any armor has a few stats which are specifically defined in the game manager.
	//The player can communicate with these weapons via IArmor
	int Weight { get; set; }
    int Resistance { get; set; }
}