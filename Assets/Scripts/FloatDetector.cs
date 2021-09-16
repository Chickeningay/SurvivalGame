using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatDetector : MonoBehaviour
{
    public bool WaterisOnTop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            WaterisOnTop = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {

      
        WaterisOnTop = false;
        }
    }
}
