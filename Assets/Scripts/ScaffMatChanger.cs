using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaffMatChanger : MonoBehaviour
{
    public string currentMat;
    public Material WoodMat;
    public Material GlassMat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMat != "")
        {
            if (currentMat == "Wood")
            {
                gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = WoodMat;
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            else if (currentMat == "Glass")
            {
                gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = GlassMat;
                gameObject.GetComponent<MeshRenderer>().enabled = false;

            }
        }
        else
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

}
