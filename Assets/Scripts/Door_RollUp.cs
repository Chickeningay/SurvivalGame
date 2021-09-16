using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_RollUp : MonoBehaviour
{
    public GameObject interactDetect;
    bool closewait;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<InteractDetector>().Interacted&&!gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Door_Open"))
        {
            gameObject.GetComponent<Animator>().Play("Door_Open");
            interactDetect.GetComponent<InteractScript>().interacted = false;
            StopCoroutine(WaitToClose());
            StartCoroutine(WaitToClose());
            
            
            
        }
        else if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Door_Open")&& gameObject.GetComponent<InteractDetector>().Interacted)
        {
            gameObject.GetComponent<Animator>().Play("Door_Close");
            interactDetect.GetComponent<InteractScript>().interacted = false;
            
        }
    }
    IEnumerator WaitToClose()
    {
       
            yield return new WaitForSeconds(10f);
        interactDetect.GetComponent<InteractScript>().interacted = false;
        gameObject.GetComponent<Animator>().Play("Door_Close");
               
            
        
        
    }
}
