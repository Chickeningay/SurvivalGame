using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class textureScaler : MonoBehaviour
{
    Vector3 parentpos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        parentpos = transform.parent.position;
        
    }
    private void LateUpdate()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x+Mathf.Abs(parentpos.x-transform.parent.position.x), gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
