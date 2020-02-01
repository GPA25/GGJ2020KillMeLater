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
        torso.GetComponent<SpriteRenderer>().sortingOrder = 10;
        l_AttachedLimbs[1].transform.Rotate(0, 0, -35, 0);
        head.transform.parent = torso.transform;
        head.GetComponent<SpriteRenderer>().sortingOrder = (int)(torso.l_LimbPosition[0].z);
        head.transform.localPosition = torso.l_LimbPosition[0];
        
        for(int i = 0; i+1 < torso.l_LimbPosition.Count && i < l_AttachedLimbs.Count; ++i)
        {
            l_AttachedLimbs[i].transform.parent = torso.transform;
            l_AttachedLimbs[i].transform.localPosition = torso.l_LimbPosition[i+1];
            l_AttachedLimbs[i].GetComponent<SpriteRenderer>().sortingOrder = (int)(torso.l_LimbPosition[i+1].z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Character Create(string head, string torso, string[] limbNameArray, BasePart.LIMB_TYPE[] limbTypeArray)
    {
        GameObject go = new GameObject();
        Character charac = go.AddComponent<Character>();

        charac.head = (HeadPart)(BasePart.Create(head, BasePart.LIMB_TYPE.LIMB_HEAD));
        charac.torso = (BaseTorso)(BasePart.Create(torso, BasePart.LIMB_TYPE.LIMB_TORSO));
        for(int i = 0; i < limbNameArray.Length && i < limbTypeArray.Length; ++i)
        {
            charac.l_AttachedLimbs.Add(BasePart.Create(limbNameArray[i], limbTypeArray[i]));
        }

        return charac;
    }
}
