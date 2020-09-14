﻿using UnityEngine;

public enum PlayerClass
{
	INVALID,
	VITOP,
	STRONK,
	DEXEUS
}

public class GameManager : MonoBehaviour
{
	//Weapon Constructor: weight, baseDamage, strScaling, dexScaling
	//DISCUSS: Another option is making a base class Weapon and adding an enum/type of for example rapier
	static IWeapon RAPIER = new Rapier(6, 10, 2, 0, 1);
	static IWeapon BOW = new Bow(6, 5, 1.5f, 0, 5);
	static IWeapon SHORTSWORD = new Shortsword(4, 5, 1f, 0.5f, 1);
	static IWeapon SWORD = new Sword(6, 5, .5f, .5f, 1);
	static IWeapon GREATSWORD = new Greatsword(10, 10, .5f, 1f, 2);
	static IWeapon BATTLEAXE = new Battleaxe(10, 10, 0f, 1.5f, 1);
	static IWeapon GREATHAMMER = new Greathammer(30, 30, 0f, 2f, 2);

	//Armor Constructor: weight, resistance
	static IArmor MAGIC_ARMOR = new MagicArmor(10, 12);
	static IArmor RAGS_ARMOR = new RagsArmor(8, 6);
	static IArmor LIGHT_ARMOR = new LightArmor(20, 8);
	static IArmor LEATHER_ARMOR = new LeatherArmor(25, 10);
	static IArmor SOLDIER_ARMOR = new SoldierArmor(35, 15);
	static IArmor HEAVY_ARMOR = new HeavyArmor(45, 20);
	static IArmor TANK_ARMOR = new TankArmor(60, 30);

	public ICombatant player;

	void Awake()
    {
		//Enemy constructor: vit, int, str, weight
		player = new Player(5, 1, 1, PlayerClass.VITOP, SWORD, LEATHER_ARMOR);
		 ICombatant enemy1 = new Enemy(2, 2, 2, 30);
    }

    void Update()
    {
        
    }

	void ChooseClass(PlayerClass playerClass)
	{
		switch (playerClass)
		{
			case PlayerClass.VITOP:
				player = new Player(5, 1, 1, playerClass, SWORD, LEATHER_ARMOR);
				break;
			case PlayerClass.STRONK:
				player = new Player(1, 5, 1, playerClass, GREATSWORD, SOLDIER_ARMOR);
				break;
			case PlayerClass.DEXEUS:
				player = new Player(1, 1, 5, playerClass, SHORTSWORD, LIGHT_ARMOR);
				break;
			default:
				Debug.Log("Invalid player class was chosen");
				break;
		}
	}
}
