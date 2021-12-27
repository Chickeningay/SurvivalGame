using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableInventory : MonoBehaviour
{
    public bool Enabled;
    public GameObject DisableRot1;
    public GameObject DisableRot2;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enabled = gameObject.GetComponent<RawImage>().enabled;
        if (Input.GetKeyDown(KeyCode.I))
        {
            foreach (Transform child in gameObject.transform.GetComponentsInChildren<Transform>())
            {
                Cursor.visible = gameObject.GetComponent<RawImage>().enabled;
                if (Cursor.visible)
                {
                    Cursor.lockState = CursorLockMode.None;
                }
                else { Cursor.lockState = CursorLockMode.Locked; }
                if (DisableRot1 != null)
                {
                    DisableRot1.GetComponent<Rotation>().enabled = !gameObject.GetComponent<RawImage>().enabled;
                }
                if (DisableRot2 != null)
                {
                    DisableRot2.GetComponent<Rotation>().enabled = !gameObject.GetComponent<RawImage>().enabled;
                }
                
                if (child.gameObject.GetComponent<RawImage>() != null)
                {
                    child.gameObject.GetComponent<RawImage>().enabled = !child.gameObject.GetComponent<RawImage>().enabled;
                }
                if (child.gameObject.GetComponent<Image>() != null)
                {
                    child.gameObject.GetComponent<Image>().enabled = !child.gameObject.GetComponent<Image>().enabled;

                }
            }
        }
    }
}
