using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class disableIfTextEmpty : MonoBehaviour
{
    public GameObject x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (x.GetComponent<Text>().text == "")
        {
            gameObject.GetComponent<RawImage>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<RawImage>().enabled = true;
        }
    }
}
