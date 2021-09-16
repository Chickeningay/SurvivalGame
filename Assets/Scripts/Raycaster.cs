using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public GameObject MainCamera;
    public RaycastHit Hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(MainCamera.transform.position, MainCamera.transform.forward,Color.green);
        Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out Hit);
    }
}
