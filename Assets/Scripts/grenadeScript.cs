using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grenadeScript : MonoBehaviour
{
    public int id;
    public GameObject bombpos;
    public GameObject shortbombpos;
    public GameObject Longbomb;
    public GameObject Shortbomb;
    public AnimationClip Action1;
    public AnimationClip Action2;
    public AnimationClip Switch_Clip;
    public AnimationClip Movement_Anim;
    public int MaxReserve;
    public int CurrentReserve=1;  
    public bool Loaded=true;
    public bool removeBomb=false;
    public AnimationClip Switch;
    public GameObject AmmoText;
    public GameObject RPGIcon;
    public GameObject AmmoIcon;
    public GameObject GrenadeIcon;
    public GameObject MeleeIcon;
    public bool blockreload;
    public AudioClip Action1_Audio;
    public GameObject Player;
    public bool flash;
    public GameObject Inventory;
    public bool InventoryExtended;
    public bool ObeyInventory;
    public GameObject CurrentHolder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Inventory.GetComponent<InventorySelecter>().CurrentSelected.GetComponent<IDHolder>().id == id)
        {
            CurrentHolder = Inventory.GetComponent<InventorySelecter>().CurrentSelected;
        }
        else
        {
            CurrentHolder = null;
        }
        
        if (CurrentReserve == 0&&!Loaded&& CurrentHolder != null&& gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State"))
        {
            CurrentHolder.GetComponent<IDHolder>().id = 0;
        }
        if (ObeyInventory)
        {
            InventoryExtended = Inventory.GetComponent<InventorySelecter>().InventoryExtended;
        }
        if (!Player.GetComponent<MovementReworked>().interacting && !InventoryExtended)
        {
            if (Player.GetComponent<MovementReworked>().InWater == false)
            {
                if (Player.GetComponent<MovementReworked>().moving)
                {
                    if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State"))
                    {
                        gameObject.GetComponent<Animator>().Play(Movement_Anim.name);
                    }

                }
                if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_Anim.name) && !Player.GetComponent<MovementReworked>().moving)
                {
                    gameObject.GetComponent<Animator>().Play("New State");
                }
                if (Loaded && Input.GetKeyDown(KeyCode.Mouse0))
                {
                    StartCoroutine(fireAnim(false));


                }
                if (Loaded && Input.GetKeyDown(KeyCode.Mouse1))
                {
                    StartCoroutine(fireAnim(true));


                }
                if (CurrentReserve >= 1 && !Loaded && !blockreload)
                {
                    Loaded = true;

                    CurrentReserve -= 1;
                    gameObject.GetComponent<Animator>().Play(Switch.name);

                    removeBomb = false;
                }
            }

            if (Loaded)
            {
                AmmoText.GetComponent<Text>().text = "";
            }
            else
            {
                AmmoText.GetComponent<Text>().text = "";
            }
            if (gameObject.layer != 3)
            {
                AmmoIcon.active = false;
                RPGIcon.active = false;
                GrenadeIcon.active = true;
                MeleeIcon.active = false;
            }

        }

    }
    IEnumerator fireAnim(bool shortThrow)
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(Action1_Audio);
        blockreload = true; 
        if (shortThrow)
        {
            gameObject.GetComponent<Animator>().Play(Action2.name);
        }
        else if (!shortThrow)
        {
            gameObject.GetComponent<Animator>().Play(Action1.name);
        }
        
        Loaded = false;
        yield return new WaitForSeconds(0.85f);
        if (shortThrow)
        {
            if (flash)
            {
                Instantiate(Shortbomb, shortbombpos.transform.position, shortbombpos.transform.rotation);
            }
            else
            {
                Instantiate(Shortbomb, shortbombpos.transform.position, shortbombpos.transform.rotation);
            }
            
        }
        else if (!shortThrow)
        {
            if (flash)
            {
                Instantiate(Longbomb, bombpos.transform.position, bombpos.transform.rotation);
            }
            else
            {
                Instantiate(Longbomb, bombpos.transform.position, bombpos.transform.rotation);
            }
            
        }

        removeBomb = true;
        yield return new WaitForSeconds(0.1f);
        blockreload = false;
       

    }
}
