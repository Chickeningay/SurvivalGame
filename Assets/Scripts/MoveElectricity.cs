using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveElectricity : MonoBehaviour
{
    public GameObject End1;
    public GameObject End2;
    public bool corrector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (End1.GetComponent<DetectElectricity>().GettingPower || End2.GetComponent<DetectElectricity>().GettingPower)
        {
            End1.tag = "PowerSource";
            End2.tag = "PowerSource";
        }
        else if (!End1.GetComponent<DetectElectricity>().GettingPower && !End2.GetComponent<DetectElectricity>().GettingPower)
        {
            End1.tag = "Untagged";
            End2.tag = "Untagged";
        }
    }
}
