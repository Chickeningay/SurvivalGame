using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swayenabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<sway>().enabled = true;
    }
}
