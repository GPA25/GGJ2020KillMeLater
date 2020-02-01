using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public HeadPart head;
    public BaseTorso torso;
    // list of attached limbs
    public List<BasePart> l_AttachedLimbs = new List<BasePart>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(string _head, string _torso, string[] limbNameArray)
    {
        head.LoadTexture(_head);
        torso.LoadTexture(_torso);

        for(int i = 0; i < limbNameArray.Length; ++i)
        {
            l_AttachedLimbs[i].LoadTexture(limbNameArray[i]);
        }
    }
}
