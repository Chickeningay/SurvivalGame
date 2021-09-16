using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRaycast : MonoBehaviour
{
    public RaycastHit Hit;
    public GameObject Player;
    public GameObject DoorHolder;
    private void Update()
    {
        Hit = Player.GetComponent<Raycaster>().Hit;
        if (Hit.transform != null)
        {
            if (Hit.transform.gameObject.name == "ScaffholdingSpawn(Clone)")
            {
                DoorHolder.GetComponent<MeshRenderer>().enabled = true;
                DoorHolder.transform.position = new Vector3(Hit.transform.position.x, Hit.transform.position.y+2.3f, Hit.transform.position.z);
            }
            else
            {
                DoorHolder.GetComponent<MeshRenderer>().enabled = false;
            }
        }

    }
}