using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaffMatChanger : MonoBehaviour
{
    public string currentMat;
    public Material WoodMat;
    public Material GlassMat;
    bool stopprocess;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopprocess) {
            if (gameObject.GetComponent<HitDetection>().hit)
            {
                gameObject.GetComponent<HitDetection>().hit = false;
                gameObject.GetComponent<HitDetection>().enabled = false;
                gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
                gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;

                currentMat = "";
                gameObject.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().Play();
                StartCoroutine(StartDeletion());
                stopprocess = true;
            }
            else if (currentMat != "")
            {
                if (currentMat == "Wood")
                {
                    gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                    gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = WoodMat;
                    gameObject.transform.GetChild(1).GetComponent<ParticleSystemRenderer>().material = WoodMat;
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
                else if (currentMat == "Glass")
                {
                    gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                    gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = GlassMat;
                    gameObject.transform.GetChild(1).GetComponent<ParticleSystemRenderer>().material = GlassMat;
                    gameObject.GetComponent<MeshRenderer>().enabled = false;

                }
            }
            else if (currentMat == "" && !gameObject.GetComponent<HitDetection>().hit)
            {
                gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }
        
    }
    IEnumerator StartDeletion()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
