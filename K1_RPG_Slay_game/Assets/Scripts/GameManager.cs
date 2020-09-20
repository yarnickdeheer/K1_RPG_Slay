using System.Collections;
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

	//instantiating a SelectButton for the input
	public SelectButton selectButton;

	private int _currentSceneID = 0;

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

		//Instantiate objects
		_em = new EncounterManager();
		_im = new InputManager();
		selectButton = new SelectButton(Resources.Load<Sprite>("Sprites/PlayerSelect"), 
			Resources.Load<Sprite>("Sprites/PlayerDeselect"), 
			Resources.Load<GameObject>("Prefabs/Button"));

		//Manager awake functionality
		_im.AddEm();
		_im.OnLeftButtonPressed += selectButton.SelectedActionLeft;
		_im.OnRightButtonPressed += selectButton.SelectedActionRight;
		_im.OnSelectButtonPressed += selectButton.Use;
	}

    private void Update()
    {
        if(_currentSceneID != SceneManager.GetActiveScene().buildIndex)
        {
            int sceneID = SceneManager.GetActiveScene().buildIndex;
            if (sceneID == 1)
            {
                _em.SpawnPlayer();
                _em.CreateNextFloor();
            }

            _currentSceneID = sceneID;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            int sceneToLoad = _currentSceneID + 1;
            StartCoroutine(SceneSwitchAsync(sceneToLoad));
        }

		_im.UpdateInputs(_maxOptions);
	}

    //This function should be called to switch a Scene
    private IEnumerator SceneSwitchAsync(int sceneID)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneID);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }
            else
            {
                asyncLoad.allowSceneActivation = false;
            }

            yield return null;
        }
    }
    
	//This function should be called to switch a Scene
	public void SceneSwitch()
	{
		Scene scene = SceneManager.GetActiveScene();
		
		//this part of the script knows what scene to switch to
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
			case 2: //go to end screen
				_maxOptions = 2;
				SceneManager.LoadScene(scene.buildIndex + 1);
				break;
			case 3: //back to map
				_maxOptions = 2;
				SceneManager.LoadScene(scene.buildIndex - 2);
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
