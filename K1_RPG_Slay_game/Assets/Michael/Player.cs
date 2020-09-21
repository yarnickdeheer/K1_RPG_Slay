using UnityEngine;

public class Player : IPlayer
{
	//ICombatant Implementation
	public int Level { get; set; }

	public int Vit { get; set; }
	public int Str { get; set; }
	public int Dex { get; set; }

	public int Health { get; set; }
	public int WeightLimit { get; set; }
	public int MovePoints { get; set; }

	//IPlayer Implementation
	public PlayerClass PlayerClass { get; set; }

	public int TotalXp { get; set; }

	public IWeapon Weapon { get; set; }
	public IArmor Armor { get; set; }

	//Constants
	

	//Constructor
	public Player(int vit, int str, int dex, PlayerClass playerClass, IWeapon weapon, IArmor armor)
	{
		Level = vit + str + dex;
		Vit = vit;
		Str = str;
		Dex = dex;

		Weapon = weapon;
		Armor = armor;
		
		//calculate the total weight
		int weight = Armor.Weight + weapon.Weight;

		//calculate the secondary stats
		Health = GameManager.BASEHEALTH + GameManager.HEALTHVITMODIFIER * vit;
		WeightLimit = GameManager.BASEWEIGHTLIMIT + GameManager.WEIGHTLIMITSTRMODIFIER * str;
		MovePoints = (int) Mathf.Floor(GameManager.BASEMOVEPOINTS + dex / GameManager.MOVEPOINTSDEXMODIFIER - 
			(weight - WeightLimit) / GameManager.MOVEPOINTSWEIGHTMODIFIER);

		PlayerClass = playerClass;
	}

	public void TakeDamage()
	{

	}

	public void GetXp(int xp)
	{
		//add the gained xp to the totalxp
		TotalXp += xp;

		//make some variables we can work with
		int _newXp = TotalXp;
		int _i = 1;
		int _currLevel = Level;

		//count the levels
		do
		{
			_newXp -= _i * 12;
			_i++;
		}
		while (_newXp > 0);

		Level = _i + 7;

		//check if a levelup has occured
		if (Level > _currLevel)
		{//if so, we need to let the player allocate new stats
			AllocateStats(Level - _currLevel);
		}
	}

	private void AllocateStats(int points)
	{
		GameManager.Instance.SceneSwitch();
		//TODO: give the player the choice to increase a stat
		//depending on input:

		//for (int i = points; i--; i = 0)
		//{
		//Check the input with for example an IEnumerator
		//StartCoroutine(WaitForPlayerInput);
		//vit++;
		//str++;
		//dex++;
		//}
	}

	//an example to detect input:
	//private IEnumerator WaitForPlayerInput(keyCode key)
	//{
	//if (Input.anyKeyDown)
	//yield return Input.inputString;
	//else
	//yield return null;
	//}
}