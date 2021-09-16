using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUp : MonoBehaviour
{
    public Material LightUpMat;
    public Material StartMat;
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
        if (other.gameObject.tag == "PowerSource")
        {
            gameObject.GetComponent<Renderer>().material = LightUpMat;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PowerSource")
        {
            gameObject.GetComponent<Renderer>().material =StartMat;
        }
    }
}
