using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarLookat : MonoBehaviour
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
        gameObject.transform.LookAt(Player.transform);
    }
}
