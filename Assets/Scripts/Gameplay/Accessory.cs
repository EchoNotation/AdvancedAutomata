using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessory : MonoBehaviour
{
    public enum DamageType {
        KINETIC,
        ENERGY,
        INCENDIARY,
    }

    public enum Weapon {
        CANNON,
        FLAMETHROWER,
        ARC_THROWER,
    }

    public enum Armor {
        REINFORCED_PLATING,
        ANTI_STATIC_PLATING,
    }

    public enum Utility {
        CRANE,
        HOPPER,
        DEAD_MANS_SWITCH,
    }

    public enum Weight {
        LIGHT,
        MEDIUM,
        HEAVY,
    }

    private MachineFrame.HardpointType type;
    private Weight weight;

    //Weapon Properties
    private int rechargeTime;
    private int range;
    private List<DamageType> damageTypes;
    private List<int> damageTotals;

    //Armor Properties
    private int kineticResistance, energyResistance, incendiaryResistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //All values are placeholders to eventuallty be tuned/balanced.
    void configureWeapon(Weapon weapon)
    {
        type = MachineFrame.HardpointType.WEAPON;

        damageTotals = new List<int>();
        damageTypes = new List<DamageType>();

        switch(weapon) {
            case Weapon.CANNON:
                damageTypes.Add(DamageType.KINETIC);
                damageTotals.Add(70);
                range = 50;
                rechargeTime = 10;
                weight = Weight.LIGHT;
                break;
            case Weapon.FLAMETHROWER:
                damageTypes.Add(DamageType.INCENDIARY);
                damageTotals.Add(10);
                range = 5;
                rechargeTime = 1;
                weight = Weight.LIGHT;
                break;
            case Weapon.ARC_THROWER:
                damageTypes.Add(DamageType.ENERGY);
                damageTotals.Add(40);
                range = 30;
                rechargeTime = 1;
                weight = Weight.MEDIUM;
                break;
            default:
                Debug.Log("Invalid weapon value-- Forgot to add a case to configureWeapon? Weapon: " + weapon.ToString());
                break;
        }
    }

    void configureArmor(Armor armor)
    {
        type = MachineFrame.HardpointType.ARMOR;

        switch(armor) {
            case Armor.REINFORCED_PLATING:
                kineticResistance = 50;
                energyResistance = 0;
                incendiaryResistance = 60;
                weight = Weight.HEAVY;
                break;
            case Armor.ANTI_STATIC_PLATING:
                kineticResistance = 30;
                energyResistance = 70;
                incendiaryResistance = 20;
                weight = Weight.MEDIUM;
                break;
            default:
                Debug.Log("Invalid armor value-- Forgot to add a case to configureArmor? Armor: " + armor.ToString());
                break;

        }
    }

    void configureUtility(Utility utility)
    {
        type = MachineFrame.HardpointType.UTILITY;
    }

    public MachineFrame.HardpointType getType()
    {
        return type;
    }

    public Weight getWeight()
    {
        return weight;
    }

    public int getRange()
    {
        return range;
    }

    public int getRechargeTime()
    {
        return rechargeTime;
    }

    public List<DamageType> getDamageTypes()
    {
        return damageTypes;
    }

    public List<int> getDamageTotal()
    {
        return damageTotals;
    }
}
