using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotAI : MonoBehaviour
{
    bool AIenabled;
    public GameObject Player;
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
            
            gameObject.transform.GetChild(0).transform.eulerAngles = new Vector3(gameObject.transform.GetChild(0).transform.eulerAngles.x, gameObject.transform.GetChild(0).transform.eulerAngles.y, gameObject.transform.GetChild(0).transform.eulerAngles.z - 1f);
           gameObject.transform.GetChild(1).transform.eulerAngles = new Vector3(-90, gameObject.transform.GetChild(1).transform.eulerAngles.y, gameObject.transform.GetChild(1).transform.eulerAngles.z );
           /* var qTo = Quaternion.LookRotation(Player.transform.position - gameObject.transform.GetChild(1).transform.position);
            qTo = Quaternion.Slerp(gameObject.transform.GetChild(1).transform.rotation, qTo, 100 * Time.deltaTime);
            gameObject.transform.GetChild(1).GetComponent<Rigidbody>().MoveRotation(qTo);*/
            
           
        }
    }
}
