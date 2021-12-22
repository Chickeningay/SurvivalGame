using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decalfixer : MonoBehaviour
{
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
        if (other.gameObject.tag == "Decal")
        {
            Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), other);
        }
    }
}
