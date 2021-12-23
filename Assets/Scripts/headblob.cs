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
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, transform.localPosition.y + 0.15f, Time.deltaTime * 3), gameObject.transform.localPosition.z);
            if (gameObject.transform.localPosition.y >= 1.14f)
            {
                hitbot = false;
                hittop = true;
            }
        }
        else if (Player.GetComponent<MovementReworked>().moving && hittop && !hitbot)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, transform.localPosition.y - 0.15f, Time.deltaTime * 3), gameObject.transform.localPosition.z);
            if (gameObject.transform.localPosition.y <=0.86f)
            {
                hitbot = true;
                hittop = false;
            }
        }
        if (!Player.GetComponent<MovementReworked>().moving)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, 1f, Time.deltaTime), gameObject.transform.localPosition.z);
        }
    }
}
