using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnImpact : MonoBehaviour
{
    GameObject Sphere;
    GameObject ChildGameObject1;
    GameObject ChildGameObject2;
    GameObject ChildGameObject3;
    // Start is called before the first frame update
    void Start()
    {
        Sphere = gameObject.transform.GetChild(0).gameObject;
        ChildGameObject1 = Sphere.transform.GetChild(0).gameObject;
        ChildGameObject2 = Sphere.transform.GetChild(1).gameObject;
        ChildGameObject3 = Sphere.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player"&& other.gameObject.tag != "MainCamera" && other.gameObject.tag != "Ray" && other.gameObject.tag != "MedBox" && other.gameObject.tag != "AmmoBox" && other.gameObject.tag != "MeleeCollider" && other.gameObject.tag != "Interacter" && other.gameObject.tag != "PlayerPart" && other.gameObject.tag != "Interactable")
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            Sphere.GetComponent<SphereCollider>().enabled = true;
            ChildGameObject1.GetComponent<ParticleSystem>().Play();
            ChildGameObject2.GetComponent<ParticleSystem>().Play();
            ChildGameObject3.GetComponent<ParticleSystem>().Play();
            gameObject.GetComponent<AudioSource>().enabled = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(StartDeletion());
        }
        

    }
    IEnumerator StartDeletion()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
