using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headblob : MonoBehaviour
{
    GameObject Player;
    bool hittop;
    bool hitbot=true;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<MovementReworked>().moving&&!hittop&&hitbot)
        {
            Mathf.Lerp(transform.position.y, +0.05f, Time.deltaTime);
            if (gameObject.transform.position.y >= 63.25f)
            {
                hitbot = false;
                hittop = true;
            }
        }
        else if (Player.GetComponent<MovementReworked>().moving && hittop && !hitbot)
        {
            Mathf.Lerp(transform.position.y, -0.05f, Time.deltaTime);
            if (gameObject.transform.position.y >= 63.15f)
            {
                hitbot = true;
                hittop = false;
            }
        }
        if (!Player.GetComponent<MovementReworked>().moving)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 63.2f, gameObject.transform.position.z);
        }
    }
}
