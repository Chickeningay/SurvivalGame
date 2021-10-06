using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeaponScript : MonoBehaviour
{
    public int id;
    int childCount;
    public List<GameObject> ChildList;
    GameObject Player;
    public bool ObeyInventory;
     GameObject Inventory;
    public bool AddAmmo;
    public int AddingAmmoCount;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("ItemCamera");
        Inventory= GameObject.Find("Inventory");
        childCount = Player.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {

            ChildList.Add(Player.transform.GetChild(i).gameObject);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (ObeyInventory)
            {
                StartAddingToInventory();
            }
            else
            {
                for (int i = 0; i < childCount; i++)
                {


                    if (i == id && ChildList[i].active == false)
                    {
                        ChildList[i].active = true;
                        Destroy(gameObject);
                    }
                }
            }
            
            
        }
    }
    void StartAddingToInventory()
    {
        foreach(Transform g in Inventory.GetComponentsInChildren<Transform>())
        {
            if (g.gameObject.GetComponent<IDHolder>() != null)
            {
                if (g.gameObject.GetComponent<IDHolder>().id ==0)
                {
                    g.gameObject.GetComponent<IDHolder>().id = id + 1;
                    if (AddAmmo)
                    {
                        g.gameObject.GetComponent<IDHolder>().currentAmmo = AddingAmmoCount;
                    }
                    break;
                }
            }
        }
        Destroy(gameObject);
    }
}
