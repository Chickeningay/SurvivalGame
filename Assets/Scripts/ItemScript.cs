using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
   
    public bool ScaffHolding;
    public bool Hammer;
    public bool Door;
    public AnimationClip Switch_Clip;
    public GameObject SecondSpawnPrefab;
    public GameObject ScaffPref;
    
    public bool AwaitingAction1;
    public bool AwaitingAction2;
    public GameObject ScaffSpawnPrefab;
    public AnimationClip Action1Anim;
    public AnimationClip WalkAnim;
    public GameObject Player;
    public Vector3 startpos;
    public Quaternion startrot;
    // Start is called before the first frame update
    void Start()
    {
        startpos = gameObject.transform.position;
        startrot = gameObject.transform.rotation;
    }

    // Update is called once per frame
    private void OnEnable()
    {
        if (Door)
        {
            gameObject.GetComponent<DoorRaycast>().enabled = true;
        }
        else if (Hammer)
        {
            gameObject.GetComponent<HammerRaycaster>().enabled = true;
        }
        else if(ScaffHolding)
        {
            gameObject.GetComponent<ScaffHoldRaycaster>().enabled = true;
        }
    }
    void Update()
    {
        if (Player.GetComponent<MovementReworked>().moving)
        {
            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State"))
            {
                gameObject.transform.rotation = startrot;
                gameObject.transform.position = startpos;
                gameObject.GetComponent<Animator>().Play(WalkAnim.name);
            }

        }
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(WalkAnim.name) && !Player.GetComponent<MovementReworked>().moving)
        {
            gameObject.transform.rotation = startrot;
            gameObject.transform.position = startpos;
            gameObject.GetComponent<Animator>().Play("New State");
        }
        if(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State") && Hammer)
        {
            gameObject.transform.rotation = startrot;
            gameObject.transform.position = startpos;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AwaitingAction1 = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
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
        ScaffPref.gameObject.active=true;
        
        if (AwaitingAction1)
        {
            gameObject.transform.rotation = startrot;
            gameObject.transform.position = startpos;
            Instantiate(ScaffSpawnPrefab, ScaffPref.gameObject.transform.position, ScaffSpawnPrefab.gameObject.transform.rotation);
            gameObject.GetComponent<Animator>().Play(Action1Anim.name);
            AwaitingAction1 = false;
        }
    }
    void HammerFunction()
    {
        ScaffPref.gameObject.active = true;
        
        if (AwaitingAction1)
        {
            gameObject.transform.rotation = startrot;
            gameObject.transform.position = startpos;
            
            gameObject.GetComponent<Animator>().Play(Action1Anim.name);
            if (Player.GetComponent<Raycaster>().Hit.transform.position == ScaffPref.transform.position)
            {
                if(Player.GetComponent<Raycaster>().Hit.transform.gameObject.name== "ScaffholdingSpawn(Clone)")
                {
                    if(Player.GetComponent<Raycaster>().Hit.transform.gameObject.GetComponent<ScaffMatChanger>().currentMat == "Wood")
                    {
                        Player.GetComponent<Raycaster>().Hit.transform.gameObject.GetComponent<ScaffMatChanger>().currentMat = "Glass";
                    }
                    else if(Player.GetComponent<Raycaster>().Hit.transform.gameObject.GetComponent<ScaffMatChanger>().currentMat == "Glass"|| Player.GetComponent<Raycaster>().Hit.transform.gameObject.GetComponent<ScaffMatChanger>().currentMat == "")
                    {
                        Player.GetComponent<Raycaster>().Hit.transform.gameObject.GetComponent<ScaffMatChanger>().currentMat = "Wood";
                    }
                      
                }
            }
            AwaitingAction1 = false;
        }
        else if (AwaitingAction2)
        {
            gameObject.transform.rotation = startrot;
            gameObject.transform.position = startpos;

            gameObject.GetComponent<Animator>().Play(Action1Anim.name);
            if (Player.GetComponent<Raycaster>().Hit.transform.position == ScaffPref.transform.position)
            {
                Destroy(Player.GetComponent<Raycaster>().Hit.transform.gameObject);
            }
            AwaitingAction2 = false;
        }

    }
    void DoorFunction()
    {
        GameObject Hit;
        ScaffPref.gameObject.active = true;

        if (AwaitingAction1)
        {
            gameObject.transform.rotation = startrot;
            gameObject.transform.position = startpos;
            Hit = Player.GetComponent<Raycaster>().Hit.transform.gameObject;
            if (Player.transform.position.x > Hit.transform.position.x)
            {
                if (Mathf.Abs(Player.transform.position.x - Hit.transform.position.x) > Mathf.Abs(Player.transform.position.y - Hit.transform.position.y) && Mathf.Abs(Player.transform.position.x - Hit.transform.position.x) > Mathf.Abs(Player.transform.position.z - Hit.transform.position.z))
                {
                    Instantiate(SecondSpawnPrefab, ScaffPref.gameObject.transform.position, new Quaternion(SecondSpawnPrefab.gameObject.transform.rotation.x , SecondSpawnPrefab.gameObject.transform.rotation.y, SecondSpawnPrefab.gameObject.transform.rotation.z, SecondSpawnPrefab.gameObject.transform.rotation.w));
                }

            }
            if (Player.transform.position.x < Hit.transform.position.x)
            {
                if (Mathf.Abs(Player.transform.position.x - Hit.transform.position.x) > Mathf.Abs(Player.transform.position.y - Hit.transform.position.y) && Mathf.Abs(Player.transform.position.x - Hit.transform.position.x) > Mathf.Abs(Player.transform.position.z - Hit.transform.position.z))
                {
                    Instantiate(SecondSpawnPrefab, ScaffPref.gameObject.transform.position, new Quaternion(SecondSpawnPrefab.gameObject.transform.rotation.x , SecondSpawnPrefab.gameObject.transform.rotation.y, SecondSpawnPrefab.gameObject.transform.rotation.z, SecondSpawnPrefab.gameObject.transform.rotation.w));
                }
            }
           
            
            if (Player.transform.position.z > Hit.transform.position.z)
            {
                if (Mathf.Abs(Player.transform.position.z - Hit.transform.position.z) > Mathf.Abs(Player.transform.position.y - Hit.transform.position.y) && Mathf.Abs(Player.transform.position.z - Hit.transform.position.z) > Mathf.Abs(Player.transform.position.x - Hit.transform.position.x))
                {
                    Instantiate(ScaffSpawnPrefab, ScaffPref.gameObject.transform.position, new Quaternion(ScaffSpawnPrefab.gameObject.transform.rotation.x, ScaffSpawnPrefab.gameObject.transform.rotation.y, ScaffSpawnPrefab.gameObject.transform.rotation.z, ScaffSpawnPrefab.gameObject.transform.rotation.w));
                }
            }
            if (Player.transform.position.z < Hit.transform.position.z)
            {
                if (Mathf.Abs(Player.transform.position.z - Hit.transform.position.z) > Mathf.Abs(Player.transform.position.y - Hit.transform.position.y) && Mathf.Abs(Player.transform.position.z - Hit.transform.position.z) > Mathf.Abs(Player.transform.position.x - Hit.transform.position.x))
                {
                    Instantiate(ScaffSpawnPrefab, ScaffPref.gameObject.transform.position, new Quaternion(ScaffSpawnPrefab.gameObject.transform.rotation.x, ScaffSpawnPrefab.gameObject.transform.rotation.y, ScaffSpawnPrefab.gameObject.transform.rotation.z, ScaffSpawnPrefab.gameObject.transform.rotation.w));
                }
            }
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
            gameObject.transform.rotation = startrot;
            gameObject.transform.position = startpos;
            ScaffPref.gameObject.active = false;
        }
    }
}
