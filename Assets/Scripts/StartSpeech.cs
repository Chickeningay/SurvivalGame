using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSpeech : MonoBehaviour
{
    public GameObject SpeechText;
    public bool interacted;
    public GameObject interactor;
    public GameObject Player;
    public GameObject chicken_head;
    public GameObject feather;
    public bool hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<HitDetection>().hit)
        {
            hit = true;
        }
        if (hit)
        {
            Instantiate(feather, transform.position, feather.transform.rotation);
            gameObject.GetComponent<HitDetection>().hit = false;
            hit = false;
            StartCoroutine(wait());
        }
        interacted = gameObject.GetComponent<InteractDetector>().Interacted;
        if (interacted)
        {
            gameObject.GetComponent<Animator>().Play("New State");
            SpeechText.GetComponent<Text>().text = "Bawk!";
            
        }
        else
        {
            gameObject.GetComponent<Animator>().Play("ChickenRun");
            gameObject.GetComponent<Animator>().enabled = true;
            SpeechText.GetComponent<Text>().text = "";
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Explosion" || other.gameObject.tag == "Melee")
        {
            hit = true;
            
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.1f);
        SpeechText.GetComponent<Text>().text = "";
        Destroy(interactor);
        interactor.GetComponent<InteractScript>().InteractText.GetComponent<Text>().text = "";

        Destroy(gameObject);
       
    }
}
