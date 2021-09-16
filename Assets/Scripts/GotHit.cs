using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotHit : MonoBehaviour
{
    public GameObject Parent;
    public bool firstEnt;
    public bool hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            StartCoroutine(StartHitSequence());
            hit = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Explosion")
        {
            hit = true;
        }
        if(other.gameObject.tag == "Melee")
        {
            hit = true;
        }
    }

    IEnumerator StartHitSequence()
    {
        firstEnt = true;
        Parent.gameObject.GetComponent<Animator>().Play("HitAnim");
        yield return new WaitForSeconds(0.2f);
        firstEnt = false;
    }
}
