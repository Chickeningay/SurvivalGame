using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlaceAbleDoor : MonoBehaviour
{
    public AnimationClip openclip;
    public AnimationClip closeclip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<InteractDetector>().Interacted && !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(openclip.name))
        {
            gameObject.GetComponent<Animator>().Play(openclip.name);
        }
        else if(!gameObject.GetComponent<InteractDetector>().Interacted && gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(openclip.name))
        {
            gameObject.GetComponent<Animator>().Play(closeclip.name);
        }
    }
}
