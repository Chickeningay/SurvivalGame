using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeifnoammo : MonoBehaviour
{
    public GameObject AmmoHoldingParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AmmoHoldingParent.GetComponent<WeaponControl>() != null)
        {
            if (AmmoHoldingParent.GetComponent<WeaponControl>().CurrentAmmo <= 0)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            if (AmmoHoldingParent.GetComponent<WeaponControl>().CurrentAmmo > 0)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }
        else if (AmmoHoldingParent.GetComponent<grenadeScript>() != null && AmmoHoldingParent.layer != 3)
        {
            if (AmmoHoldingParent.GetComponent<grenadeScript>().removeBomb)
            {
                foreach (Transform g in gameObject.transform.GetComponentsInChildren<Transform>())
                {
                    g.gameObject.layer = 3;
                }
            }
            if (!AmmoHoldingParent.GetComponent<grenadeScript>().removeBomb)
            {
                foreach (Transform g in gameObject.transform.GetComponentsInChildren<Transform>())
                {
                    g.gameObject.layer = 7;
                }
            }
        }
    }
}
