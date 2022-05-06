using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ChickenAI : MonoBehaviour
{
    GameObject Player;
    float distance;
    public Vector3 startpos;
    public GameObject Interacter;
    public bool waitrot;
    float startspeed;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
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
        if (Player.GetComponent<MovementReworked>().moving)
        {
            gameObject.GetComponent<Animator>().speed = 1;
        }
        else
        {
            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime - Mathf.Floor(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime) < 0.56f && gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime - Mathf.Floor(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime) > 0.53f)
            {
                gameObject.GetComponent<Animator>().speed = 0;
            }
            else if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime - Mathf.Floor(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime) < 0.6f)
            {
                gameObject.GetComponent<Animator>().speed = 2f;
            }
            else if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime - Mathf.Floor(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime) < 0.95f)
            {
                gameObject.GetComponent<Animator>().speed = 2f;
            }
        }
            
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<Animator>().speed = 1;
        transform.parent.gameObject.GetComponent<NavMeshAgent>().destination = new Vector3(startpos.x - Random.Range(0, 20), startpos.y, startpos.z - Random.Range(0, 20));
    }
}
