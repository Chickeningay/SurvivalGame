using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EFSANESCRIPT : MonoBehaviour
{
    GameObject Player;
    bool stop;
    float multval;
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
            if (Input.GetKey(KeyCode.W))
            {
                multval = 1f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                multval = -1f;
            }
            gameObject.GetComponent<Animator>().SetFloat("mult",1f*multval);
        }
        else
        {
            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime - Mathf.Floor(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime) < 0.56f && gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime - Mathf.Floor(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime) > 0.53f)
            {

                gameObject.GetComponent<Animator>().SetFloat("mult", 0f * multval);
            }
            else if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime - Mathf.Floor(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime) < 0.75f&&gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime - Mathf.Floor(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime) > 0.56f)
            {
                gameObject.GetComponent<Animator>().SetFloat("mult", -2f);
            }
            else if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime - Mathf.Floor(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime) < 0.50f)
            {
                gameObject.GetComponent<Animator>().SetFloat("mult", 2f * multval);
            }
        }
    }
}
