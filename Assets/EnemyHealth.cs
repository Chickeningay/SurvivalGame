using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject DeathAnimHolder;
    public GameObject HealthBarEmpty;
    public GameObject HealthBar;
    public AnimationClip DeathClip;
    public int health=100;
    public int maxHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<HitDetection>() != null)
        {
            if (gameObject.GetComponent<HitDetection>().hit)
            {
                gameObject.GetComponent<HitDetection>().hit = false;
                health -= 5;
            }
        }
        if (health < 0)
        {
            DeathAnimHolder.GetComponent<Animator>().enabled = true;
            DeathAnimHolder.GetComponent<Animator>().Play(DeathClip.name);
            if (gameObject.GetComponent<FollowerAI>() != null)
            {
                gameObject.GetComponent<FollowerAI>().enabled = false;
            }
        }
        if (health == maxHealth)
        {
            HealthBarEmpty.active = false;
            HealthBar.active = false;
        }
        else
        {
            HealthBarEmpty.active = true;
            HealthBar.active = true;
        }
        HealthBarEmpty.transform.localScale = new Vector3(Mathf.Lerp(HealthBarEmpty.transform.localScale.x,Mathf.Abs(health - 100) * 10,Time.deltaTime*5), HealthBarEmpty.transform.localScale.y, HealthBarEmpty.transform.localScale.z);
    }
}
