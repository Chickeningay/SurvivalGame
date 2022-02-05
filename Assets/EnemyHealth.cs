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
    public GameObject Interactable;
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
            Destroy(gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>());
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
        else if( health!=maxHealth&&health>0)
        {
            HealthBarEmpty.active = true;
            HealthBar.active = true;
        }
        else if (health <= 0||health==0)
        {
            if (Interactable != null)
            {
                Interactable.active = false;
            }
            Invoke("healthbarDestruction", 2f);
        }
        HealthBarEmpty.transform.localScale = new Vector3(Mathf.Lerp(HealthBarEmpty.transform.localScale.x,Mathf.Abs(health - 100) * 10,Time.deltaTime*5), HealthBarEmpty.transform.localScale.y, HealthBarEmpty.transform.localScale.z);
    }
    void healthbarDestruction()
    {
        HealthBarEmpty.active = false;
        HealthBar.active = false;
    }
}
