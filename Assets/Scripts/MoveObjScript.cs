using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjScript : MonoBehaviour
{
    public GameObject PreferredLocation;
    public bool interacted;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interacted = gameObject.GetComponent<InteractDetector>().Interacted;
        gameObject.transform.eulerAngles = new Vector3(0, gameObject.transform.eulerAngles.y,0);
        
        if (interacted)
        {
            gameObject.GetComponent<Rigidbody>().freezeRotation = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3((PreferredLocation.transform.position.x - gameObject.transform.position.x) * 6, (PreferredLocation.transform.position.y - gameObject.transform.position.y)*2 , (PreferredLocation.transform.position.z - gameObject.transform.position.z) * 6);
           
        }
        else if(!interacted)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().freezeRotation = true;


        }
    }
    
}
