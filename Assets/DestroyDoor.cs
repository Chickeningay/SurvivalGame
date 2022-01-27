using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDoor : MonoBehaviour
{
    public GameObject Destroy_Particles;
    public GameObject SecondRenderer;
    public GameObject OwnerScaff;
    bool stop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!OwnerScaff.GetComponent<MeshRenderer>().enabled && !stop)
        {
            Destroy_Particles.GetComponent<ParticleSystem>().Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            if (SecondRenderer != null)
            {
                SecondRenderer.GetComponent<MeshRenderer>().enabled = false;
            }
            gameObject.GetComponent<AudioSource>().enabled = true;
            stop = true;
        }
        if (gameObject.GetComponent<HitDetection>().hit&&!stop)
        {
            Destroy_Particles.GetComponent<ParticleSystem>().Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            if (SecondRenderer != null)
            {
                SecondRenderer.GetComponent<MeshRenderer>().enabled = false;
            }
            gameObject.GetComponent<AudioSource>().enabled = true;
            stop = true;
        }
    }
}
