using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlaceAbleDoor : MonoBehaviour
{
    public AnimationClip openclip;
    public AnimationClip closeclip;
    Vector3 startpos;
    public bool changerot;
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
            if (changerot)
            {
                gameObject.transform.position = new Vector3(startpos.x - 0.6f, startpos.y, startpos.z );
            }
            else
            {
                gameObject.transform.position = new Vector3(startpos.x, startpos.y, startpos.z - 0.6f);
            }
            
        }
        else if (!gameObject.GetComponent<InteractDetector>().Interacted && gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(closeclip.name))
        {

            gameObject.transform.position = new Vector3(startpos.x, startpos.y, startpos.z);
        }
    }
}
