using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IDtoDisplay : MonoBehaviour
{
    public int id;
    public GameObject Parent;
    public Texture id_1;
    public Texture id_2;
    public Texture id_3;
    public Texture id_4;
    public Texture id_5;
    public Texture id_6;
    public Texture id_7;
    public Texture id_8;
    public Texture id_9;
    public Texture id_10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Parent != null && !Parent.GetComponent<RawImage>().enabled)
        {
            gameObject.GetComponent<RawImage>().enabled = false;
        }
        
           if (Parent != null&&Parent.GetComponent<RawImage>().enabled)
        {

            id = Parent.GetComponent<IDHolder>().id;
            if (id == 0)
            {
                gameObject.GetComponent<RawImage>().texture = null;
                gameObject.GetComponent<RawImage>().enabled = false;
            }
            else if (id == 1)
            {
                gameObject.GetComponent<RawImage>().texture = id_1;
                gameObject.GetComponent<RawImage>().enabled = true;
            }
            else if (id == 2)
            {
                gameObject.GetComponent<RawImage>().texture = id_2;
                gameObject.GetComponent<RawImage>().enabled = true;
            }

            else if (id == 3)
            {
                gameObject.GetComponent<RawImage>().texture = id_3;
                gameObject.GetComponent<RawImage>().enabled = true;
            }
            else if (id == 4)
            {
                gameObject.GetComponent<RawImage>().texture = id_4;
                gameObject.GetComponent<RawImage>().enabled = true;
            }
            else if (id == 5)
            {
                gameObject.GetComponent<RawImage>().texture = id_5;
                gameObject.GetComponent<RawImage>().enabled = true;
            }
            else if (id == 6)
            {
                gameObject.GetComponent<RawImage>().texture = id_6;
                gameObject.GetComponent<RawImage>().enabled = true;
            }
            else if (id == 7)
            {
                gameObject.GetComponent<RawImage>().texture = id_7;
                gameObject.GetComponent<RawImage>().enabled = true;
            }
            else if (id == 8)
            {
                gameObject.GetComponent<RawImage>().texture = id_8;
                gameObject.GetComponent<RawImage>().enabled = true;
            }
            else if (id == 9)
            {
                gameObject.GetComponent<RawImage>().texture = id_9;
                gameObject.GetComponent<RawImage>().enabled = true;
            }
            else if (id == 10)
            {
                gameObject.GetComponent<RawImage>().texture = id_10;
                gameObject.GetComponent<RawImage>().enabled = true;
            }
        }
        
        
    }
}
