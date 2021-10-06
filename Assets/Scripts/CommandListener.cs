using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandListener : MonoBehaviour
{
    GameObject player;
    public GameObject textholder;
    GameObject maincamera;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        maincamera = player.transform.GetChild(0).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        string Command = textholder.GetComponent<Text>().text;
        
        maincamera.GetComponent<Rotation>().enabled = false;
        player.GetComponent<Rotation>().enabled = false;
        Cursor.visible = true;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameObject.GetComponent<InputField>().text = "";
            if (Command.Substring(0, 2) == "tp" || Command.Substring(0, 8) == "Teleport" || Command.Substring(0, 8) == "teleport" || Command.Substring(0, 2) == "TP" || Command.Substring(0, 8) == "TELEPORT" || Command.Substring(0, 2) == "Tp")
            {
                Vector3 CommandPos;
                string[] sizes = Command.Split(null);
                foreach (string x in sizes)
                {
                    print(x);
                }
                if (int.TryParse(sizes[1],out _)||sizes[1]=="*")
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
    }
    private void OnDisable()
    {
        maincamera.GetComponent<Rotation>().enabled = true;
        player.GetComponent<Rotation>().enabled = true;
        player.GetComponent<MovementReworked>().enabled = true;
        Cursor.visible = false;
    }

}
