using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ChickenAI : MonoBehaviour
{
    float distance;
    public Vector3 startpos;
    public GameObject Interacter;
    public bool waitrot;
    float startspeed;
    // Start is called before the first frame update
    void Start()
    {
        startspeed = transform.parent.gameObject.GetComponent<NavMeshAgent>().speed;
        startpos = transform.parent.gameObject.transform.position;
        transform.parent.gameObject.GetComponent<NavMeshAgent>().destination = new Vector3(startpos.x - Random.Range(0, 20), startpos.y, startpos.z - Random.Range(0, 20));
    }

    // Update is called once per frame
    void Update()
    {
        distance = Mathf.Sqrt((transform.parent.gameObject.transform.position.x - transform.parent.gameObject.GetComponent<NavMeshAgent>().destination.x) * (transform.parent.gameObject.transform.position.x - transform.parent.gameObject.GetComponent<NavMeshAgent>().destination.x) + (transform.parent.gameObject.transform.position.z - transform.parent.gameObject.GetComponent<NavMeshAgent>().destination.z) * (transform.parent.gameObject.transform.position.z - transform.parent.gameObject.GetComponent<NavMeshAgent>().destination.z));

        Interacter.transform.position=gameObject.GetComponent<NavMeshAgent>().transform.position;
        if (distance ==0)
        {
            
            if (waitrot)
            {
                StartCoroutine(waitforturn());
            }
            else
            {
                transform.parent.gameObject.GetComponent<NavMeshAgent>().destination = new Vector3(startpos.x - Random.Range(0, 20), startpos.y, startpos.z - Random.Range(0, 20));
            }
        }
       
    }
    IEnumerator waitforturn()
    {
        
        gameObject.GetComponent<Animator>().speed = 0;
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<Animator>().speed = 1;
        transform.parent.gameObject.GetComponent<NavMeshAgent>().destination = new Vector3(startpos.x - Random.Range(0, 20), startpos.y, startpos.z - Random.Range(0, 20));
    }
}
