using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sway : MonoBehaviour
{
    public float intensity;
    public float smooth;
    public Quaternion origin_rotation;

    private void Start()
    {
        if (gameObject.GetComponent<ItemScript>() != null)
        {
            if (gameObject.GetComponent<ItemScript>().ScaffHolding)
            {
                origin_rotation = gameObject.GetComponent<ItemScript>().startrot;
            }
            else
            {
                origin_rotation = gameObject.transform.localRotation;
            }
        }
        else
        {
            origin_rotation = gameObject.transform.localRotation;
        }
        
    }
    
   
    void Update()
    {
        float t_x_mouse = Input.GetAxis("Mouse X");
        float t_y_mouse = Input.GetAxis("Mouse Y");
        Quaternion t_x_adj = Quaternion.AngleAxis(-intensity * t_x_mouse, Vector3.up);
        Quaternion t_y_adj = Quaternion.AngleAxis(intensity *2 * t_y_mouse, Vector3.right);
        Quaternion target_rotation = origin_rotation * t_x_adj * t_y_adj;

        
        transform.localRotation = Quaternion.Lerp(transform.localRotation, target_rotation, Time.deltaTime * smooth);
    }
}
