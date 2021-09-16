using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public int Health=100;
    int maxHealth = 100;
    public int Armour = 100;
    int maxArmour = 100;
    public GameObject HealthText;
    public GameObject ArmourText;
    public bool Drowning;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.GetComponent<Text>().text = Health.ToString();
        ArmourText.GetComponent<Text>().text = Armour.ToString();
    }
    
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "MedBox")
        {
            Health = maxHealth;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Armour")
        {
            Armour = maxArmour;
            Destroy(other.gameObject);
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Spike"|| other.gameObject.tag == "Fire"||other.gameObject.tag=="PowerSource") 
        {
            if (Armour <= 0)
            {
                Health -= 1;
            }
            else
            {
                Armour -= 1;    
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        
    }
    
}
