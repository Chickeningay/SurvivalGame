using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableifEmptyArsenal : MonoBehaviour
{
    public GameObject ItemCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ItemCamera.GetComponent<BetterWeaponSwitchForInventory>().CurrentWeaponObject == null)
        {
            gameObject.active = false;
        }
    }
}
