using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    public GameObject cam;
    GameObject Sphere;
    GameObject ChildGameObject1;
    GameObject ChildGameObject2;
    GameObject ChildGameObject3;
    public bool HE;
    public float speed;
    public bool isshort;
    // Start is called before the first frame update
    void Start()

    {
        cam = GameObject.Find("PlayerView");
        Vector3 ThrowHigh = cam.transform.forward;
        if (isshort)
        {
            ThrowHigh = new Vector3(ThrowHigh.x, ThrowHigh.y + 0.5f, ThrowHigh.z);
        }
        else
        {
            ThrowHigh = new Vector3(ThrowHigh.x, ThrowHigh.y + 0.1f, ThrowHigh.z);
        }
       
        gameObject.GetComponent<Rigidbody>().AddForce(ThrowHigh * speed);
        Sphere = gameObject.transform.GetChild(0).gameObject;
        if (HE)
        {
            ChildGameObject1 = Sphere.transform.GetChild(0).gameObject;
            ChildGameObject2 = Sphere.transform.GetChild(1).gameObject;
            ChildGameObject3 = Sphere.transform.GetChild(2).gameObject;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "MainCamera" && other.gameObject.tag != "Ray" && other.gameObject.tag != "MedBox" && other.gameObject.tag != "AmmoBox")
        { 
            Sphere.GetComponent<SphereCollider>().enabled = true;
            if (HE)
            {
                ChildGameObject1.GetComponent<ParticleSystem>().Play();
                ChildGameObject2.GetComponent<ParticleSystem>().Play();
                ChildGameObject3.GetComponent<ParticleSystem>().Play();

            }
            
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<AudioSource>().enabled = true;
            
            StartCoroutine(Destruction());
        }
    }
    IEnumerator Destruction()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
    
}
