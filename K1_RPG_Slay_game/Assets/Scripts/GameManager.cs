using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerClass
{
	INVALID,
	VITOP,
	STRONK,
	DEXEUS
}

public class GameManager : MonoBehaviour
{
	//Singleton pattern
	private static GameManager INSTANCE;
	public static GameManager Instance
		{
			get { return INSTANCE; }
		}

	//Definitions for other Managers
	public EncounterManager _em;
	public InputManager _im;

	//Weapon Constructor to instantiate all weapons: weight, baseDamage, strScaling, dexScaling
	//DISCUSS: Another option is making a base class Weapon and adding an enum/type of for example rapier
	static IWeapon RAPIER = new Rapier(6, 10, 2, 0, 1);
	static IWeapon BOW = new Bow(6, 5, 1.5f, 0, 5);
	static IWeapon SHORTSWORD = new Shortsword(4, 5, 1f, 0.5f, 1);
	static IWeapon SWORD = new Sword(6, 5, .5f, .5f, 1);
	static IWeapon GREATSWORD = new Greatsword(10, 10, .5f, 1f, 2);
	static IWeapon BATTLEAXE = new Battleaxe(10, 10, 0f, 1.5f, 1);
	static IWeapon GREATHAMMER = new Greathammer(30, 30, 0f, 2f, 2);

	//Armor Constructor to instantiate all armors: weight, resistance
	static IArmor MAGIC_ARMOR = new MagicArmor(10, 12);
	static IArmor RAGS_ARMOR = new RagsArmor(8, 6);
	static IArmor LIGHT_ARMOR = new LightArmor(20, 8);
	static IArmor LEATHER_ARMOR = new LeatherArmor(25, 10);
	static IArmor SOLDIER_ARMOR = new SoldierArmor(35, 15);
	static IArmor HEAVY_ARMOR = new HeavyArmor(45, 20);
	static IArmor TANK_ARMOR = new TankArmor(60, 30);

	//Base formula numbers used in calculations for secondary stats
	public static int BASEHEALTH = 10;
	public static int HEALTHVITMODIFIER = 2;
	public static int BASEWEIGHTLIMIT = 20;
	public static int WEIGHTLIMITSTRMODIFIER = 2;
	public static int BASEMOVEPOINTS = 5;
	public static int MOVEPOINTSDEXMODIFIER = 5;
	public static int MOVEPOINTSWEIGHTMODIFIER = 10;

	public ICombatant _player;
	public ICombatant _currentEnemy;

	//maxOptions for the input manager, at the start when you choose a class you have 3 options
	private int _maxOptions = 3;
	
	private void Awake()
    {
		//Singleton pattern
		if (INSTANCE != null && INSTANCE != this)
		{
			Destroy(gameObject);
		}
		else
		{
			INSTANCE = this;
		}

		//(example) Enemy constructor: vit, str, dex, weight
		//ICombatant enemy1 = new Enemy(2, 2, 2, 30);

		//Instantiate the managers
		_em = new EncounterManager();
		_im = new InputManager();

		//Manager awake functionality
		_im.AddEm();
		//TODO: this functionality needs to be executed whenever the player is placed in scene, not at startup
		_em.SpawnPlayer();
		_em.CreateNextFloor();
	}

    private void Update()
    {
		_im.UpdateInputs(_maxOptions);
	}

	//This function should be called to switch a Scene
	//TODO: find a better way to detect when to execute certain code
	public void SceneSwitch()
	{
		Scene scene = SceneManager.GetActiveScene();
		
		//TODO: detect when we get an item, and when we level up
		switch (scene.buildIndex)
		{
			case 0: //go to map
				_maxOptions = 2;
				SceneManager.LoadScene(scene.buildIndex + 1);
				break;
			case 1: //go to battle
				_maxOptions = 3;
				SceneManager.LoadScene(scene.buildIndex + 1);
				break;
			case 2:
				if (/*item*/true)
				{ //go to item switch
					_maxOptions = 2;
					SceneManager.LoadScene(scene.buildIndex + 1);
				}
				else if (/*death*/ true)
				{ //restart the game
					_maxOptions = 3;
					SceneManager.LoadScene(scene.buildIndex - 2);
				}
				else
				{ //back to map
					_maxOptions = 2;
					SceneManager.LoadScene(scene.buildIndex - 1);
				}
				break;
			case 3:
				if (/*level up*/true)
				{ //go to level up
					_maxOptions = 3;
					SceneManager.LoadScene(scene.buildIndex + 1);
				}
				else
				{ //back to map

					_maxOptions = 2;
					SceneManager.LoadScene(scene.buildIndex - 2);
				}
				break;
			case 4: //back to map
				_maxOptions = 2;
				SceneManager.LoadScene(scene.buildIndex - 3);
				break;
		}
	}

	//This method instantiates a player with the right stats for his class at the start of the game
	public void ChooseClass(PlayerClass playerClass)
	{
		switch (playerClass)
		{
			case PlayerClass.VITOP:
				_player = new Player(5, 1, 1, playerClass, SWORD, LEATHER_ARMOR);
				break;
			case PlayerClass.STRONK:
				_player = new Player(1, 5, 1, playerClass, GREATSWORD, SOLDIER_ARMOR);
				break;
			case PlayerClass.DEXEUS:
				_player = new Player(1, 1, 5, playerClass, SHORTSWORD, LIGHT_ARMOR);
				break;
			default:
				Debug.Log("Invalid player class was chosen");
				break;
		}
	}
}
