using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractScript : MonoBehaviour
{
    public GameObject InteractSubject;
    public GameObject InteractText;
    public string interactOption;
    public bool interacted;
    public string deinteractOption;
    public bool colliding;
    public GameObject Player;
    public bool interacting_needs_continuation;
    public bool Collision_Not_Needed_To_Disable;

    // Start is called before the first frame update
    void Start()
    {
        InteractText = GameObject.Find("InteractText");
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        InteractSubject.GetComponent<InteractDetector>().Interacted = interacted;
        if (interacting_needs_continuation)
        {
            Player.GetComponent<MovementReworked>().interacting = interacted;
        }
       /* if (InteractSubject.gameObject.GetComponent<MoveObjScript>() != null)
        {
            if (interacted)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interacted = false;

                }
            }
        }*/
        if (colliding||interacted)
        {
            

                if (interacted)
                {
                    InteractText.GetComponent<Text>().text = deinteractOption;
                }
                else if(!interacted)
                {
                    InteractText.GetComponent<Text>().text = interactOption;
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                if (interacted)
                {
                    interacted = false;
                }
                else if (!interacted)
                {
                    interacted = true;
                }
                    
                    
                }
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Interacter")
        { colliding = true; }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Interacter")
        {
            colliding = false;
            InteractText.GetComponent<Text>().text = "";
        }
        }
    
}
