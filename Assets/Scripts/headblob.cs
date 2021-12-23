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
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, transform.localPosition.y + 0.08f, Time.deltaTime * 5), gameObject.transform.localPosition.z);
            if (gameObject.transform.localPosition.y >= 1.07f)
            {
                hitbot = false;
                hittop = true;
            }
        }
        else if (Player.GetComponent<MovementReworked>().moving && hittop && !hitbot)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, transform.localPosition.y - 0.08f, Time.deltaTime * 10), gameObject.transform.localPosition.z);
            if (gameObject.transform.localPosition.y <=0.93f)
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
