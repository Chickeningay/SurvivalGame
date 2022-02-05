using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowerAI : MonoBehaviour
{
    bool AIenabled;
    public GameObject Player;
    public AnimationClip MovementClip;
    public AnimationClip DeathClip;
    public GameObject Head;
    
    Vector3 startrot;
    bool death_start;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        startrot = gameObject.transform.GetChild(1).transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 trans = gameObject.transform.GetChild(1).position;
        /*if (AIenabled)
        {
            distance = Mathf.Sqrt((transform.gameObject.transform.position.x - transform.gameObject.GetComponent<NavMeshAgent>().destination.x) * (transform.gameObject.transform.position.x - transform.gameObject.GetComponent<NavMeshAgent>().destination.x) + (transform.gameObject.transform.position.z - transform.gameObject.GetComponent<NavMeshAgent>().destination.z) * (transform.gameObject.transform.position.z - transform.gameObject.GetComponent<NavMeshAgent>().destination.z));
            if (distance < 1)
            {  }
        }*/
            AIenabled = gameObject.GetComponent<InteractDetector>().Interacted;
        if (AIenabled&&!death_start)
        {
            gameObject.GetComponent<NavMeshAgent>().destination = Player.transform.position;
            //Head.transform.LookAt(Player.transform);

            
            
            // gameObject.transform.GetChild(1).transform.eulerAngles = new Vector3(0, startrot.y+90, 0);
            Vector3 lTargetDir = gameObject.GetComponent<NavMeshAgent>().steeringTarget - gameObject.transform.GetChild(1).transform.position;
            lTargetDir.y = 0.0f;
            gameObject.transform.GetChild(1).transform.rotation = Quaternion.RotateTowards(new Quaternion(gameObject.transform.GetChild(1).transform.rotation.x, gameObject.transform.GetChild(1).transform.rotation.y, gameObject.transform.GetChild(1).transform.rotation.z, gameObject.transform.GetChild(1).transform.rotation.w), Quaternion.LookRotation(new Vector3(lTargetDir.x, lTargetDir.y, lTargetDir.z )), Time.time);
            Head.GetComponent<Animator>().enabled = true;
            Head.GetComponent<Animator>().Play(MovementClip.name);
            

        }
        else if (!AIenabled && !death_start)
        {
            Head.GetComponent<Animator>().enabled = false;
        }
        /*if (gameObject.GetComponent<HitDetection>().hit)
        {
            death_start = true;
            Head.GetComponent<Animator>().enabled = true;
            Head.GetComponent<Animator>().Play(DeathClip.name);
        }*/

    }
    private void LateUpdate()
    {
        
    }
}
