using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnImpact : MonoBehaviour
{
    public GameObject Player;
    GameObject Sphere;
    GameObject ChildGameObject1;
    GameObject ChildGameObject2;
    GameObject ChildGameObject3;
    GameObject Impact;
    public GameObject ImpactPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Sphere = gameObject.transform.GetChild(0).gameObject;
        ChildGameObject1 = Sphere.transform.GetChild(0).gameObject;
        ChildGameObject2 = Sphere.transform.GetChild(1).gameObject;
        ChildGameObject3 = Sphere.transform.GetChild(2).gameObject;
        Impact = gameObject.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "MainCamera" && other.gameObject.tag != "Ray" && other.gameObject.tag != "MedBox" && other.gameObject.tag != "AmmoBox" && other.gameObject.tag != "Melee" && other.gameObject.tag != "Interacter" && other.gameObject.tag != "PlayerPart" && other.gameObject.tag != "Interactable")
        {
           
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            Sphere.GetComponent<SphereCollider>().enabled = true;
            ChildGameObject1.GetComponent<ParticleSystem>().Play();
            ChildGameObject2.GetComponent<ParticleSystem>().Play();
            ChildGameObject3.GetComponent<ParticleSystem>().Play();
            gameObject.GetComponent<AudioSource>().enabled = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            var normal = other.contacts[0].normal;
            float x=normal.x; float y=normal.y; float z=normal.z;
            print(normal);
            
            GameObject spawn = Instantiate(ImpactPrefab, other.contacts[0].point, new Quaternion(ImpactPrefab.transform.rotation.x, 45, ImpactPrefab.transform.rotation.z, ImpactPrefab.transform.rotation.w));
            
            if(Mathf.Max(Mathf.Abs(normal.x), Mathf.Abs(normal.y), Mathf.Abs(normal.z)) == Mathf.Abs(normal.x))
            {
                spawn.GetComponent<explosionManage>().x=true;
            }
            if (Mathf.Max(Mathf.Abs(normal.x), Mathf.Abs(normal.y), Mathf.Abs(normal.z)) == Mathf.Abs(normal.y))
            {
                spawn.GetComponent<explosionManage>().y = true;
            }
            if (Mathf.Max(Mathf.Abs(normal.x), Mathf.Abs(normal.y), Mathf.Abs(normal.z)) == Mathf.Abs(normal.z))
            {
                spawn.GetComponent<explosionManage>().z = true;

            }





            StartCoroutine(StartDeletion());
        }
        

    }
    IEnumerator StartDeletion()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
