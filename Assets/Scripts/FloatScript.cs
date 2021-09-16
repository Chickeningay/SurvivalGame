using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatScript : MonoBehaviour
{
    public bool inWater;
    bool gravactive;
    public GameObject waterDetector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 6&&!gameObject.GetComponent<MoveObjScript>().interacted)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            if (gravactive)
            {
                if (!waterDetector.GetComponent<FloatDetector>().WaterisOnTop)
                {
                    gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, -1f, gameObject.GetComponent<Rigidbody>().velocity.z);
                }
                else
                {
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                }
               
            }
            inWater = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6 && !gameObject.GetComponent<MoveObjScript>().interacted)
        {
            gravactive = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x/2, gameObject.GetComponent<Rigidbody>().velocity.y/2, gameObject.GetComponent<Rigidbody>().velocity.z/2); inWater = true;
            StartCoroutine(waitforgrav());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            inWater = false;
                 gravactive = false;
        }
    }
    IEnumerator waitforgrav()
    {
        yield return new WaitForSeconds(0.05f);
        gravactive = true;
    }
    
}
