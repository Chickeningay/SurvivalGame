using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headblob : MonoBehaviour
{
    GameObject Player;
    public GameObject headbone;
    public GameObject bone1;
    public GameObject bone2;
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
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, transform.localPosition.y + 0.08f, Time.deltaTime * 2), gameObject.transform.localPosition.z);
            headbone.transform.localPosition = new Vector3(headbone.transform.localPosition.x, Mathf.Lerp(headbone.transform.localPosition.y, headbone.transform.localPosition.y - 0.08f, Time.deltaTime * 2), headbone.transform.localPosition.z);
            bone1.transform.localPosition = new Vector3(bone1.transform.localPosition.x, Mathf.Lerp(bone1.transform.localPosition.y, bone1.transform.localPosition.y - 0.08f, Time.deltaTime * 2), bone1.transform.localPosition.z);
            bone2.transform.localPosition = new Vector3(bone2.transform.localPosition.x, Mathf.Lerp(bone2.transform.localPosition.y, bone2.transform.localPosition.y - 0.08f, Time.deltaTime * 2), bone2.transform.localPosition.z);
            if (gameObject.transform.localPosition.y >= 1.04f)
            {
                hitbot = false;
                hittop = true;
            }
        }
        else if (Player.GetComponent<MovementReworked>().moving && hittop && !hitbot)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, transform.localPosition.y - 0.08f, Time.deltaTime * 5), gameObject.transform.localPosition.z);
            headbone.transform.localPosition = new Vector3(headbone.transform.localPosition.x, Mathf.Lerp(headbone.transform.localPosition.y, headbone.transform.localPosition.y + 0.08f, Time.deltaTime * 5), headbone.transform.localPosition.z);
            bone1.transform.localPosition = new Vector3(bone1.transform.localPosition.x, Mathf.Lerp(bone1.transform.localPosition.y, bone1.transform.localPosition.y + 0.08f, Time.deltaTime * 5), bone1.transform.localPosition.z);
            bone2.transform.localPosition = new Vector3(bone2.transform.localPosition.x, Mathf.Lerp(bone2.transform.localPosition.y, bone2.transform.localPosition.y + 0.08f, Time.deltaTime * 5), bone2.transform.localPosition.z);
            if (gameObject.transform.localPosition.y <=0.95f)
            {
                hitbot = true;
                hittop = false;
            }
        }
        if (!Player.GetComponent<MovementReworked>().moving)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, 1f, Time.deltaTime), gameObject.transform.localPosition.z);
            headbone.transform.localPosition = new Vector3(headbone.transform.localPosition.x, Mathf.Lerp(headbone.transform.localPosition.y,1, Time.deltaTime * 5), headbone.transform.localPosition.z);
           /* bone1.transform.localPosition = new Vector3(bone1.transform.localPosition.x, Mathf.Lerp(bone1.transform.localPosition.y, 1, Time.deltaTime * 5), bone1.transform.localPosition.z);
            bone2.transform.localPosition = new Vector3(bone2.transform.localPosition.x, Mathf.Lerp(bone2.transform.localPosition.y, 1, Time.deltaTime * 5), bone2.transform.localPosition.z);*/
        }
    }
}
