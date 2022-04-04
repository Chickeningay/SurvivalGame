using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public GameObject Menu1;
   
    public GameObject SettingsMenu;
    public GameObject HallofFameMenu;
    public GameObject vidbeforeHOFanim;
    bool rendered_HOF;
    public void MenuChange(int no)
    {
        Menu1.active = false;
        SettingsMenu.active = false;
        HallofFameMenu.active = false;
        
        if (no == 0)
        {
            Menu1.active = true;
        }
        else if (no == 1)
        {
            SettingsMenu.active = true;
        }
        else if (no == 2)
        {
            if (rendered_HOF == false)
            {
                rendered_HOF = true;
                vidbeforeHOFanim.active = true;
                Invoke("HOFanim", 10);
            }
            else
            {
                HallofFameMenu.active = true;
            }
        }
        else if (no == 3)
        {
            SceneManager.LoadScene(1);
        }
    }
    void HOFanim()
    {
        vidbeforeHOFanim.active = false;
        HallofFameMenu.active = true;
    }

}
