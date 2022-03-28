using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public GameObject Menu1;
    public GameObject StartMenu;
    public GameObject SettingsMenu;
    public GameObject HallofFameMenu;
    public GameObject vidbeforeHOFanim;
    bool rendered_HOF;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MenuChange(int no)
    {
        Menu1.active = false;
        SettingsMenu.active = false;
        HallofFameMenu.active = false;
        StartMenu.active = false;
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
                Invoke("HOFanim", 12);
            }
            else
            {
                HallofFameMenu.active = true;
            }
        }
        else if (no == 3)
        {
            StartMenu.active = true;
        }
    }
    void HOFanim()
    {
        vidbeforeHOFanim.active = false;
        HallofFameMenu.active = true;
    }
    public void SceneChanger(int no)
    {
        SceneManager.LoadScene(no);
    }
}
