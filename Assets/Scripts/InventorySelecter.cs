using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySelecter : MonoBehaviour
{
    public GameObject CurrentSelected;
    public GameObject Selectmark;
    public bool InventoryExtended;
    public GameObject LastSelectedHolster;
    public GameObject Player;
    public GameObject Crosshair;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Crosshair.gameObject.GetComponent<RawImage>().enabled = !InventoryExtended;
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
            else if(Player.GetComponent<MovementReworked>().SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>().CurrentWeaponObject.gameObject.GetComponent<grenadeScript>() != null)
            {
                    if (!Player.GetComponent<MovementReworked>().SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>().CurrentWeaponObject.gameObject.GetComponent<grenadeScript>().gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Player.GetComponent<MovementReworked>().SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>().CurrentWeaponObject.gameObject.GetComponent<grenadeScript>().Action1.name)) { 
                        if (!InventoryExtended)
                {
                    if (Input.GetKeyDown(KeyCode.I))
                    {
                        LastSelectedHolster = CurrentSelected;

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
            else if (Player.GetComponent<MovementReworked>().SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>().CurrentWeaponObject.gameObject.GetComponent<ItemScript>() != null)
                {
                    if (!Player.GetComponent<MovementReworked>().SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>().CurrentWeaponObject.gameObject.GetComponent<ItemScript>().gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Player.GetComponent<MovementReworked>().SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>().CurrentWeaponObject.gameObject.GetComponent<ItemScript>().Action1Anim.name))
                    {
                        if (!InventoryExtended)
                        {
                            if (Input.GetKeyDown(KeyCode.I))
                            {
                                LastSelectedHolster = CurrentSelected;

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
            else if(Player.GetComponent<MovementReworked>().SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>().CurrentWeaponObject == null)
            {
                if (!InventoryExtended)
                {
                    if (Input.GetKeyDown(KeyCode.I))
                    {
                        LastSelectedHolster = CurrentSelected;

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
    public void ChangeSelected(GameObject Selected)
    {
        if (CurrentSelected == null)
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
        else if(CurrentSelected == Selected||Selected.name=="SelectBox")
        {
            CurrentSelected = null;
        }
        
        
    }
}
