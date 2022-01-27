using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x + 0.01f, gameObject.transform.eulerAngles.y + 0.01f, gameObject.transform.eulerAngles.z + 0.01f);
    }
}
