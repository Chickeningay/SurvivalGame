using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IDHolder : MonoBehaviour
{
    public int id;
    public int currentAmmo;
    GameObject Inventory;
    GameObject ItemCam;
    private void Start()
    {
        Inventory = GameObject.Find("Inventory");
        ItemCam = GameObject.Find("ItemCamera");
    }
    void Update()
    {
        if (Inventory.GetComponent<InventorySelecter>().CurrentSelected == gameObject&&id!=0)
        {
            //currentAmmo = ItemCam.GetComponent<BetterWeaponSwitchForInventory>().ChildList[id--].GetComponent<WeaponControl>().CurrentAmmo;
        }
        if (gameObject.name == "Holder1" || gameObject.name == "Holder2" || gameObject.name == "Holder3" || gameObject.name == "Holder4" || gameObject.name == "Holder5" || gameObject.name == "Holder6" || gameObject.name == "Holder7" || gameObject.name == "Holder8")
        { gameObject.GetComponent<Button>().enabled = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<InventorySelecter>().InventoryExtended; }
        
        foreach (Transform g in gameObject.transform.GetComponentInChildren<Transform>())
        {
            g.gameObject.GetComponent<IDtoDisplay>().Parent = gameObject;
        }
    }
}
