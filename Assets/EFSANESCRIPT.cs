using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EFSANESCRIPT : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<MovementReworked>().moving)
        {
            gameObject.GetComponent<Animator>().speed = 1;
        }
        else
        {
            gameObject.GetComponent<Animator>().speed =0;
        }
    }
}
