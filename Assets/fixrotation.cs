using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixrotation : MonoBehaviour
{
    public float wantedy;
    public float wantedx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localEulerAngles = new Vector3(wantedx, wantedy, gameObject.transform.localEulerAngles.z);
    }
}
