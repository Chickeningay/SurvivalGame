using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionManage : MonoBehaviour
{
    public bool x;
    public bool y;
    public bool z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (x)
        {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, 90, gameObject.transform.eulerAngles.z);
        }
        if (y)
        {
            gameObject.transform.eulerAngles = new Vector3(90, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
        }
        if (z)
        {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, 90);
        }
    }
}
