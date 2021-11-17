using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockplacement : MonoBehaviour
{
    public bool notplacable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.name== "ScaffholdingSpawn(Clone)")
        {
            if (collision.gameObject.transform.position == gameObject.transform.position)
            {
                notplacable = true;
            }
            else
            {
                notplacable = false;
            }
        }
    }
}
