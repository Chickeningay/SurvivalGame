using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySelecter : MonoBehaviour
{
    public GameObject CurrentSelected;
    public GameObject Selectmark;
    public bool InventoryExtended;
    public bool ConsoleExtended;
    public GameObject LastSelectedHolster;
    public GameObject Player;
    public GameObject Crosshair;
    public GameObject CommandTaker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ConsoleExtended = !ConsoleExtended;
        }
        if (!CommandTaker.active) { 
        if (Input.GetAxis("Mouse ScrollWheel") < 0f&&CurrentSelected!=null&&!InventoryExtended)
        {
            int current=0;
            if (CurrentSelected.name == "Holder1")
            {
                current = 1;
            }
            else if (CurrentSelected.name == "Holder2")
            {
                current = 2;
            }
            else if (CurrentSelected.name == "Holder3")
            {
                current = 3;
            }
            else if(CurrentSelected.name == "Holder4")
            {
                current = 4;
            }
            else if(CurrentSelected.name == "Holder5")
            {
                current = 5;
            }
            else if(CurrentSelected.name == "Holder6")
            {
                current = 6;
            }
            else if(CurrentSelected.name == "Holder7")
            {
                current = 7;
            }
            else if(CurrentSelected.name == "Holder8")
            {
                current = 8;
            }
            if (current == 0)
            {

            }
            else if (current == 1)
            {
                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster2);
            }
            else if (current == 2)
            {
                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster3);
            }
            else if (current == 3)
            {
                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster4);
            }
            else if (current == 4)
            {
                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster5);
            }
            else if (current == 5)
            {
                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster6);
            }
            else if (current == 6)
            {
                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster7);
            }
            else if (current == 7)
            {
                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster8);
            }
            else if (current == 8)
            {
                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster1);
            }
            

        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f && CurrentSelected != null && !InventoryExtended)
        {
            int current = 0;
            if (CurrentSelected.name == "Holder1")
            {
                current = 1;
            }
            else if (CurrentSelected.name == "Holder2")
            {
                current = 2;
            }
            else if (CurrentSelected.name == "Holder3")
            {
                current = 3;
            }
            else if (CurrentSelected.name == "Holder4")
            {
                current = 4;
            }
            else if (CurrentSelected.name == "Holder5")
            {
                current = 5;
            }
            else if (CurrentSelected.name == "Holder6")
            {
                current = 6;
            }
            else if (CurrentSelected.name == "Holder7")
            {
                current = 7;
            }
            else if (CurrentSelected.name == "Holder8")
            {
                current = 8;
            }
            if (current == 0)
            {

            }
            else if (current == 1)
            {
                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster8);
            }
            else if (current == 2)
            {
                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster1);
            }
            else if (current == 3)
            {
                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster2);
            }
            else if (current == 4)
            {
                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster3);
            }
            else if (current == 5)
            {
                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster4);
            }
            else if (current == 6)
            {
                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster5);
            }
            else if (current == 7)
            {
                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster6);
            }
            else if (current == 8)
            {
                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster7);
            }


        }
        }
        Crosshair.gameObject.GetComponent<RawImage>().enabled = !InventoryExtended;
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CommandTaker.active = !CommandTaker.active;
        }
        if (!Player.GetComponent<MovementReworked>().flashed) {
            if (Player.GetComponent<MovementReworked>().SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>().CurrentWeaponObject != null)
            {

            
            if (Player.GetComponent<MovementReworked>().SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>().CurrentWeaponObject.gameObject.GetComponent<WeaponControl>() != null) { 
                if (!Player.GetComponent<MovementReworked>().SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>().CurrentWeaponObject.gameObject.GetComponent<WeaponControl>().ShootingCooldown) {
                if (!InventoryExtended)
                {
                    if (Input.GetKeyDown(KeyCode.I))
                    {
                        LastSelectedHolster = CurrentSelected;
                                CurrentSelected = null;
                            }
                }
                else if (InventoryExtended)
                {
                    if (Input.GetKeyDown(KeyCode.I))
                    {
                        CurrentSelected = LastSelectedHolster;
                        LastSelectedHolster = null;
                    }
                }

                InventoryExtended = gameObject.transform.GetChild(1).gameObject.GetComponent<DisableInventory>().Enabled;
                if (CurrentSelected == null)
                {
                    Selectmark.active = false;
                }
                else
                {
                    Selectmark.active = true;
                    Selectmark.transform.position = CurrentSelected.transform.position;
                }
                        if (!ConsoleExtended) { 
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                    {
                        ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster1);
                    }
                    else
                    {
                        CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster1;
                    }
                }


                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                    {
                        ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster2);
                    }
                    else
                    {
                        CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster2;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                    {
                        ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster3);
                    }
                    else
                    {
                        CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster3;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                    {
                        ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster4);
                    }
                    else
                    {
                        CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster4;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                    {
                        ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster5);
                    }
                    else
                    {
                        CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster5;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                    {
                        ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster6);
                    }
                    else
                    {
                        CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster6;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                    {

                        ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster7);
                    }
                    else
                    {
                        CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster7;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                    if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                    {
                        ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster8);
                    }
                    else
                    {
                        CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster8;
                    }
                }
                        }
                    }
        }
            else if(Player.GetComponent<MovementReworked>().SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>().CurrentWeaponObject.gameObject.GetComponent<grenadeScript>() != null)
            {
                    if (!Player.GetComponent<MovementReworked>().SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>().CurrentWeaponObject.gameObject.GetComponent<grenadeScript>().gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Player.GetComponent<MovementReworked>().SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>().CurrentWeaponObject.gameObject.GetComponent<grenadeScript>().Action1.name)) { 
                        if (!InventoryExtended)
                {
                    if (Input.GetKeyDown(KeyCode.I))
                    {
                        LastSelectedHolster = CurrentSelected;
                                CurrentSelected = null;
                    }
                }
                else if (InventoryExtended)
                {
                    if (Input.GetKeyDown(KeyCode.I))
                    {
                        CurrentSelected = LastSelectedHolster;
                        LastSelectedHolster = null;
                    }
                }

                InventoryExtended = gameObject.transform.GetChild(1).gameObject.GetComponent<DisableInventory>().Enabled;
                if (CurrentSelected == null)
                {
                    Selectmark.active = false;
                }
                else
                {
                    Selectmark.active = true;
                    Selectmark.transform.position = CurrentSelected.transform.position;
                }
                        if (!ConsoleExtended)
                        {
                            if (Input.GetKeyDown(KeyCode.Alpha1))
                            {
                                if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                                {
                                    ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster1);
                                }
                                else
                                {
                                    CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster1;
                                }
                            }


                            else if (Input.GetKeyDown(KeyCode.Alpha2))
                            {
                                if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                                {
                                    ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster2);
                                }
                                else
                                {
                                    CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster2;
                                }
                            }
                            else if (Input.GetKeyDown(KeyCode.Alpha3))
                            {
                                if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                                {
                                    ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster3);
                                }
                                else
                                {
                                    CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster3;
                                }
                            }
                            else if (Input.GetKeyDown(KeyCode.Alpha4))
                            {
                                if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                                {
                                    ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster4);
                                }
                                else
                                {
                                    CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster4;
                                }
                            }
                            else if (Input.GetKeyDown(KeyCode.Alpha5))
                            {
                                if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                                {
                                    ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster5);
                                }
                                else
                                {
                                    CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster5;
                                }
                            }
                            else if (Input.GetKeyDown(KeyCode.Alpha6))
                            {
                                if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                                {
                                    ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster6);
                                }
                                else
                                {
                                    CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster6;
                                }
                            }
                            else if (Input.GetKeyDown(KeyCode.Alpha7))
                            {
                                if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                                {

                                    ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster7);
                                }
                                else
                                {
                                    CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster7;
                                }
                            }
                            else if (Input.GetKeyDown(KeyCode.Alpha8))
                            {
                                if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                                {
                                    ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster8);
                                }
                                else
                                {
                                    CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster8;
                                }
                            }
                        }
            }
                }
            else if (Player.GetComponent<MovementReworked>().SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>().CurrentWeaponObject.gameObject.GetComponent<ItemScript>() != null)
                {
                    if (!Player.GetComponent<MovementReworked>().SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>().CurrentWeaponObject.gameObject.GetComponent<ItemScript>().gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Player.GetComponent<MovementReworked>().SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>().CurrentWeaponObject.gameObject.GetComponent<ItemScript>().Action1Anim.name))
                    {
                        if (!InventoryExtended)
                        {
                            if (Input.GetKeyDown(KeyCode.I))
                            {
                                LastSelectedHolster = CurrentSelected;
                                CurrentSelected = null;
                            }
                        }
                        else if (InventoryExtended)
                        {
                            if (Input.GetKeyDown(KeyCode.I))
                            {
                                CurrentSelected = LastSelectedHolster;
                                LastSelectedHolster = null;
                            }
                        }

                        InventoryExtended = gameObject.transform.GetChild(1).gameObject.GetComponent<DisableInventory>().Enabled;
                        if (CurrentSelected == null)
                        {
                            Selectmark.active = false;
                        }
                        else
                        {
                            Selectmark.active = true;
                            Selectmark.transform.position = CurrentSelected.transform.position;
                        }
                        if (!ConsoleExtended)
                        {
                            if (Input.GetKeyDown(KeyCode.Alpha1))
                        {
                            if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                            {
                                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster1);
                            }
                            else
                            {
                                CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster1;
                            }
                        }


                        else if (Input.GetKeyDown(KeyCode.Alpha2))
                        {
                            if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                            {
                                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster2);
                            }
                            else
                            {
                                CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster2;
                            }
                        }
                        else if (Input.GetKeyDown(KeyCode.Alpha3))
                        {
                            if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                            {
                                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster3);
                            }
                            else
                            {
                                CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster3;
                            }
                        }
                        else if (Input.GetKeyDown(KeyCode.Alpha4))
                        {
                            if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                            {
                                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster4);
                            }
                            else
                            {
                                CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster4;
                            }
                        }
                        else if (Input.GetKeyDown(KeyCode.Alpha5))
                        {
                            if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                            {
                                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster5);
                            }
                            else
                            {
                                CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster5;
                            }
                        }
                        else if (Input.GetKeyDown(KeyCode.Alpha6))
                        {
                            if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                            {
                                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster6);
                            }
                            else
                            {
                                CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster6;
                            }
                        }
                        else if (Input.GetKeyDown(KeyCode.Alpha7))
                        {
                            if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                            {

                                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster7);
                            }
                            else
                            {
                                CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster7;
                            }
                        }
                        else if (Input.GetKeyDown(KeyCode.Alpha8))
                        {
                            if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                            {
                                ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster8);
                            }
                            else
                            {
                                CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster8;
                            }
                        }
                        }
                    }
                }
            }
            else if(Player.GetComponent<MovementReworked>().SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>().CurrentWeaponObject == null)
            {
                if (!InventoryExtended)
                {
                    if (Input.GetKeyDown(KeyCode.I))
                    {
                        LastSelectedHolster = CurrentSelected;
                        CurrentSelected = null;
                    }
                }
                else if (InventoryExtended)
                {
                    if (Input.GetKeyDown(KeyCode.I))
                    {
                        CurrentSelected = LastSelectedHolster;
                        LastSelectedHolster = null;
                    }
                }

                InventoryExtended = gameObject.transform.GetChild(1).gameObject.GetComponent<DisableInventory>().Enabled;
                if (CurrentSelected == null)
                {
                    Selectmark.active = false;
                }
                else
                {
                    Selectmark.active = true;
                    Selectmark.transform.position = CurrentSelected.transform.position;
                }
                if (!ConsoleExtended) {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                    {
                        ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster1);
                    }
                    else
                    {
                        CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster1;
                    }
                }


                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                    {
                        ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster2);
                    }
                    else
                    {
                        CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster2;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                    {
                        ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster3);
                    }
                    else
                    {
                        CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster3;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                    {
                        ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster4);
                    }
                    else
                    {
                        CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster4;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                    {
                        ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster5);
                    }
                    else
                    {
                        CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster5;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                    {
                        ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster6);
                    }
                    else
                    {
                        CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster6;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                    {

                        ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster7);
                    }
                    else
                    {
                        CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster7;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                    if (gameObject.GetComponent<InventoryManager>().InventorySlot1.GetComponent<RawImage>().enabled)
                    {
                        ChangeSelected(gameObject.GetComponent<InventoryManager>().Holster8);
                    }
                    else
                    {
                        CurrentSelected = gameObject.GetComponent<InventoryManager>().Holster8;
                    }
                }
                }
            }
        }
    }
    public void ChangeSelected(GameObject Selected)
    {
        if (CurrentSelected == Selected || Selected.name == "SelectBox")
        {
            CurrentSelected = null;
        }
        else if (CurrentSelected == null||CurrentSelected!=Selected&&!InventoryExtended)
        {
            if(Selected.GetComponent<IDHolder>().id != 0)
            {
                CurrentSelected = Selected;
            }
        }
        else if (CurrentSelected != null)
        {
           
                int old_id;
            int old_ammo;
                old_id = CurrentSelected.GetComponent<IDHolder>().id;
            old_ammo = CurrentSelected.GetComponent<IDHolder>().currentAmmo;
            
            CurrentSelected.GetComponent<IDHolder>().id = Selected.GetComponent<IDHolder>().id;
            CurrentSelected.GetComponent<IDHolder>().currentAmmo = Selected.GetComponent<IDHolder>().currentAmmo;
            Selected.GetComponent<IDHolder>().currentAmmo = old_ammo;
                Selected.GetComponent<IDHolder>().id = old_id;
                CurrentSelected = null;
          
            
        }
       
        
        
    }
}
