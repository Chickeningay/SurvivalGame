using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemScript : MonoBehaviour
{
    public bool hammerbool;
    public bool ScaffHolding;
    public bool Hammer;
    public bool Door;
    public AnimationClip Switch_Clip;
    public GameObject SecondSpawnPrefab;
    public GameObject ScaffPref;
    public int Ammo;
    public int MaxAmmo;
    public bool AwaitingAction1;
    public bool AwaitingAction2;
    public GameObject ScaffSpawnPrefab;
    public AnimationClip Action1Anim;
    public AnimationClip WalkAnim;
    public GameObject Player;
    public GameObject Inventory;
    public GameObject Selected;
    public Vector3 startpos;
    public Quaternion startrot;
    public GameObject buildicon;
    public GameObject AmmoCounter;
    public AudioClip WoodPlace;
    public AudioClip GlassPlace;
    // Start is called before the first frame update
    void Start()
    {
        startpos = gameObject.transform.localPosition;
        startrot = gameObject.transform.localRotation;
        
    }

    // Update is called once per frame
    private void OnEnable()
    {
        if (Door)
        {
            Selected = Inventory.GetComponent<InventorySelecter>().CurrentSelected;
            if (Selected.gameObject != null)
            {
                Selected.GetComponent<IDHolder>().currentAmmo = Ammo;
            }
            AmmoCounter.GetComponent<Text>().text ="";
              gameObject.GetComponent<DoorRaycast>().enabled = true;
        }
        else if (Hammer)
        {
            AmmoCounter.GetComponent<Text>().text = "";
            gameObject.GetComponent<HammerRaycaster>().enabled = true;
        }
        else if(ScaffHolding)
        {
           
            Selected = Inventory.GetComponent<InventorySelecter>().CurrentSelected;
            if (Selected.gameObject != null)
            {
                Selected.GetComponent<IDHolder>().currentAmmo = Ammo;
            }
            
            gameObject.GetComponent<ScaffHoldRaycaster>().enabled = true;
        }
    }
    void Update()
    {
        buildicon.active = true;
        if (Player.GetComponent<MovementReworked>().moving)
        {
            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State"))
            {
                gameObject.transform.localRotation = startrot;
                gameObject.transform.localPosition = startpos;
                gameObject.GetComponent<Animator>().Play(WalkAnim.name);
            }

        }
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(WalkAnim.name) && !Player.GetComponent<MovementReworked>().moving)
        {
            gameObject.transform.localRotation = startrot;
            gameObject.transform.localPosition = startpos;
            gameObject.GetComponent<Animator>().Play("New State");
        }
        if(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State") && Hammer&&hammerbool)
        {
            gameObject.transform.localRotation = startrot;
            gameObject.transform.localPosition = startpos;
            hammerbool = false;
        }
        else if (!gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State") && Hammer)
        {
            hammerbool = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)&&!Inventory.gameObject.GetComponent<InventorySelecter>().InventoryExtended)
        {
            AwaitingAction1 = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && !Inventory.gameObject.GetComponent<InventorySelecter>().InventoryExtended)
        {
            AwaitingAction2 = true;
        }   
        if (ScaffHolding)
        {
            ScaffHoldingFunction();
        }
        if (Hammer)
        {
            HammerFunction();
        }
        if (Door)
        {
            DoorFunction();
        }
    }
    void ScaffHoldingFunction()
    {
        AmmoCounter.GetComponent<Text>().text = Ammo.ToString();
        ScaffPref.gameObject.active=true;
        if (0 >= Ammo)
        {
            Selected.gameObject.GetComponent<IDHolder>().id = 0;
        }
        if (AwaitingAction1)
        {
            if (!ScaffPref.GetComponent<blockplacement>().notplacable)
            {
                Ammo--;
                gameObject.transform.localRotation = startrot;
                gameObject.transform.localPosition = startpos;
                Instantiate(ScaffSpawnPrefab, ScaffPref.gameObject.transform.position, ScaffSpawnPrefab.gameObject.transform.rotation);
                gameObject.GetComponent<Animator>().Play(Action1Anim.name);
                
                Player.GetComponent<AudioSource>().PlayOneShot(WoodPlace);
            }
            AwaitingAction1 = false;
        }
    }
    void HammerFunction()
    {
        ScaffPref.gameObject.active = true;
        
        if (AwaitingAction1)
        {
            gameObject.transform.localRotation = startrot;
            gameObject.transform.localPosition = startpos;

            gameObject.GetComponent<Animator>().Play(Action1Anim.name);
            if (Player.GetComponent<Raycaster>().Hit.transform.position == ScaffPref.transform.position)
            {
                if(Player.GetComponent<Raycaster>().Hit.transform.gameObject.name== "ScaffholdingSpawn(Clone)")
                {
                    if(Player.GetComponent<Raycaster>().Hit.transform.gameObject.GetComponent<ScaffMatChanger>().currentMat == "Wood")
                    {
                        Player.GetComponent<AudioSource>().PlayOneShot(GlassPlace);
                        Player.GetComponent<Raycaster>().Hit.transform.gameObject.GetComponent<ScaffMatChanger>().currentMat = "Glass";
                    }
                    else if(Player.GetComponent<Raycaster>().Hit.transform.gameObject.GetComponent<ScaffMatChanger>().currentMat == "Glass"|| Player.GetComponent<Raycaster>().Hit.transform.gameObject.GetComponent<ScaffMatChanger>().currentMat == "")
                    {
                        Player.GetComponent<AudioSource>().PlayOneShot(WoodPlace);
                        Player.GetComponent<Raycaster>().Hit.transform.gameObject.GetComponent<ScaffMatChanger>().currentMat = "Wood";
                    }
                      
                }
            }
            AwaitingAction1 = false;
        }
        else if (AwaitingAction2)
        {
            gameObject.transform.localRotation = startrot;
            gameObject.transform.localPosition = startpos;

            gameObject.GetComponent<Animator>().Play(Action1Anim.name);
            if (Player.GetComponent<Raycaster>().Hit.transform.position == ScaffPref.transform.position)
            {
                Player.GetComponent<Raycaster>().Hit.transform.gameObject.GetComponent<HitDetection>().hit=true;
            }
            AwaitingAction2 = false;
        }

    }
    void DoorFunction()
    {
        GameObject Hit;
        ScaffPref.gameObject.active = true;
        AmmoCounter.GetComponent<Text>().text = Ammo.ToString();
        if (0 >= Ammo)
        {
            Selected.gameObject.GetComponent<IDHolder>().id = 0;
        }
        if (AwaitingAction1)
        {
            Player.GetComponent<AudioSource>().PlayOneShot(WoodPlace);
            Ammo--;
            gameObject.transform.localRotation = startrot;
            gameObject.transform.localPosition = startpos;
            Hit = Player.GetComponent<Raycaster>().Hit.transform.gameObject;
            GameObject SpawnedDoor=null;
            if (Player.transform.position.x > Hit.transform.position.x)
            {
                if (Mathf.Abs(Player.transform.position.x - Hit.transform.position.x) > Mathf.Abs(Player.transform.position.y - Hit.transform.position.y) && Mathf.Abs(Player.transform.position.x - Hit.transform.position.x) > Mathf.Abs(Player.transform.position.z - Hit.transform.position.z))
                {
                    SpawnedDoor=Instantiate(SecondSpawnPrefab, ScaffPref.gameObject.transform.position, new Quaternion(SecondSpawnPrefab.gameObject.transform.rotation.x , SecondSpawnPrefab.gameObject.transform.rotation.y, SecondSpawnPrefab.gameObject.transform.rotation.z, SecondSpawnPrefab.gameObject.transform.rotation.w));
                }

            }
            if (Player.transform.position.x < Hit.transform.position.x)
            {
                if (Mathf.Abs(Player.transform.position.x - Hit.transform.position.x) > Mathf.Abs(Player.transform.position.y - Hit.transform.position.y) && Mathf.Abs(Player.transform.position.x - Hit.transform.position.x) > Mathf.Abs(Player.transform.position.z - Hit.transform.position.z))
                {
                    SpawnedDoor = Instantiate(SecondSpawnPrefab, ScaffPref.gameObject.transform.position, new Quaternion(SecondSpawnPrefab.gameObject.transform.rotation.x , SecondSpawnPrefab.gameObject.transform.rotation.y, SecondSpawnPrefab.gameObject.transform.rotation.z, SecondSpawnPrefab.gameObject.transform.rotation.w));
                }
            }
           
            
            if (Player.transform.position.z > Hit.transform.position.z)
            {
                if (Mathf.Abs(Player.transform.position.z - Hit.transform.position.z) > Mathf.Abs(Player.transform.position.y - Hit.transform.position.y) && Mathf.Abs(Player.transform.position.z - Hit.transform.position.z) > Mathf.Abs(Player.transform.position.x - Hit.transform.position.x))
                {
                    SpawnedDoor = Instantiate(ScaffSpawnPrefab, ScaffPref.gameObject.transform.position, new Quaternion(ScaffSpawnPrefab.gameObject.transform.rotation.x, ScaffSpawnPrefab.gameObject.transform.rotation.y, ScaffSpawnPrefab.gameObject.transform.rotation.z, ScaffSpawnPrefab.gameObject.transform.rotation.w));
                }
            }
            if (Player.transform.position.z < Hit.transform.position.z)
            {
                if (Mathf.Abs(Player.transform.position.z - Hit.transform.position.z) > Mathf.Abs(Player.transform.position.y - Hit.transform.position.y) && Mathf.Abs(Player.transform.position.z - Hit.transform.position.z) > Mathf.Abs(Player.transform.position.x - Hit.transform.position.x))
                {
                    SpawnedDoor = Instantiate(ScaffSpawnPrefab, ScaffPref.gameObject.transform.position, new Quaternion(ScaffSpawnPrefab.gameObject.transform.rotation.x, ScaffSpawnPrefab.gameObject.transform.rotation.y, ScaffSpawnPrefab.gameObject.transform.rotation.z, ScaffSpawnPrefab.gameObject.transform.rotation.w));
                }
            }
            SpawnedDoor.GetComponent<DestroyDoor>().OwnerScaff = Hit;
            gameObject.GetComponent<Animator>().Play(Action1Anim.name);
            AwaitingAction1 = false;
        }
    }
    void OnDisable()
    {
        if (ScaffHolding)
        {
            ScaffPref.gameObject.active = false;
            foreach (Transform g in gameObject.GetComponentsInChildren<Transform>())
            {
                if (g.transform.name == "ScaffholdingPrefab")
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                   
                }
            }   
        }
        else if (Hammer)
        {
            ScaffPref.gameObject.active = false;
        }
        else if (Door)
        {
            gameObject.transform.localRotation = startrot;
            gameObject.transform.localPosition = startpos;
            ScaffPref.gameObject.active = false;
        }
    }
}
