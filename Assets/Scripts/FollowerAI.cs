using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowerAI : MonoBehaviour
{
    bool AIenabled;
    public GameObject Player;
    public AnimationClip MovementClip;
    public GameObject Head;
    Vector3 startrot;
    // Start is called before the first frame update
    void Start()
    {
        startrot = gameObject.transform.GetChild(1).transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 trans = gameObject.transform.GetChild(1).position;
        AIenabled = gameObject.GetComponent<InteractDetector>().Interacted;
        if (AIenabled)
        {
            gameObject.GetComponent<NavMeshAgent>().destination = Player.transform.position;
            //Head.transform.LookAt(Player.transform);


            // gameObject.transform.GetChild(1).transform.eulerAngles = new Vector3(0, startrot.y+90, 0);
            Vector3 lTargetDir = Player.transform.position - gameObject.transform.GetChild(1).transform.position;
            lTargetDir.y = 0.0f;
            gameObject.transform.GetChild(1).transform.rotation = Quaternion.RotateTowards(new Quaternion(gameObject.transform.GetChild(1).transform.rotation.x, gameObject.transform.GetChild(1).transform.rotation.y, gameObject.transform.GetChild(1).transform.rotation.z, gameObject.transform.GetChild(1).transform.rotation.w), Quaternion.LookRotation(new Vector3(lTargetDir.x, lTargetDir.y, lTargetDir.z )), Time.time * 2);
            Head.GetComponent<Animator>().enabled = true;
            Head.GetComponent<Animator>().Play(MovementClip.name);
            

        }
    }
}
