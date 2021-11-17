using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandListener : MonoBehaviour
{
    GameObject player;
    public GameObject textholder;
    GameObject maincamera;
    public bool infinite0=true;
    public bool infinite1;
    public bool infinite2;
    public GameObject itemcam;
    public List<GameObject> ChildList;
    public GameObject currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        
        ChildList = itemcam.GetComponent<BetterWeaponSwitchForInventory>().ChildList;
        player = GameObject.Find("Player");
        maincamera = player.transform.GetChild(0).gameObject;
        itemcam = GameObject.Find("ItemCamera");
    }

    // Update is called once per frame
    void Update()
    {
        int xd = itemcam.GetComponent<BetterWeaponSwitchForInventory>().currentID;
        currentWeapon = ChildList[xd - 1];
        foreach (GameObject weapon in ChildList)
        {
            if (weapon.GetComponent<WeaponControl>() != null)
            {


                weapon.GetComponent<WeaponControl>().enabled = false;

            }
            if (weapon.GetComponent<ItemScript>() != null)
            {
                weapon.GetComponent<ItemScript>().enabled = false;

            }
        }
            string Command = textholder.GetComponent<Text>().text.ToLower();
        
        
        Cursor.visible = true;
        Cursor.lockState=CursorLockMode.None;
        
            if (Input.GetKeyDown(KeyCode.Return))
        {
            
            gameObject.GetComponent<InputField>().text = "";
            string[] Valuee = Command.Split(null);
            
            
            if (Command.Substring(0, 2) == "tp")
            {
                Vector3 CommandPos;
                string[] sizes = Command.Split(null);
               
                if (int.TryParse(sizes[1], out _) || sizes[1] == "*")
                {
                    if (int.TryParse(sizes[2], out _) || sizes[2] == "*")
                    {
                        if (int.TryParse(sizes[3], out _) || sizes[3] == "*")
                        {
                            float x;
                            float y;
                            float z;
                            if (sizes[1] == "*")
                            {
                                x = player.transform.position.x;
                            }
                            else
                            {
                                x = int.Parse(sizes[1]);
                            }
                            if (sizes[2] == "*")
                            {
                                y = player.transform.position.y;
                            }
                            else
                            {
                                y = int.Parse(sizes[2]);
                            }
                            if (sizes[3] == "*")
                            {
                                z = player.transform.position.z;
                            }
                            else
                            {
                                z = int.Parse(sizes[3]);
                            }
                            CommandPos = new Vector3(x, y, z);
                            print(CommandPos);
                            player.GetComponent<MovementReworked>().MoveIntoPosition(CommandPos);
                            gameObject.active = false;
                        }
                    }
                }

            }
            if (Command.Length > 8)
            {
                if (Command.Substring(0, 8) == "teleport")
                {
                    Vector3 CommandPos;
                    string[] sizes = Command.Split(null);

                    if (int.TryParse(sizes[1], out _) || sizes[1] == "*")
                    {
                        if (int.TryParse(sizes[2], out _) || sizes[2] == "*")
                        {
                            if (int.TryParse(sizes[3], out _) || sizes[3] == "*")
                            {
                                float x;
                                float y;
                                float z;
                                if (sizes[1] == "*")
                                {
                                    x = player.transform.position.x;
                                }
                                else
                                {
                                    x = int.Parse(sizes[1]);
                                }
                                if (sizes[2] == "*")
                                {
                                    y = player.transform.position.y;
                                }
                                else
                                {
                                    y = int.Parse(sizes[2]);
                                }
                                if (sizes[3] == "*")
                                {
                                    z = player.transform.position.z;
                                }
                                else
                                {
                                    z = int.Parse(sizes[3]);
                                }
                                CommandPos = new Vector3(x, y, z);
                                print(CommandPos);
                                player.GetComponent<MovementReworked>().MoveIntoPosition(CommandPos);
                                gameObject.active = false;
                            }
                        }
                    }

                }
            }
            
            else if (Command.Substring(0, 2) == "ia" || Command.Substring(0, 2) == "ýa")
            {
                string[] Value = Command.Split(null);
                foreach(string x in Value)
                {

                    print(x);
                    if (x == "0")
                    {
                        infinite0 = true;
                        infinite1 = false;
                        infinite2 = false;
                    }
                    else if (x == "1")
                    {
                        infinite1 = true;
                        infinite2 = false;
                        infinite0 = false;
                    }
                    else if (x == "2")
                    {
                        infinite2 = true;
                        infinite1 = false;
                        infinite0 = false;
                    }
                }
                
                
            }
            if (Command.Length > 14)
            { if (Command.Substring(0, 14) == "infinite ammo" || Command.Substring(0, 14) == "ýnfýnýteammo")
                {
                    string[] Value = Command.Split(null);
                    foreach (string x in Value)
                    {

                        print(x);
                        if (x == "0")
                        {
                            infinite0 = true;
                            infinite1 = false;
                            infinite2 = false;
                        }
                        else if (x == "1")
                        {
                            infinite1 = true;
                            infinite2 = false;
                            infinite0 = false;
                        }
                        else if (x == "2")
                        {
                            infinite2 = true;
                            infinite1 = false;
                            infinite0 = false;
                        }
                    }


                }
            }
            if (Command.Length > 13)
            {
                if (Command.Substring(0, 13) == "infiniteammo")
                {
                    string[] Value = Command.Split(null);
                    foreach (string x in Value)
                    {

                        print(x);
                        if (x == "0")
                        {
                            infinite0 = true;
                            infinite1 = false;
                            infinite2 = false;
                        }
                        else if (x == "1")
                        {
                            infinite1 = true;
                            infinite2 = false;
                            infinite0 = false;
                        }
                        else if (x == "2")
                        {
                            infinite2 = true;
                            infinite1 = false;
                            infinite0 = false;
                        }
                    }


                }
            }
               



















        }
    }
    private void OnDisable()
    {
        if (currentWeapon.GetComponent<WeaponControl>() != null)
        {
            currentWeapon.GetComponent<WeaponControl>().enabled = true;
        }
        if (currentWeapon.GetComponent<ItemScript>() != null)
        {
            currentWeapon.GetComponent<ItemScript>().enabled = true;

        }
        if (currentWeapon.GetComponent<grenadeScript>() != null)
           
        {
            currentWeapon.GetComponent<grenadeScript>().enabled = true;
        }

       
        player.GetComponent<MovementReworked>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
