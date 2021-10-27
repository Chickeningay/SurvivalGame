using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItself : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(null);
        StartCoroutine(destroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator destroy()
    {
        if (gameObject.GetComponent<ExplodeOnImpact>() != null)
        {
            yield return new WaitForSeconds(10f);
        }
        else
        {
            yield return new WaitForSeconds(1f);
        }
        Destroy(gameObject);
    }
}
