using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaffHoldRaycaster : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Scaff;
    bool onground;
    Vector3 hit_transform;
    bool overridePos;
    float newx;
    float newy;
    float newz;
    public RaycastHit Hit;
    public bool block;
    void Update()
    {
        Hit = MainCamera.transform.parent.gameObject.GetComponent<Raycaster>().Hit;    
        onground = false;
        if (Hit.transform != null)
        {
            if (Hit.transform.gameObject.tag != "Player" || Hit.transform.gameObject.tag != "PlayerPart" || Hit.transform.gameObject.tag != "MainCamera" || Hit.transform.gameObject.tag != "Interacter")
            {

                if (Hit.transform.gameObject.name == "ScaffholdingSpawn(Clone)")
                {
                    overridePos = true;

                }

                else if (Hit.transform.gameObject.name != "ScaffholdingSpawn(Clone)")
                {
                    onground = true;
                }
                else
                {
                    onground = false;
                }
                hit_transform = Hit.point;
            }
        }
       Rollx();
       Rolly();
       Rollz();
       
        if (!overridePos)
        {
            if (!onground)
            {
                Scaff.transform.position = new Vector3(newx, newy, newz);

            }
            else
            {
                Scaff.transform.position = new Vector3(newx, newy + 2f, newz);
            }
            if (Scaff.transform.position == Hit.transform.position)
            {
                block = true;
            }
            else
            {
                block = false;
            }
        }
       
        else
        {
            overridePos = false;
            if (hit_transform.x > Hit.transform.position.x)
            {
                if (Mathf.Abs(hit_transform.x - Hit.transform.position.x) > Mathf.Abs(hit_transform.y - Hit.transform.position.y) && Mathf.Abs(hit_transform.x - Hit.transform.position.x) > Mathf.Abs(hit_transform.z - Hit.transform.position.z))
                {
                    Scaff.transform.position = new Vector3(Hit.transform.position.x + 1.5f, Hit.transform.position.y, Hit.transform.position.z);
                }

            }
            if (hit_transform.x < Hit.transform.position.x)
            {
                if (Mathf.Abs(hit_transform.x - Hit.transform.position.x) > Mathf.Abs(hit_transform.y - Hit.transform.position.y) && Mathf.Abs(hit_transform.x - Hit.transform.position.x) > Mathf.Abs(hit_transform.z - Hit.transform.position.z))
                {
                    Scaff.transform.position = new Vector3(Hit.transform.position.x - 1.5f, Hit.transform.position.y, Hit.transform.position.z);
                }
            }
            if (hit_transform.y > Hit.transform.position.y)
            {
                if (Mathf.Abs(hit_transform.y - Hit.transform.position.y) > Mathf.Abs(hit_transform.z - Hit.transform.position.z) && Mathf.Abs(hit_transform.y - Hit.transform.position.y) > Mathf.Abs(hit_transform.z - Hit.transform.position.z))
                {
                    Scaff.transform.position = new Vector3(Hit.transform.position.x, Hit.transform.position.y + 1.5f, Hit.transform.position.z);
                }
            }
            if (hit_transform.y < Hit.transform.position.y)
            {
                if (Mathf.Abs(hit_transform.y - Hit.transform.position.y) > Mathf.Abs(hit_transform.z - Hit.transform.position.z) && Mathf.Abs(hit_transform.y - Hit.transform.position.y) > Mathf.Abs(hit_transform.z - Hit.transform.position.z))
                {
                    Scaff.transform.position = new Vector3(Hit.transform.position.x, Hit.transform.position.y - 1.5f, Hit.transform.position.z);
                }
            }
            if (hit_transform.z > Hit.transform.position.z)
            {
                if (Mathf.Abs(hit_transform.z - Hit.transform.position.z) > Mathf.Abs(hit_transform.y - Hit.transform.position.y) && Mathf.Abs(hit_transform.z - Hit.transform.position.z) > Mathf.Abs(hit_transform.x - Hit.transform.position.x))
                {
                    Scaff.transform.position = new Vector3(Hit.transform.position.x, Hit.transform.position.y, Hit.transform.position.z + 1.5f);
                }
            }
            if (hit_transform.z < Hit.transform.position.z)
            {
                if (Mathf.Abs(hit_transform.z - Hit.transform.position.z) > Mathf.Abs(hit_transform.y - Hit.transform.position.y) && Mathf.Abs(hit_transform.z - Hit.transform.position.z) > Mathf.Abs(hit_transform.x - Hit.transform.position.x))
                {
                    Scaff.transform.position = new Vector3(Hit.transform.position.x, Hit.transform.position.y, Hit.transform.position.z - 1.5f);
                }
            }
        }
    }
    void Rollx()
    {
        float stopper1int;
        float stopper2int;
        bool stopper1 = true;
        bool stopper2 = true;
        float numberofdown = 0;
        float numberofup =0;
        stopper1int = (int)hit_transform.x;
        stopper2int = (int)hit_transform.x;

        if (hit_transform.x % 1.5f != 0&& (int)hit_transform.x % 3f != 0)
        {

            while (stopper1)
            {
                stopper1int -= 0.5f;
                numberofdown++;
                if (stopper1int % 1.5f == 0)
                {
                    stopper1 = false;
                }
               
            }
            while (stopper2)
            {
                stopper2int += 0.5f;
                numberofup++;
                if (stopper2int % 1.5f == 0)
                {
                    stopper2 = false;
                }
                
            }
            if (numberofdown > numberofup)
            {
               newx =(int)hit_transform.x + numberofup/2 ;

            }
            else
            {
                newx = (int)hit_transform.x - numberofdown/2;
               
            }
            
        }

        else
        {
            newx = (int)hit_transform.x;
        }
    }
    void Rolly()
    {
        float stopper1int;
        float stopper2int;
        bool stopper1 = true;
        bool stopper2 = true;
        float numberofdown = 0;
        float numberofup = 0;
        stopper1int = (int)hit_transform.y;
        stopper2int = (int)hit_transform.y;

        if (hit_transform.y % 1.5f != 0)
        {

            while (stopper1)
            {
                stopper1int-=0.5f;
                numberofdown++;
                if (stopper1int % 1.5f == 0)
                {
                    stopper1 = false;
                }
                
            }
            while (stopper2)
            {
                stopper2int+= 0.5f;
                numberofup++;
                if (stopper2int % 1.5f == 0)
                {
                    stopper2 = false;
                }
                
            }
            if (numberofdown > numberofup)
            {
                newy = (int)hit_transform.y + (numberofup /2) ;
               
            }
            else
            {
                newy = (int)hit_transform.y - (numberofdown /2) ;
               
            }
        }
        else
        {
            newy = (int)hit_transform.y;
        }
    }
    void Rollz()
    {
        float stopper1int;
        float stopper2int;
        bool stopper1 = true;
        bool stopper2 = true;
        float numberofdown = 0;
        float numberofup = 0;
        stopper1int = (int)hit_transform.z;
        stopper2int = (int)hit_transform.z;

        if (hit_transform.z % 1.5f != 0&& (int)hit_transform.z % 3f != 0)
        {

            while (stopper1)
            {
                stopper1int-=0.5f;
                numberofdown++;
                if (stopper1int % 1.5f == 0 || stopper1int % 3f == 0)
                {
                    stopper1 = false;
                }
               
            }
            while (stopper2)
            {
                stopper2int+=0.5f;
                numberofup++;
                if (stopper2int % 1.5f == 0|| stopper2int % 3f == 0)
                {
                    stopper2 = false;
                }
               
            }
            if (numberofdown > numberofup)
            {
                newz = (int)hit_transform.z + (numberofup/2) ;
               
            }
            else
            {
                newz = (int)hit_transform.z - (numberofdown /2) ;
                
            }
            
        }
        else
        {
            newz = (int)hit_transform.z;
        }
    }
}
