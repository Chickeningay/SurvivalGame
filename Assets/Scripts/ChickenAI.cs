using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ChickenAI : MonoBehaviour
{
    float distance;
    public Vector3 startpos;
    public GameObject Interacter;
    
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.parent.gameObject.transform.position;
        transform.parent.gameObject.GetComponent<NavMeshAgent>().destination = new Vector3(startpos.x - Random.Range(0, 10), startpos.y, startpos.z - Random.Range(0, 10));
    }

    // Update is called once per frame
    void Update()
    {
        Interacter.transform.position=gameObject.GetComponent<NavMeshAgent>().transform.position;
        distance = Mathf.Sqrt((transform.parent.gameObject.transform.position.x -transform.parent.gameObject.GetComponent<NavMeshAgent>().destination.x) * (transform.parent.gameObject.transform.position.x - transform.parent.gameObject.GetComponent<NavMeshAgent>().destination.x) + (transform.parent.gameObject.transform.position.z - transform.parent.gameObject.GetComponent<NavMeshAgent>().destination.z) * (transform.parent.gameObject.transform.position.z - transform.parent.gameObject.GetComponent<NavMeshAgent>().destination.z));
        if (distance < 1)
        {
            transform.parent.gameObject.GetComponent<NavMeshAgent>().destination = new Vector3(startpos.x - Random.Range(0, 10), startpos.y, startpos.z - Random.Range(0, 10));
        }
       
    }
}
