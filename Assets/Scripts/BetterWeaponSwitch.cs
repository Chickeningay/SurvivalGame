using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterWeaponSwitch : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Player;
    public AudioClip Switch_Audio;
    int childCount;
    public List<GameObject> ChildList;
    public bool RenewAmmo;
    public bool Grounded;
    public int currentWeapon=1;
    
    void Start()
    {
        
        childCount = gameObject.transform.childCount;
        for(int i=0; i < childCount; i++)
        {
            
            ChildList.Add(gameObject.transform.GetChild(i).gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (RenewAmmo)
        {
            if (childCount > 0&& ChildList[0].GetComponent<WeaponControl>()!=null)
            {
                ChildList[0].GetComponent<WeaponControl>().CurrentReserve = ChildList[0].GetComponent<WeaponControl>().MaxReserve;
            }
            else if (childCount > 0 && ChildList[0].GetComponent<WeaponControl>() == null)
            {
                ChildList[0].GetComponent<grenadeScript>().CurrentReserve = ChildList[0].GetComponent<grenadeScript>().MaxReserve;

            }
            if (childCount > 1 && ChildList[1].GetComponent<WeaponControl>() != null)
            {
                ChildList[1].GetComponent<WeaponControl>().CurrentReserve = ChildList[1].GetComponent<WeaponControl>().MaxReserve;
            }
            else if (childCount > 1 && ChildList[1].GetComponent<WeaponControl>() == null)
            {
                ChildList[1].GetComponent<grenadeScript>().CurrentReserve = ChildList[1].GetComponent<grenadeScript>().MaxReserve;

            }
            if (childCount > 2 && ChildList[2].GetComponent<WeaponControl>() != null)
            {
                ChildList[2].GetComponent<WeaponControl>().CurrentReserve = ChildList[2].GetComponent<WeaponControl>().MaxReserve;
            }
            else if (childCount > 2 && ChildList[2].GetComponent<WeaponControl>() == null)
            {
                ChildList[2].GetComponent<grenadeScript>().CurrentReserve = ChildList[2].GetComponent<grenadeScript>().MaxReserve;

            }
            if (childCount > 3 && ChildList[3].GetComponent<WeaponControl>() != null)
            {
                ChildList[3].GetComponent<WeaponControl>().CurrentReserve = ChildList[3].GetComponent<WeaponControl>().MaxReserve;
            }
            else if (childCount > 3 && ChildList[3].GetComponent<WeaponControl>() == null)
            {
                ChildList[3].GetComponent<grenadeScript>().CurrentReserve = ChildList[3].GetComponent<grenadeScript>().MaxReserve;

            }
            if (childCount > 4 && ChildList[4].GetComponent<WeaponControl>() != null)
            {
                ChildList[4].GetComponent<WeaponControl>().CurrentReserve = ChildList[4].GetComponent<WeaponControl>().MaxReserve;
            }
            else if(childCount > 4 && ChildList[4].GetComponent<WeaponControl>() == null)
            {
                ChildList[4].GetComponent<grenadeScript>().CurrentReserve = ChildList[4].GetComponent<grenadeScript>().MaxReserve;

            }
            if (childCount > 5 && ChildList[5].GetComponent<WeaponControl>() != null)
            {
                ChildList[5].GetComponent<WeaponControl>().CurrentReserve = ChildList[5].GetComponent<WeaponControl>().MaxReserve;
            }
            else if (childCount > 5 && ChildList[5].GetComponent<WeaponControl>() == null)
            {
                ChildList[5].GetComponent<grenadeScript>().CurrentReserve = ChildList[5].GetComponent<grenadeScript>().MaxReserve;

            }

            if (childCount > 6 && ChildList[6].GetComponent<WeaponControl>() != null)
            {
                ChildList[6].GetComponent<WeaponControl>().CurrentReserve = ChildList[6].GetComponent<WeaponControl>().MaxReserve;
            }
            else if (childCount > 6 && ChildList[6].GetComponent<WeaponControl>() == null)
            {
                ChildList[6].GetComponent<grenadeScript>().CurrentReserve = ChildList[6].GetComponent<grenadeScript>().MaxReserve;

            }
            if (childCount > 7 && ChildList[7].GetComponent<WeaponControl>() != null)
            {
                ChildList[7].GetComponent<WeaponControl>().CurrentReserve = ChildList[7].GetComponent<WeaponControl>().MaxReserve;
            }
            else if (childCount > 7 && ChildList[7].GetComponent<WeaponControl>() == null)
            {
                ChildList[7].GetComponent<grenadeScript>().CurrentReserve = ChildList[7].GetComponent<grenadeScript>().MaxReserve;

            }
            if (childCount > 8 && ChildList[8].GetComponent<WeaponControl>() != null)
            {
                ChildList[8].GetComponent<WeaponControl>().CurrentReserve = ChildList[8].GetComponent<WeaponControl>().MaxReserve;
            }
            else if (childCount > 8 && ChildList[8].GetComponent<WeaponControl>() == null)
            {
                ChildList[8].GetComponent<grenadeScript>().CurrentReserve = ChildList[8].GetComponent<grenadeScript>().MaxReserve;

            }
           
            RenewAmmo = false;

        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && childCount > 0 && currentWeapon != 1&&ChildList[0].active==true)
         {
             for(int i = 0; i < childCount; i++)
             {
                
                if (ChildList[i].GetComponent<WeaponControl>() != null) { ChildList[i].GetComponent<WeaponControl>().enabled = false; }
                else
                {
                    ChildList[i].GetComponent<grenadeScript>().enabled = false;

                }

                ChildList[i].layer =3;
                 foreach (Transform g in ChildList[i].transform.GetComponentsInChildren<Transform>())
                 {
                     g.gameObject.layer = 3;
                 }
             }
            if (ChildList[0].GetComponent<WeaponControl>() != null) { ChildList[0].transform.position = ChildList[0].GetComponent<WeaponControl>().startpos; ChildList[0].GetComponent<WeaponControl>().enabled = true; ChildList[0].GetComponent<WeaponControl>().ShootingCooldown = false; }
            else
            {
                ChildList[0].GetComponent<grenadeScript>().enabled = true;
            }
            if (ChildList[0].GetComponent<WeaponControl>() != null)
            {
                ChildList[0].GetComponent<Animator>().Play(ChildList[0].GetComponent<WeaponControl>().Switch_Clip.name);
            }
            else
            {
                ChildList[0].GetComponent<Animator>().Play(ChildList[0].GetComponent<grenadeScript>().Switch_Clip.name);

            }

            ChildList[0].layer = 0;
             foreach (Transform g in ChildList[0].transform.GetComponentsInChildren<Transform>())
             {
                 g.gameObject.layer = 0;
             }

             Player.GetComponent<AudioSource>().PlayOneShot(Switch_Audio);
            currentWeapon = 1;
            MainCamera.GetComponent<Camera>().fieldOfView = 60;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && childCount>1 && currentWeapon != 2 && ChildList[1].active == true)
         {
             for (int i = 0; i < childCount; i++)
             {
                if (ChildList[i].GetComponent<WeaponControl>() != null) { ChildList[i].GetComponent<WeaponControl>().enabled = false; }
                else
                {
                    ChildList[i].GetComponent<grenadeScript>().enabled = false;
                }
                 

                 ChildList[i].layer = 3;
                 foreach (Transform g in ChildList[i].transform.GetComponentsInChildren<Transform>())
                 {
                     g.gameObject.layer = 3;
                 }
             }
            if (ChildList[1].GetComponent<WeaponControl>() != null)
            {
                ChildList[1].GetComponent<Animator>().Play(ChildList[1].GetComponent<WeaponControl>().Switch_Clip.name);
            }
            else
            {
                ChildList[1].GetComponent<Animator>().Play(ChildList[1].GetComponent<grenadeScript>().Switch_Clip.name);

            }
            if (ChildList[1].GetComponent<WeaponControl>() != null) { ChildList[1].GetComponent<WeaponControl>().enabled = true; ChildList[1].GetComponent<WeaponControl>().ShootingCooldown = false; }
            else
            {
                ChildList[1].GetComponent<grenadeScript>().enabled = true;
            }
            ChildList[1].layer = 0;
             foreach (Transform g in ChildList[1].transform.GetComponentsInChildren<Transform>())
             {
                 g.gameObject.layer = 0;
             }

             Player.GetComponent<AudioSource>().PlayOneShot(Switch_Audio);
            currentWeapon = 2;
            MainCamera.GetComponent<Camera>().fieldOfView = 60;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && childCount > 2 && currentWeapon != 3 && ChildList[2].active == true)
        {
            if (ChildList[2].GetComponent<WeaponControl>() != null)
            {
                ChildList[2].GetComponent<Animator>().Play(ChildList[2].GetComponent<WeaponControl>().Switch_Clip.name);
            }
            else
            {
                ChildList[2].GetComponent<Animator>().Play(ChildList[2].GetComponent<grenadeScript>().Switch_Clip.name);

            }
            for (int i = 0; i < childCount; i++)
            {
                if (ChildList[i].GetComponent<WeaponControl>() != null) { ChildList[i].GetComponent<WeaponControl>().enabled = false; }
                else
                {
                    ChildList[i].GetComponent<grenadeScript>().enabled = false;
                }

                ChildList[i].layer = 3;
                foreach (Transform g in ChildList[i].transform.GetComponentsInChildren<Transform>())
                {
                    g.gameObject.layer = 3;
                }
            }
            if (ChildList[2].GetComponent<WeaponControl>() != null) { ChildList[2].GetComponent<WeaponControl>().enabled = true; ChildList[2].GetComponent<WeaponControl>().ShootingCooldown = false; }
            else
            {
                ChildList[2].GetComponent<grenadeScript>().enabled = true;
            }
            ChildList[2].layer = 0;
            foreach (Transform g in ChildList[2].transform.GetComponentsInChildren<Transform>())
            {
                g.gameObject.layer = 0;
            }

            Player.GetComponent<AudioSource>().PlayOneShot(Switch_Audio);
            currentWeapon = 3;
            MainCamera.GetComponent<Camera>().fieldOfView = 60;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)&& childCount > 3 && currentWeapon != 4 && ChildList[3].active == true)
        {
            if (ChildList[3].GetComponent<WeaponControl>() != null)
            {
                ChildList[3].GetComponent<Animator>().Play(ChildList[3].GetComponent<WeaponControl>().Switch_Clip.name);
            }
            else
            {
                ChildList[3].GetComponent<Animator>().Play(ChildList[3].GetComponent<grenadeScript>().Switch_Clip.name);

            }
            for (int i = 0; i < childCount; i++)
            {
                if (ChildList[i].GetComponent<WeaponControl>() != null) { ChildList[i].GetComponent<WeaponControl>().enabled = false; }
                else
                {
                    ChildList[i].GetComponent<grenadeScript>().enabled = false;
                }

                ChildList[i].layer = 3;
                foreach (Transform g in ChildList[i].transform.GetComponentsInChildren<Transform>())
                {
                    g.gameObject.layer = 3;
                }
            }
            if (ChildList[3].GetComponent<WeaponControl>() != null) { ChildList[3].GetComponent<WeaponControl>().enabled = true; ChildList[3].GetComponent<WeaponControl>().ShootingCooldown = false; }
            else
            {
                ChildList[3].GetComponent<grenadeScript>().enabled = true;
            }
            ChildList[3].layer = 0;
            foreach (Transform g in ChildList[3].transform.GetComponentsInChildren<Transform>())
            {
                g.gameObject.layer = 0;
            }

            Player.GetComponent<AudioSource>().PlayOneShot(Switch_Audio);
            currentWeapon = 4;
            MainCamera.GetComponent<Camera>().fieldOfView = 60;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && childCount > 4 && currentWeapon != 5 && ChildList[4].active == true)
        {
            if(ChildList[4].GetComponent<WeaponControl>() != null)
            {
                ChildList[4].GetComponent<Animator>().Play(ChildList[4].GetComponent<WeaponControl>().Switch_Clip.name);
            }
            else
            {
                ChildList[4].GetComponent<Animator>().Play(ChildList[4].GetComponent<grenadeScript>().Switch_Clip.name);
            }
           
            for (int i = 0; i < childCount; i++)
            {
                if(ChildList[i].GetComponent<WeaponControl>() != null) { ChildList[i].GetComponent<WeaponControl>().enabled = false; }
                else
                {
                    ChildList[i].GetComponent<grenadeScript>().enabled = false;
                }

                ChildList[i].layer = 3;
                foreach (Transform g in ChildList[i].transform.GetComponentsInChildren<Transform>())
                {
                    g.gameObject.layer = 3;
                }
            }
            if (ChildList[4].GetComponent<WeaponControl>() != null) { ChildList[4].GetComponent<WeaponControl>().enabled = true; ChildList[4].GetComponent<WeaponControl>().ShootingCooldown = false; }
            else
            {
                ChildList[4].GetComponent<grenadeScript>().enabled = true;
            }
            ChildList[4].layer = 0;
            foreach (Transform g in ChildList[4].transform.GetComponentsInChildren<Transform>())
            {
                g.gameObject.layer = 0;
            }

            Player.GetComponent<AudioSource>().PlayOneShot(Switch_Audio);
            currentWeapon = 5;
            MainCamera.GetComponent<Camera>().fieldOfView = 60;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) && childCount > 5 && currentWeapon != 6 && ChildList[5].active == true)
        {
            if(ChildList[5].GetComponent<WeaponControl>() != null)
            {
                ChildList[5].GetComponent<Animator>().Play(ChildList[5].GetComponent<WeaponControl>().Switch_Clip.name);
            }
            else
            {
                ChildList[5].GetComponent<Animator>().Play(ChildList[5].GetComponent<grenadeScript>().Switch_Clip.name);

            }
            for (int i = 0; i < childCount; i++)
            {
                if (ChildList[i].GetComponent<WeaponControl>() != null) { ChildList[i].GetComponent<WeaponControl>().enabled = false; }
                else
                {
                    ChildList[i].GetComponent<grenadeScript>().enabled = false;
                }

                ChildList[i].layer = 3;
                foreach (Transform g in ChildList[i].transform.GetComponentsInChildren<Transform>())
                {
                    g.gameObject.layer = 3;
                }
            }
            if (ChildList[5].GetComponent<WeaponControl>() != null) { ChildList[5].GetComponent<WeaponControl>().enabled = true; ChildList[5].GetComponent<WeaponControl>().ShootingCooldown = false; }
            else
            {
                ChildList[5].GetComponent<grenadeScript>().enabled = true;
            }
            ChildList[5].layer = 0;
            foreach (Transform g in ChildList[5].transform.GetComponentsInChildren<Transform>())
            {
                g.gameObject.layer = 0;
            }

            Player.GetComponent<AudioSource>().PlayOneShot(Switch_Audio);
            currentWeapon = 6;
            MainCamera.GetComponent<Camera>().fieldOfView = 60;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7) && childCount > 6 && currentWeapon != 7 && ChildList[6].active == true)
        {
            if (ChildList[6].GetComponent<WeaponControl>() != null)
            {
                ChildList[6].GetComponent<Animator>().Play(ChildList[6].GetComponent<WeaponControl>().Switch_Clip.name);
            }
            else
            {
                ChildList[6].GetComponent<Animator>().Play(ChildList[6].GetComponent<grenadeScript>().Switch_Clip.name);

            }
            for (int i = 0; i < childCount; i++)
            {
                if (ChildList[i].GetComponent<WeaponControl>() != null) { ChildList[i].GetComponent<WeaponControl>().enabled = false; }
                else
                {
                    ChildList[i].GetComponent<grenadeScript>().enabled = false;
                }

                ChildList[i].layer = 3;
                foreach (Transform g in ChildList[i].transform.GetComponentsInChildren<Transform>())
                {
                    g.gameObject.layer = 3;
                }
            }
            if (ChildList[6].GetComponent<WeaponControl>() != null) { ChildList[6].GetComponent<WeaponControl>().enabled = true; ChildList[6].GetComponent<WeaponControl>().ShootingCooldown = false; }
            else
            {
                ChildList[6].GetComponent<grenadeScript>().enabled = true;
            }
            ChildList[6].layer = 0;
            foreach (Transform g in ChildList[6].transform.GetComponentsInChildren<Transform>())
            {
                g.gameObject.layer = 0;
            }

            Player.GetComponent<AudioSource>().PlayOneShot(Switch_Audio);
            currentWeapon = 7;
            MainCamera.GetComponent<Camera>().fieldOfView = 60;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8) && childCount > 7 && currentWeapon != 8 && ChildList[7].active == true)
        {
            if (ChildList[7].GetComponent<WeaponControl>() != null)
            {
                ChildList[7].GetComponent<Animator>().Play(ChildList[7].GetComponent<WeaponControl>().Switch_Clip.name);
            }
            else
            {
                ChildList[7].GetComponent<Animator>().Play(ChildList[7].GetComponent<grenadeScript>().Switch_Clip.name);

            }
            for (int i = 0; i < childCount; i++)
            {
                if (ChildList[i].GetComponent<WeaponControl>() != null) { ChildList[i].GetComponent<WeaponControl>().enabled = false; }
                else
                {
                    ChildList[i].GetComponent<grenadeScript>().enabled = false;
                }
                ChildList[i].layer = 3;
                foreach (Transform g in ChildList[i].transform.GetComponentsInChildren<Transform>())
                {
                    g.gameObject.layer = 3;
                }
            }
            if (ChildList[7].GetComponent<WeaponControl>() != null) { ChildList[7].GetComponent<WeaponControl>().enabled = true; ChildList[7].GetComponent<WeaponControl>().ShootingCooldown = false; }
            else
            {
                ChildList[7].GetComponent<grenadeScript>().enabled = true;
            }
            
            ChildList[7].layer = 0;
            foreach (Transform g in ChildList[7].transform.GetComponentsInChildren<Transform>())
            {
                g.gameObject.layer = 0;
            }

            Player.GetComponent<AudioSource>().PlayOneShot(Switch_Audio);
            currentWeapon = 8;
            MainCamera.GetComponent<Camera>().fieldOfView = 60;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9) && childCount > 8&&currentWeapon!=9 && ChildList[8].active == true)
        {
            if (ChildList[8].GetComponent<WeaponControl>() != null)
            {
                ChildList[8].GetComponent<Animator>().Play(ChildList[8].GetComponent<WeaponControl>().Switch_Clip.name);
            }
            else
            {
                ChildList[8].GetComponent<Animator>().Play(ChildList[8].GetComponent<grenadeScript>().Switch_Clip.name);

            }
            for (int i = 0; i < childCount; i++)
            {
                if (ChildList[i].GetComponent<WeaponControl>() != null) { ChildList[i].GetComponent<WeaponControl>().enabled = false; }
                else
                {
                    ChildList[i].GetComponent<grenadeScript>().enabled = false;
                }

                ChildList[i].layer = 3;
                foreach (Transform g in ChildList[i].transform.GetComponentsInChildren<Transform>())
                {
                    g.gameObject.layer = 3;
                }
            }
            if (ChildList[8].GetComponent<WeaponControl>() != null) { ChildList[8].GetComponent<WeaponControl>().enabled = true; ChildList[8].GetComponent<WeaponControl>().ShootingCooldown = false; }
            else
            {
                ChildList[8].GetComponent<grenadeScript>().enabled = true;
            }
            
            ChildList[8].layer = 0;
            foreach (Transform g in ChildList[8].transform.GetComponentsInChildren<Transform>())
            {
                g.gameObject.layer = 0;
            }

            Player.GetComponent<AudioSource>().PlayOneShot(Switch_Audio);
            currentWeapon = 9;
            MainCamera.GetComponent<Camera>().fieldOfView = 60;
        }
    }
}
