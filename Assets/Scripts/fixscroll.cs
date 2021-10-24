using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fixscroll : MonoBehaviour
{
    public GameObject ScrollChild;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScrollChild.GetComponent<Scrollbar>().value = 0.999f;
        Destroy(this);
    }
}
