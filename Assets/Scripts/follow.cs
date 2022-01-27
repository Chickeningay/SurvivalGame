using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject x;
    Vector3 lastpos;
    Vector3 firstpos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        firstpos = x.gameObject.transform.position;
       lastpos = x.gameObject.transform.position;
        gameObject.transform.position = gameObject.transform.position - (firstpos - lastpos);
    }
    void LateUpdate()
    {
        gameObject.transform.position = gameObject.transform.position - (firstpos - lastpos);
    }
}
