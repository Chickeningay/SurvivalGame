using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject Ray;
    public bool Reload;
    public bool Action1;
    public bool Action2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload = true;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Action1 = true;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Action2 = true;
        }
    }
    
}
