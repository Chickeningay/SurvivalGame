using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perpectivechanger : MonoBehaviour
{
    public GameObject x;
    public GameObject y;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (x.GetComponent<Camera>().enabled)
            {
                x.GetComponent<Camera>().enabled = false;
                y.GetComponent<Camera>().enabled = false;
                cam1.GetComponent<Camera>().enabled = true;
            }
            else if (cam1.GetComponent<Camera>().enabled)
            {
                cam1.GetComponent<Camera>().enabled = false;
                cam2.GetComponent<Camera>().enabled = true;
            }
            else if (cam2.GetComponent<Camera>().enabled)
            {
                cam2.GetComponent<Camera>().enabled = false;
                cam3.GetComponent<Camera>().enabled = true;
            }
            else if (cam3.GetComponent<Camera>().enabled)
            {
                cam3.GetComponent<Camera>().enabled = false;
                cam4.GetComponent<Camera>().enabled = true;
            }
            else if (cam4.GetComponent<Camera>().enabled)
            {
                cam4.GetComponent<Camera>().enabled = false;
                x.GetComponent<Camera>().enabled = true; y.GetComponent<Camera>().enabled = true;
            }
        }
    }
}
