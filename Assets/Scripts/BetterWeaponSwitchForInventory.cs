using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterWeaponSwitchForInventory : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Player;
    public AudioClip Switch_Audio;
    int childCount;
    public List<GameObject> ChildList;
    public bool RenewAmmo;
    public bool Grounded;
    public int currentWeapon=1;
    public GameObject Holster1;
    public GameObject Holster2;
    public GameObject Holster3;
    public GameObject Holster4;
    public GameObject Holster5;
    public GameObject Holster6;
    public GameObject Holster7;
    public GameObject Holster8;
    public int currentID;
    public GameObject Inventory;
    public bool InventoryExtended;
    public GameObject CurrentWeaponObject;
   
    void Start()
    {
        
        childCount = gameObject.transform.childCount;
        for(int i=0; i < childCount; i++)
        {
            
            ChildList.Add(gameObject.transform.GetChild(i).gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        InventoryExtended = Inventory.GetComponent<InventorySelecter>().InventoryExtended;
        if(Inventory.GetComponent<InventorySelecter>().CurrentSelected != null)
        {

        
        if (Inventory.GetComponent<InventorySelecter>().CurrentSelected.name == "Holder1" || Inventory.GetComponent<InventorySelecter>().CurrentSelected.name == "Holder2" || Inventory.GetComponent<InventorySelecter>().CurrentSelected.name == "Holder3" || Inventory.GetComponent<InventorySelecter>().CurrentSelected.name == "Holder4" || Inventory.GetComponent<InventorySelecter>().CurrentSelected.name == "Holder5" || Inventory.GetComponent<InventorySelecter>().CurrentSelected.name == "Holder6" || Inventory.GetComponent<InventorySelecter>().CurrentSelected.name == "Holder7" || Inventory.GetComponent<InventorySelecter>().CurrentSelected.name == "Holder8")
        { currentID = Inventory.GetComponent<InventorySelecter>().CurrentSelected.GetComponent<IDHolder>().id; }
        else
        {
            currentID=0;
        }
        }
        if (RenewAmmo)
        {
            if (childCount > 0&& ChildList[0].GetComponent<WeaponControl>()!=null)
            {
                ChildList[0].GetComponent<WeaponControl>().CurrentReserve = ChildList[0].GetComponent<WeaponControl>().MaxReserve;
            }
            else if (childCount > 0 && ChildList[0].GetComponent<grenadeScript>() != null)
            {
                ChildList[0].GetComponent<grenadeScript>().CurrentReserve = ChildList[0].GetComponent<grenadeScript>().MaxReserve;

            }
            if (childCount > 1 && ChildList[1].GetComponent<WeaponControl>() != null)
            {
                ChildList[1].GetComponent<WeaponControl>().CurrentReserve = ChildList[1].GetComponent<WeaponControl>().MaxReserve;
            }
            else if (childCount > 1 && ChildList[1].GetComponent<grenadeScript>() != null)
            {
                ChildList[1].GetComponent<grenadeScript>().CurrentReserve = ChildList[1].GetComponent<grenadeScript>().MaxReserve;

            }
            if (childCount > 2 && ChildList[2].GetComponent<WeaponControl>() != null)
            {
                ChildList[2].GetComponent<WeaponControl>().CurrentReserve = ChildList[2].GetComponent<WeaponControl>().MaxReserve;
            }
            else if (childCount > 2 && ChildList[2].GetComponent<grenadeScript>() != null)
            {
                ChildList[2].GetComponent<grenadeScript>().CurrentReserve = ChildList[2].GetComponent<grenadeScript>().MaxReserve;

            }
            if (childCount > 3 && ChildList[3].GetComponent<WeaponControl>() != null)
            {
                ChildList[3].GetComponent<WeaponControl>().CurrentReserve = ChildList[3].GetComponent<WeaponControl>().MaxReserve;
            }
            else if (childCount > 3 && ChildList[3].GetComponent<grenadeScript>() != null)
            {
                ChildList[3].GetComponent<grenadeScript>().CurrentReserve = ChildList[3].GetComponent<grenadeScript>().MaxReserve;

            }
            if (childCount > 4 && ChildList[4].GetComponent<WeaponControl>() != null)
            {
                ChildList[4].GetComponent<WeaponControl>().CurrentReserve = ChildList[4].GetComponent<WeaponControl>().MaxReserve;
            }
            else if(childCount > 4 && ChildList[4].GetComponent<grenadeScript>() != null)
            {
                ChildList[4].GetComponent<grenadeScript>().CurrentReserve = ChildList[4].GetComponent<grenadeScript>().MaxReserve;

            }
            if (childCount > 5 && ChildList[5].GetComponent<WeaponControl>() != null)
            {
                ChildList[5].GetComponent<WeaponControl>().CurrentReserve = ChildList[5].GetComponent<WeaponControl>().MaxReserve;
            }
            else if (childCount > 5 && ChildList[5].GetComponent<grenadeScript>() != null)
            {
                ChildList[5].GetComponent<grenadeScript>().CurrentReserve = ChildList[5].GetComponent<grenadeScript>().MaxReserve;

            }

            if (childCount > 6 && ChildList[6].GetComponent<WeaponControl>() != null)
            {
                ChildList[6].GetComponent<WeaponControl>().CurrentReserve = ChildList[6].GetComponent<WeaponControl>().MaxReserve;
            }
            else if (childCount > 6 && ChildList[6].GetComponent<grenadeScript>() != null)
            {
                ChildList[6].GetComponent<grenadeScript>().CurrentReserve = ChildList[6].GetComponent<grenadeScript>().MaxReserve;

            }
            if (childCount > 7 && ChildList[7].GetComponent<WeaponControl>() != null)
            {
                ChildList[7].GetComponent<WeaponControl>().CurrentReserve = ChildList[7].GetComponent<WeaponControl>().MaxReserve;
            }
            else if (childCount > 7 && ChildList[7].GetComponent<grenadeScript>() != null)
            {
                ChildList[7].GetComponent<grenadeScript>().CurrentReserve = ChildList[7].GetComponent<grenadeScript>().MaxReserve;

            }
            if (childCount > 8 && ChildList[8].GetComponent<WeaponControl>() != null)
            {
                ChildList[8].GetComponent<WeaponControl>().CurrentReserve = ChildList[8].GetComponent<WeaponControl>().MaxReserve;
            }
            else if (childCount > 8 && ChildList[8].GetComponent<grenadeScript>() != null)
            {
                ChildList[8].GetComponent<grenadeScript>().CurrentReserve = ChildList[8].GetComponent<grenadeScript>().MaxReserve;

            }
           
            RenewAmmo = false;

        }
        if (!InventoryExtended)
        {

       
        if (currentID == 0 && currentWeapon != currentID)
        {
            for (int i = 0; i < childCount; i++)
            {

                if (ChildList[i].GetComponent<WeaponControl>() != null) { ChildList[i].GetComponent<WeaponControl>().enabled = false; }
                else if (ChildList[i].GetComponent<grenadeScript>() != null)
                {
                    ChildList[i].GetComponent<grenadeScript>().enabled = false;

                }
                else if(ChildList[i].GetComponent<ItemScript>() != null)
                {
                        ChildList[i].GetComponent<ItemScript>().enabled = false;
                }
                    CurrentWeaponObject = null;
                ChildList[i].layer = 3;
                foreach (Transform g in ChildList[i].transform.GetComponentsInChildren<Transform>())
                {
                    g.gameObject.layer = 3;
                }
            }
            
            currentWeapon = 0;
            MainCamera.GetComponent<Camera>().fieldOfView = 60;
        }
        else if (currentID==1&&currentWeapon!=currentID)
         {
               
             for(int i = 0; i < childCount; i++)
             {
                
                if (ChildList[i].GetComponent<WeaponControl>() != null) { ChildList[i].GetComponent<WeaponControl>().enabled = false; }
                    else if (ChildList[i].GetComponent<grenadeScript>() != null)
                    {
                        ChildList[i].GetComponent<grenadeScript>().enabled = false;

                    }
                    else if (ChildList[i].GetComponent<ItemScript>() != null)
                    {
                        ChildList[i].GetComponent<ItemScript>().enabled = false;
                    }

                    ChildList[i].layer =3;
                 foreach (Transform g in ChildList[i].transform.GetComponentsInChildren<Transform>())
                 {
                     g.gameObject.layer = 3;
                 }
             }
            if (ChildList[0].GetComponent<WeaponControl>() != null) {  ChildList[0].GetComponent<WeaponControl>().enabled = true; ChildList[0].GetComponent<WeaponControl>().ShootingCooldown = false; }
            else if (ChildList[0].GetComponent<grenadeScript>() != null)
            {
                ChildList[0].GetComponent<grenadeScript>().enabled = true;
            }
            else if(ChildList[0].GetComponent<ItemScript>() != null) 
                {
                    ChildList[0].GetComponent<ItemScript>().enabled = true;
                }
            if (ChildList[0].GetComponent<WeaponControl>() != null)
            {
                ChildList[0].GetComponent<Animator>().Play(ChildList[0].GetComponent<WeaponControl>().Switch_Clip.name);
            }
            else if (ChildList[0].GetComponent<grenadeScript>() != null)
             {
                ChildList[0].GetComponent<Animator>().Play(ChildList[0].GetComponent<grenadeScript>().Switch_Clip.name);

            }
            else if (ChildList[0].GetComponent<ItemScript>() != null)
            {
                    ChildList[0].GetComponent<Animator>().Play(ChildList[0].GetComponent<ItemScript>().Switch_Clip.name);

            }

                ChildList[0].layer = 0;
             foreach (Transform g in ChildList[0].transform.GetComponentsInChildren<Transform>())
             {
                 g.gameObject.layer = 0;
                    if(g.gameObject.GetComponent<WeaponControl>()!=null|| g.gameObject.GetComponent<grenadeScript>() != null || g.gameObject.GetComponent<ItemScript>() != null)
                    {
                        CurrentWeaponObject = g.gameObject;
                    }
             }

             Player.GetComponent<AudioSource>().PlayOneShot(Switch_Audio);
            currentWeapon = 1;
            MainCamera.GetComponent<Camera>().fieldOfView = 60;
        }
        else if (currentID == 2 && currentWeapon != currentID)
         {
             for (int i = 0; i < childCount; i++)
             {
                if (ChildList[i].GetComponent<WeaponControl>() != null) { ChildList[i].GetComponent<WeaponControl>().enabled = false; }
                    else if (ChildList[i].GetComponent<grenadeScript>() != null)
                    {
                        ChildList[i].GetComponent<grenadeScript>().enabled = false;

                    }
                    else if (ChildList[i].GetComponent<ItemScript>() != null)
                    {
                        ChildList[i].GetComponent<ItemScript>().enabled = false;
                    }


                    ChildList[i].layer = 3;
                 foreach (Transform g in ChildList[i].transform.GetComponentsInChildren<Transform>())
                 {
                     g.gameObject.layer = 3;
                 }
             }
            if (ChildList[1].GetComponent<WeaponControl>() != null)
            {
                ChildList[1].GetComponent<Animator>().Play(ChildList[1].GetComponent<WeaponControl>().Switch_Clip.name);
            }
                else if (ChildList[1].GetComponent<grenadeScript>() != null)
                {
                    ChildList[1].GetComponent<Animator>().Play(ChildList[1].GetComponent<grenadeScript>().Switch_Clip.name);

                }
                else if (ChildList[1].GetComponent<ItemScript>() != null)
                {
                    ChildList[1].GetComponent<Animator>().Play(ChildList[1].GetComponent<ItemScript>().Switch_Clip.name);

                }
                if (ChildList[1].GetComponent<WeaponControl>() != null) { ChildList[1].GetComponent<WeaponControl>().enabled = true; ChildList[1].GetComponent<WeaponControl>().ShootingCooldown = false; }
                else if (ChildList[1].GetComponent<grenadeScript>() != null)
                {
                    ChildList[1].GetComponent<grenadeScript>().enabled = true;
                }
                else if (ChildList[1].GetComponent<ItemScript>() != null)
                {
                    ChildList[1].GetComponent<ItemScript>().enabled = true;
                }
                ChildList[1].layer = 0;
             foreach (Transform g in ChildList[1].transform.GetComponentsInChildren<Transform>())
             {
                 g.gameObject.layer = 0; 
                    if (g.gameObject.GetComponent<WeaponControl>() != null || g.gameObject.GetComponent<grenadeScript>() != null || g.gameObject.GetComponent<ItemScript>() != null)
                    {
                        CurrentWeaponObject = g.gameObject;
                    }
                }

             Player.GetComponent<AudioSource>().PlayOneShot(Switch_Audio);
            currentWeapon = 2;
            MainCamera.GetComponent<Camera>().fieldOfView = 60;
        }
        else if (currentID == 3 && currentWeapon != currentID)
        {
            if (ChildList[2].GetComponent<WeaponControl>() != null)
            {
                ChildList[2].GetComponent<Animator>().Play(ChildList[2].GetComponent<WeaponControl>().Switch_Clip.name);
            }
                else if (ChildList[2].GetComponent<grenadeScript>() != null)
                {
                    ChildList[2].GetComponent<Animator>().Play(ChildList[2].GetComponent<grenadeScript>().Switch_Clip.name);

                }
                else if (ChildList[2].GetComponent<ItemScript>() != null)
                {
                    ChildList[2].GetComponent<Animator>().Play(ChildList[2].GetComponent<ItemScript>().Switch_Clip.name);

                }
                for (int i = 0; i < childCount; i++)
            {
                if (ChildList[i].GetComponent<WeaponControl>() != null) { ChildList[i].GetComponent<WeaponControl>().enabled = false; }
                    else if (ChildList[i].GetComponent<grenadeScript>() != null)
                    {
                        ChildList[i].GetComponent<grenadeScript>().enabled = false;

                    }
                    else if (ChildList[i].GetComponent<ItemScript>() != null)
                    {
                        ChildList[i].GetComponent<ItemScript>().enabled = false;
                    }

                    ChildList[i].layer = 3;
                foreach (Transform g in ChildList[i].transform.GetComponentsInChildren<Transform>())
                {
                    g.gameObject.layer = 3;
                }
            }
            if (ChildList[2].GetComponent<WeaponControl>() != null) { ChildList[2].GetComponent<WeaponControl>().enabled = true; ChildList[2].GetComponent<WeaponControl>().ShootingCooldown = false; }
                else if (ChildList[2].GetComponent<grenadeScript>() != null)
                {
                    ChildList[2].GetComponent<grenadeScript>().enabled = true;
                }
                else if (ChildList[2].GetComponent<ItemScript>() != null)
                {
                    ChildList[2].GetComponent<ItemScript>().enabled = true;
                }
                ChildList[2].layer = 0;
            foreach (Transform g in ChildList[2].transform.GetComponentsInChildren<Transform>())
            {
                g.gameObject.layer = 0;
                    if (g.gameObject.GetComponent<WeaponControl>() != null || g.gameObject.GetComponent<grenadeScript>() != null || g.gameObject.GetComponent<ItemScript>() != null)
                    {
                        CurrentWeaponObject = g.gameObject;
                    }
                }

            Player.GetComponent<AudioSource>().PlayOneShot(Switch_Audio);
            currentWeapon = 3;
            MainCamera.GetComponent<Camera>().fieldOfView = 60;
        }
        else if (currentID == 4 && currentWeapon != currentID)
        {
            if (ChildList[3].GetComponent<WeaponControl>() != null)
            {
                ChildList[3].GetComponent<Animator>().Play(ChildList[3].GetComponent<WeaponControl>().Switch_Clip.name);
            }
                else if (ChildList[3].GetComponent<grenadeScript>() != null)
                {
                    ChildList[3].GetComponent<Animator>().Play(ChildList[3].GetComponent<grenadeScript>().Switch_Clip.name);

                }
                else if (ChildList[3].GetComponent<ItemScript>() != null)
                {
                    ChildList[3].GetComponent<Animator>().Play(ChildList[3].GetComponent<ItemScript>().Switch_Clip.name);

                }
                for (int i = 0; i < childCount; i++)
            {
                if (ChildList[i].GetComponent<WeaponControl>() != null) { ChildList[i].GetComponent<WeaponControl>().enabled = false; }
                    else if (ChildList[i].GetComponent<grenadeScript>() != null)
                    {
                        ChildList[i].GetComponent<grenadeScript>().enabled = false;

                    }
                    else if (ChildList[i].GetComponent<ItemScript>() != null)
                    {
                        ChildList[i].GetComponent<ItemScript>().enabled = false;
                    }

                    ChildList[i].layer = 3;
                foreach (Transform g in ChildList[i].transform.GetComponentsInChildren<Transform>())
                {
                    g.gameObject.layer = 3;
                }
            }
            if (ChildList[3].GetComponent<WeaponControl>() != null) { ChildList[3].GetComponent<WeaponControl>().enabled = true; ChildList[3].GetComponent<WeaponControl>().ShootingCooldown = false; }
                else if (ChildList[3].GetComponent<grenadeScript>() != null)
                {
                    ChildList[3].GetComponent<grenadeScript>().enabled = true;
                }
                else if (ChildList[3].GetComponent<ItemScript>() != null)
                {
                    ChildList[3].GetComponent<ItemScript>().enabled = true;
                }
                ChildList[3].layer = 0;
            foreach (Transform g in ChildList[3].transform.GetComponentsInChildren<Transform>())
            {
                    if (g.gameObject.GetComponent<WeaponControl>() != null || g.gameObject.GetComponent<grenadeScript>() != null|| g.gameObject.GetComponent<ItemScript>() != null)
                    {
                        CurrentWeaponObject = g.gameObject;
                    }
                    g.gameObject.layer = 0;
            }

            Player.GetComponent<AudioSource>().PlayOneShot(Switch_Audio);
            currentWeapon = 4;
            MainCamera.GetComponent<Camera>().fieldOfView = 60;
        }
        else if (currentID == 5 && currentWeapon != currentID)
        {
            if(ChildList[4].GetComponent<WeaponControl>() != null)
            {
                ChildList[4].GetComponent<Animator>().Play(ChildList[4].GetComponent<WeaponControl>().Switch_Clip.name);
            }
                else if (ChildList[4].GetComponent<grenadeScript>() != null)
                {
                    ChildList[4].GetComponent<Animator>().Play(ChildList[4].GetComponent<grenadeScript>().Switch_Clip.name);

                }
                else if (ChildList[4].GetComponent<ItemScript>() != null)
                {
                    ChildList[4].GetComponent<Animator>().Play(ChildList[4].GetComponent<ItemScript>().Switch_Clip.name);

                }

                for (int i = 0; i < childCount; i++)
            {
                if(ChildList[i].GetComponent<WeaponControl>() != null) { ChildList[i].GetComponent<WeaponControl>().enabled = false; }
                    else if (ChildList[i].GetComponent<grenadeScript>() != null)
                    {
                        ChildList[i].GetComponent<grenadeScript>().enabled = false;

                    }
                    else if (ChildList[i].GetComponent<ItemScript>() != null)
                    {
                        ChildList[i].GetComponent<ItemScript>().enabled = false;
                    }

                    ChildList[i].layer = 3;
                foreach (Transform g in ChildList[i].transform.GetComponentsInChildren<Transform>())
                {
                    g.gameObject.layer = 3;
                }
            }
            if (ChildList[4].GetComponent<WeaponControl>() != null) { ChildList[4].GetComponent<WeaponControl>().enabled = true; ChildList[4].GetComponent<WeaponControl>().ShootingCooldown = false; }
                else if (ChildList[4].GetComponent<grenadeScript>() != null)
                {
                    ChildList[4].GetComponent<grenadeScript>().enabled = true;
                }
                else if (ChildList[4].GetComponent<ItemScript>() != null)
                {
                    ChildList[4].GetComponent<ItemScript>().enabled = true;
                }
                ChildList[4].layer = 0;
            foreach (Transform g in ChildList[4].transform.GetComponentsInChildren<Transform>())
            {
                g.gameObject.layer = 0;
                    if (g.gameObject.GetComponent<WeaponControl>() != null || g.gameObject.GetComponent<grenadeScript>() != null || g.gameObject.GetComponent<ItemScript>() != null)
                    {
                        CurrentWeaponObject = g.gameObject;
                    }
                }

            Player.GetComponent<AudioSource>().PlayOneShot(Switch_Audio);
            currentWeapon = 5;
            MainCamera.GetComponent<Camera>().fieldOfView = 60;
        }
        else if (currentID == 6 && currentWeapon != currentID)
        {
            if(ChildList[5].GetComponent<WeaponControl>() != null)
            {
                ChildList[5].GetComponent<Animator>().Play(ChildList[5].GetComponent<WeaponControl>().Switch_Clip.name);
            }
                else if (ChildList[5].GetComponent<grenadeScript>() != null)
                {
                    ChildList[5].GetComponent<Animator>().Play(ChildList[5].GetComponent<grenadeScript>().Switch_Clip.name);

                }
                else if (ChildList[5].GetComponent<ItemScript>() != null)
                {
                    ChildList[5].GetComponent<Animator>().Play(ChildList[5].GetComponent<ItemScript>().Switch_Clip.name);

                }
                for (int i = 0; i < childCount; i++)
            {
                if (ChildList[i].GetComponent<WeaponControl>() != null) { ChildList[i].GetComponent<WeaponControl>().enabled = false; }
                    else if (ChildList[i].GetComponent<grenadeScript>() != null)
                    {
                        ChildList[i].GetComponent<grenadeScript>().enabled = false;

                    }
                    else if (ChildList[i].GetComponent<ItemScript>() != null)
                    {
                        ChildList[i].GetComponent<ItemScript>().enabled = false;
                    }

                    ChildList[i].layer = 3;
                foreach (Transform g in ChildList[i].transform.GetComponentsInChildren<Transform>())
                {
                    g.gameObject.layer = 3;
                }
            }
            if (ChildList[5].GetComponent<WeaponControl>() != null) { ChildList[5].GetComponent<WeaponControl>().enabled = true; ChildList[5].GetComponent<WeaponControl>().ShootingCooldown = false; }
                else if (ChildList[5].GetComponent<grenadeScript>() != null)
                {
                    ChildList[5].GetComponent<grenadeScript>().enabled = true;
                }
                else if (ChildList[5].GetComponent<ItemScript>() != null)
                {
                    ChildList[5].GetComponent<ItemScript>().enabled = true;
                }
                ChildList[5].layer = 0;
            foreach (Transform g in ChildList[5].transform.GetComponentsInChildren<Transform>())
            {
                g.gameObject.layer = 0;
                    if (g.gameObject.GetComponent<WeaponControl>() != null || g.gameObject.GetComponent<grenadeScript>() != null || g.gameObject.GetComponent<ItemScript>() != null)
                    {
                        CurrentWeaponObject = g.gameObject;
                    }
                }

            Player.GetComponent<AudioSource>().PlayOneShot(Switch_Audio);
            currentWeapon = 6;
            MainCamera.GetComponent<Camera>().fieldOfView = 60;
        }
        else if (currentID == 7 && currentWeapon != currentID)
        {
            if (ChildList[6].GetComponent<WeaponControl>() != null)
            {
                ChildList[6].GetComponent<Animator>().Play(ChildList[6].GetComponent<WeaponControl>().Switch_Clip.name);
            }
                else if (ChildList[6].GetComponent<grenadeScript>() != null)
                {
                    ChildList[6].GetComponent<Animator>().Play(ChildList[6].GetComponent<grenadeScript>().Switch_Clip.name);

                }
                else if (ChildList[6].GetComponent<ItemScript>() != null)
                {
                    ChildList[6].GetComponent<Animator>().Play(ChildList[6].GetComponent<ItemScript>().Switch_Clip.name);

                }
                for (int i = 0; i < childCount; i++)
            {
                if (ChildList[i].GetComponent<WeaponControl>() != null) { ChildList[i].GetComponent<WeaponControl>().enabled = false; }
                    else if (ChildList[i].GetComponent<grenadeScript>() != null)
                    {
                        ChildList[i].GetComponent<grenadeScript>().enabled = false;

                    }
                    else if (ChildList[i].GetComponent<ItemScript>() != null)
                    {
                        ChildList[i].GetComponent<ItemScript>().enabled = false;
                    }

                    ChildList[i].layer = 3;
                foreach (Transform g in ChildList[i].transform.GetComponentsInChildren<Transform>())
                {
                    g.gameObject.layer = 3;
                }
            }
            if (ChildList[6].GetComponent<WeaponControl>() != null) { ChildList[6].GetComponent<WeaponControl>().enabled = true; ChildList[6].GetComponent<WeaponControl>().ShootingCooldown = false; }
                else if (ChildList[6].GetComponent<grenadeScript>() != null)
                {
                    ChildList[6].GetComponent<grenadeScript>().enabled = true;
                }
                else if (ChildList[6].GetComponent<ItemScript>() != null)
                {
                    ChildList[6].GetComponent<ItemScript>().enabled = true;
                }
                ChildList[6].layer = 0;
            foreach (Transform g in ChildList[6].transform.GetComponentsInChildren<Transform>())
            {
                g.gameObject.layer = 0;
                    if (g.gameObject.GetComponent<WeaponControl>() != null || g.gameObject.GetComponent<grenadeScript>() != null || g.gameObject.GetComponent<ItemScript>() != null)
                    {
                        CurrentWeaponObject = g.gameObject;
                    }
                }

            Player.GetComponent<AudioSource>().PlayOneShot(Switch_Audio);
            currentWeapon = 7;
            MainCamera.GetComponent<Camera>().fieldOfView = 60;
        }
        else if (currentID == 8 && currentWeapon != currentID)
        {
            if (ChildList[7].GetComponent<WeaponControl>() != null)
            {
                ChildList[7].GetComponent<Animator>().Play(ChildList[7].GetComponent<WeaponControl>().Switch_Clip.name);
            }
                else if (ChildList[7].GetComponent<grenadeScript>() != null)
                {
                    ChildList[7].GetComponent<Animator>().Play(ChildList[7].GetComponent<grenadeScript>().Switch_Clip.name);

                }
                else if (ChildList[7].GetComponent<ItemScript>() != null)
                {
                    ChildList[7].GetComponent<Animator>().Play(ChildList[7].GetComponent<ItemScript>().Switch_Clip.name);

                }
                for (int i = 0; i < childCount; i++)
            {
                if (ChildList[i].GetComponent<WeaponControl>() != null) { ChildList[i].GetComponent<WeaponControl>().enabled = false; }
                    else if (ChildList[i].GetComponent<grenadeScript>() != null)
                    {
                        ChildList[i].GetComponent<grenadeScript>().enabled = false;

                    }
                    else if (ChildList[i].GetComponent<ItemScript>() != null)
                    {
                        ChildList[i].GetComponent<ItemScript>().enabled = false;
                    }
                    ChildList[i].layer = 3;
                foreach (Transform g in ChildList[i].transform.GetComponentsInChildren<Transform>())
                {
                    g.gameObject.layer = 3;
                }
            }
            if (ChildList[7].GetComponent<WeaponControl>() != null) { ChildList[7].GetComponent<WeaponControl>().enabled = true; ChildList[7].GetComponent<WeaponControl>().ShootingCooldown = false; }
                else if (ChildList[7].GetComponent<grenadeScript>() != null)
                {
                    ChildList[7].GetComponent<grenadeScript>().enabled = true;
                }
                else if (ChildList[7].GetComponent<ItemScript>() != null)
                {
                    ChildList[7].GetComponent<ItemScript>().enabled = true;
                }

                ChildList[7].layer = 0;
            foreach (Transform g in ChildList[7].transform.GetComponentsInChildren<Transform>())
            {
                g.gameObject.layer = 0;
                    if (g.gameObject.GetComponent<WeaponControl>() != null || g.gameObject.GetComponent<grenadeScript>() != null || g.gameObject.GetComponent<ItemScript>() != null)
                    {
                        CurrentWeaponObject = g.gameObject;
                    }
                }

            Player.GetComponent<AudioSource>().PlayOneShot(Switch_Audio);
            currentWeapon = 8;
            MainCamera.GetComponent<Camera>().fieldOfView = 60;
        }
        else if (currentID == 9 && currentWeapon != currentID)
        {
            if (ChildList[8].GetComponent<WeaponControl>() != null)
            {
                ChildList[8].GetComponent<Animator>().Play(ChildList[8].GetComponent<WeaponControl>().Switch_Clip.name);
            }
                else if (ChildList[8].GetComponent<grenadeScript>() != null)
                {
                    ChildList[8].GetComponent<Animator>().Play(ChildList[8].GetComponent<grenadeScript>().Switch_Clip.name);

                }
                else if (ChildList[8].GetComponent<ItemScript>() != null)
                {
                    ChildList[8].GetComponent<Animator>().Play(ChildList[8].GetComponent<ItemScript>().Switch_Clip.name);

                }
                for (int i = 0; i < childCount; i++)
            {
                if (ChildList[i].GetComponent<WeaponControl>() != null) { ChildList[i].GetComponent<WeaponControl>().enabled = false; }
                    else if (ChildList[i].GetComponent<grenadeScript>() != null)
                    {
                        ChildList[i].GetComponent<grenadeScript>().enabled = false;

                    }
                    else if (ChildList[i].GetComponent<ItemScript>() != null)
                    {
                        ChildList[i].GetComponent<ItemScript>().enabled = false;
                    }

                    ChildList[i].layer = 3;
                foreach (Transform g in ChildList[i].transform.GetComponentsInChildren<Transform>())
                {
                    g.gameObject.layer = 3;
                }
            }
            if (ChildList[8].GetComponent<WeaponControl>() != null) { ChildList[8].GetComponent<WeaponControl>().enabled = true; ChildList[8].GetComponent<WeaponControl>().ShootingCooldown = false; }
            else if(ChildList[8].GetComponent<grenadeScript>() != null)
            {
                ChildList[8].GetComponent<grenadeScript>().enabled = true;
            }
                else if (ChildList[8].GetComponent<ItemScript>() != null)
                {
                    ChildList[8].GetComponent<ItemScript>().enabled = true;
                }

                ChildList[8].layer = 0;
            foreach (Transform g in ChildList[8].transform.GetComponentsInChildren<Transform>())
            {
                g.gameObject.layer = 0;
                    if (g.gameObject.GetComponent<WeaponControl>() != null || g.gameObject.GetComponent<grenadeScript>() != null || g.gameObject.GetComponent<ItemScript>() != null)
                    {
                        CurrentWeaponObject = g.gameObject;
                    }
                }

            Player.GetComponent<AudioSource>().PlayOneShot(Switch_Audio);
            currentWeapon = 9;
            MainCamera.GetComponent<Camera>().fieldOfView = 60;
        }
            else if (currentID == 10 && currentWeapon != currentID)
            {
                if (ChildList[9].GetComponent<WeaponControl>() != null)
                {
                    ChildList[9].GetComponent<Animator>().Play(ChildList[9].GetComponent<WeaponControl>().Switch_Clip.name);
                }
                else if (ChildList[9].GetComponent<grenadeScript>() != null)
                {
                    ChildList[9].GetComponent<Animator>().Play(ChildList[9].GetComponent<grenadeScript>().Switch_Clip.name);

                }
                else if (ChildList[9].GetComponent<ItemScript>() != null)
                {
                    ChildList[9].GetComponent<Animator>().Play(ChildList[9].GetComponent<ItemScript>().Switch_Clip.name);

                }
                for (int i = 0; i < childCount; i++)
                {
                    if (ChildList[i].GetComponent<WeaponControl>() != null) { ChildList[i].GetComponent<WeaponControl>().enabled = false; }
                    else if (ChildList[i].GetComponent<grenadeScript>() != null)
                    {
                        ChildList[i].GetComponent<grenadeScript>().enabled = false;

                    }
                    else if (ChildList[i].GetComponent<ItemScript>() != null)
                    {
                        ChildList[i].GetComponent<ItemScript>().enabled = false;
                    }

                    ChildList[i].layer = 3;
                    foreach (Transform g in ChildList[i].transform.GetComponentsInChildren<Transform>())
                    {
                        g.gameObject.layer = 3;
                    }
                }
                if (ChildList[9].GetComponent<WeaponControl>() != null) { ChildList[9].GetComponent<WeaponControl>().enabled = true; ChildList[9].GetComponent<WeaponControl>().ShootingCooldown = false; }
                else if (ChildList[9].GetComponent<grenadeScript>() != null)
                {
                    ChildList[9].GetComponent<grenadeScript>().enabled = true;
                }
                else if (ChildList[9].GetComponent<ItemScript>() != null)
                {
                    ChildList[9].GetComponent<ItemScript>().enabled = true;
                }

                ChildList[9].layer = 0;
                foreach (Transform g in ChildList[9].transform.GetComponentsInChildren<Transform>())
                {
                    g.gameObject.layer = 0;
                    if (g.gameObject.GetComponent<WeaponControl>() != null || g.gameObject.GetComponent<grenadeScript>() != null || g.gameObject.GetComponent<ItemScript>() != null)
                    {
                        CurrentWeaponObject = g.gameObject;
                    }
                }

                Player.GetComponent<AudioSource>().PlayOneShot(Switch_Audio);
                currentWeapon = 10;
                MainCamera.GetComponent<Camera>().fieldOfView = 60;
            }
        }
    }
}
