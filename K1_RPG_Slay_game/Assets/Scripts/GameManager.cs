using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        //Weapon Constructor: weight, baseDamage, strScaling, dexScaling
        IWeapon rapier = new Rapier(6, 10, 2, 0, 1);
        IWeapon bow = new Bow(6, 5, 1.5f, 0, 5);
        IWeapon shortsword = new Shortsword(4, 5, 1f, 0.5f, 1);
        IWeapon sword = new Sword(6, 5, .5f, .5f, 1);
        IWeapon greatsword = new Greatsword(10, 10, .5f, 1f, 2);
        IWeapon battleaxe = new Battleaxe(10, 10, 0f, 1.5f, 1);
        IWeapon greathammer = new Greathammer(30, 30, 0f, 2f, 2);

        //Armor Constructor: weight, resistance
        IArmor magicArmor = new MagicArmor(10, 12);
        IArmor ragsArmor = new RagsArmor(8, 6);
        IArmor lightArmor = new LightArmor(20, 8);
        IArmor leatherArmor = new LeatherArmor(25, 10);
        IArmor soldierArmor = new SoldierArmor(35, 15);
        IArmor heavyArmor = new HeavyArmor(45, 20);
        IArmor tankArmor = new TankArmor(60, 30);
    }

    void Update()
    {
        
    }
}
