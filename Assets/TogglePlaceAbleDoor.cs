using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlaceAbleDoor : MonoBehaviour
{
    public AnimationClip openclip;
    public AnimationClip closeclip;
    Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        startpos = gameObject.transform.position;
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
        if(gameObject.GetComponent<InteractDetector>().Interacted && gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(openclip.name))
        {
            gameObject.transform.position = new Vector3(startpos.x-0.5f, startpos.y, startpos.z-1);
        }
    }
}
