using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWire : MonoBehaviour
{
    public bool Interacted;
    public Vector3 LocationtoMove;
    public Vector3 Startpos;
    // Start is called before the first frame update
    void Start()
    {
        Startpos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Interacted = gameObject.GetComponent<InteractDetector>().Interacted;
        if (Interacted)
        {
            gameObject.transform.position = LocationtoMove;
        }
        else
        {
            gameObject.transform.position = Startpos;
        }
    }
}
