using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerRaycaster : MonoBehaviour
{
    public RaycastHit Hit;
    public GameObject Player;
    public GameObject HammerHolder;
    private void Update()
    {
        Hit = Player.GetComponent<Raycaster>().Hit;
        if (Hit.transform != null)
        {
            if (Hit.transform.gameObject.name == "ScaffholdingSpawn(Clone)")
            {
                HammerHolder.GetComponent<MeshRenderer>().enabled = true;
                HammerHolder.transform.position = Hit.transform.position;
            }
            else
            {
                HammerHolder.GetComponent<MeshRenderer>().enabled = false;
            }
        }
        
    }
}
