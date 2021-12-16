using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandExecuter : MonoBehaviour
{
    public bool infinite0;
    public bool infinite1;
    public bool infinite2;
    public GameObject WeaponHolder;
    public List<GameObject> ChildList;
    public GameObject commandListener;
   

    // Start is called before the first frame update
    void Start()
    {
        ChildList = WeaponHolder.GetComponent<BetterWeaponSwitchForInventory>().ChildList;
    }

    // Update is called once per frame
    void Update()
    {
        
        infinite0= commandListener.GetComponent<CommandListener>().infinite0;
        infinite1 = commandListener.GetComponent<CommandListener>().infinite1;
        infinite2 = commandListener.GetComponent<CommandListener>().infinite2;
        if (infinite0)
        {

        }
        if (infinite1)
        {
            foreach(GameObject weapon in ChildList)
            {
                if (weapon.GetComponent<WeaponControl>() != null)
                {
                    if (!weapon.GetComponent<WeaponControl>().Melee) { 
                    weapon.GetComponent<WeaponControl>().CurrentAmmo = weapon.GetComponent<WeaponControl>().MaxAmmo;
                    }
                }
                else if (weapon.GetComponent<ItemScript>() != null)
                {
                    if (weapon.GetComponent<ItemScript>().ScaffHolding||weapon.GetComponent<ItemScript>().Door)
                    {
                        weapon.GetComponent<ItemScript>().Ammo = weapon.GetComponent<ItemScript>().MaxAmmo;
                    }
                }
            }
        }
        if (infinite2)
        {
            foreach (GameObject weapon in ChildList)
            {
                if (weapon.GetComponent<WeaponControl>() != null && !weapon.GetComponent<WeaponControl>().Melee)
                {
                    weapon.GetComponent<WeaponControl>().CurrentReserve = weapon.GetComponent<WeaponControl>().MaxReserve;
                }
            }
        }
        }
}
