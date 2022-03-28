using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensAndAudManager : MonoBehaviour
{
    public float AudioValue;
    public float SensValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void changeAUD(float val)
    {
        AudioValue = val;
    }
    public void changeSENS(float val)
    {
        SensValue = val;
    }
    public void apply(int what)
    {
        if (what == 0)
        {
            PlayerPrefs.SetFloat("AudioScale", AudioValue);
        }
        else if (what == 1)
        {
            PlayerPrefs.SetFloat("SensScale", SensValue);
        }
    }
}
