using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Duos : MonoBehaviour
{
    public GameObject child;
    public GameObject bone;
    public Duos(GameObject Child,GameObject Bone) 
    {
        child = Child;
        bone = Bone;
    }
}
public class matchrot : MonoBehaviour
{
    public GameObject matchTarget;
    public List<GameObject> BoneList;
    public List<GameObject> ChildList;
    public List<Duos> DuoList;
    void Start()
    {
        foreach (Transform g in matchTarget.transform.GetComponentsInChildren<Transform>())
        {
            BoneList.Add(g.gameObject);
        }
        foreach (Transform g in gameObject.transform.GetComponentsInChildren<Transform>())
        {
            ChildList.Add(g.gameObject);
        }
        
    }
    void Update()
    {
        foreach (GameObject bone in BoneList)
        {
            foreach (GameObject Child in ChildList)
            {
                if (bone.name == Child.name)
                {
                    
                    if (DuoList.Count > 0)
                    {
                        foreach(Duos duo in DuoList)
                        {
                            if (duo != new Duos(Child, bone)) { DuoList.Add(new Duos(Child, bone)); }

                        }
                    }
                    else
                    {
                        print("x");
                        Duos xduo = new Duos(Child, bone);
                        DuoList.Add(xduo);
                    }

                }
            }
        }
        foreach (Duos duo in DuoList)
        {
            duo.child.transform.position = duo.bone.transform.position;
            duo.child.transform.rotation = duo.bone.transform.rotation;
            duo.child.transform.localScale = duo.bone.transform.localScale;
        }
    }
}
