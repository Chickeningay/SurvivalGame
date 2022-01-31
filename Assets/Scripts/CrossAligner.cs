using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossAligner : MonoBehaviour
{
    public bool activatebounce = false;public bool stopgoingdown = false;public bool parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!parent)
        {
            gameObject.GetComponent<RawImage>().enabled = gameObject.transform.parent.gameObject.GetComponent<RawImage>().enabled;
            gameObject.transform.localScale = new Vector3(0.075f / gameObject.transform.parent.localScale.x, 0.2f / gameObject.transform.parent.localScale.y, 0.01f / gameObject.transform.parent.localScale.z);
        }
        else
        {
            if (activatebounce)
            {
                activatebounce = false;
                
               
                stopgoingdown = true;
            }
            if (stopgoingdown)
            {
                gameObject.transform.localScale = new Vector3(Mathf.Lerp(gameObject.transform.localScale.x, gameObject.transform.localScale.x + 5f, Time.deltaTime * 3), Mathf.Lerp(gameObject.transform.localScale.y, gameObject.transform.localScale.y +5f, Time.deltaTime * 3), Mathf.Lerp(gameObject.transform.localScale.z, gameObject.transform.localScale.z + 5f, Time.deltaTime *3));
            }
           if (!stopgoingdown)
            {
                gameObject.transform.localScale = new Vector3(Mathf.Lerp(gameObject.transform.localScale.x, 1, Time.deltaTime), Mathf.Lerp(gameObject.transform.localScale.y, 1, Time.deltaTime), Mathf.Lerp(gameObject.transform.localScale.z,1, Time.deltaTime));
                
            }
            stopgoingdown = false;
        }
        
    }
}
