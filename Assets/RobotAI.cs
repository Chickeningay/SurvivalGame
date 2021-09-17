using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotAI : MonoBehaviour
{
    bool AIenabled;
    public GameObject Player;
    public AnimationClip MovementClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 trans = gameObject.transform.GetChild(1).position;
        AIenabled = gameObject.GetComponent<InteractDetector>().Interacted;
        if (AIenabled)
        {
            gameObject.GetComponent<NavMeshAgent>().destination = Player.transform.position;
            gameObject.transform.GetChild(1).transform.LookAt(Player.transform);
            
           
           gameObject.transform.GetChild(1).transform.eulerAngles = new Vector3(0, gameObject.transform.GetChild(1).transform.eulerAngles.y-90f, 0);
            gameObject.transform.GetChild(1).GetComponent<Animator>().enabled = true;
            gameObject.transform.GetChild(1).GetComponent<Animator>().Play(MovementClip.name);



        }
    }
}
