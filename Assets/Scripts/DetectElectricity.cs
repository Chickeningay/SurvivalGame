using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectElectricity : MonoBehaviour
{
    public bool GettingPower;

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
            GettingPower = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PowerSource")
        {
            GettingPower = false;
        }
    }
}
