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
    public bool interactableonce;
    bool outline;
    // Start is called before the first frame update
    void Start()
    {
        InteractText = GameObject.Find("InteractText");
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.parent.gameObject.GetComponent<Outline>() != null)
        {
            outline = true;
        }
        InteractSubject.GetComponent<InteractDetector>().Interacted = interacted;
        if (interacting_needs_continuation)
        {
            Player.GetComponent<MovementReworked>().interacting = interacted;
        }
        
        if (colliding||interacted&&gameObject.transform.parent.gameObject.GetComponent<MoveObjScript>()!=null)
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
                    if (interactableonce)
                    {
                        Destroy(gameObject);
                    }
                }
                
                    
                }
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Interacter")
        { colliding = true; 
            if (outline){ 
                            transform.parent.gameObject.GetComponent<Outline>().enabled = true; 
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Interacter")
        {
            if (outline)
            {
                transform.parent.gameObject.GetComponent<Outline>().enabled = false;
            }
            
            colliding = false;
            InteractText.GetComponent<Text>().text = "";
        }
        }
    
}
