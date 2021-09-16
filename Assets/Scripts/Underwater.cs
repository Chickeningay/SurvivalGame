using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underwater : MonoBehaviour
{
    public bool CameraInWater;
    public GameObject Player;
    bool drowning;
    bool outofwater;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (drowning&&!outofwater) {
            if (Player.GetComponent<HealthScript>().Armour <= 0)
            {
                Player.GetComponent<HealthScript>().Health -= 1;
            }
            else
            {
                Player.GetComponent<HealthScript>().Armour -= 1;
            }
        }
        
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            StartCoroutine(StartDrowning());
        }
    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.layer == 6)
        {
            CameraInWater = true;
        }
        
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.layer == 6)
        {
            CameraInWater = false;
            StopCoroutine(StartDrowning());
            outofwater = true;
        }

    }
    IEnumerator StartDrowning()
    {

        yield return new WaitForSeconds(10f);
        if (!outofwater)
        {
            drowning = true;
            outofwater = false;
        }
        
    }
}
