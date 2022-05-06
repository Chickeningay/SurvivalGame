using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAsPlayerModel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.layer == 7)
        {
            gameObject.layer = 10;
            foreach (Transform g in gameObject.transform.GetComponentsInChildren<Transform>())
            {
                g.gameObject.layer = 10;
                
            }
        }
    }
}
