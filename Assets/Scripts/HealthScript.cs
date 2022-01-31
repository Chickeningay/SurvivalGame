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
    public GameObject HealthBar;
    public GameObject HealthBar2;
    public GameObject ArmourBar;
    public GameObject ArmourBar2;
    public GameObject ArmourBar3;
    public bool Drowning;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*HealthBar.transform.localScale = new Vector3(Health*0.06f,HealthBar.transform.localScale.y,HealthBar.transform.localScale.z);
        ArmourBar.transform.localScale = new Vector3(Armour * 0.06f, ArmourBar.transform.localScale.y, ArmourBar.transform.localScale.z);*/
        HealthBar.transform.localPosition = new Vector3(-1203+ Health * 5f, HealthBar.transform.localPosition.y, HealthBar.transform.localPosition.z);
        HealthBar2.transform.localPosition = new Vector3( Mathf.Abs(Health - 100), HealthBar2.transform.localPosition.y, HealthBar2.transform.localPosition.z);
        ArmourBar.transform.localPosition = new Vector3(-1203 + Armour *5f, ArmourBar.transform.localPosition.y, ArmourBar.transform.localPosition.z);
        ArmourBar2.transform.localPosition = new Vector3( Mathf.Abs(Armour-100), ArmourBar2.transform.localPosition.y, ArmourBar2.transform.localPosition.z);
        ArmourBar3.transform.localPosition = new Vector3(Mathf.Abs(Armour - 100), ArmourBar3.transform.localPosition.y, ArmourBar3.transform.localPosition.z);
        //HealthText.GetComponent<Text>().text = Health.ToString();
        //ArmourText.GetComponent<Text>().text = Armour.ToString();
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
