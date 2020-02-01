using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] limbNameArray = {"stump", "stump", "chicken", "chicken" };
        BasePart.LIMB_TYPE[] limbTypeArray = {BasePart.LIMB_TYPE.LIMB_ARM, BasePart.LIMB_TYPE.LIMB_ARM, BasePart.LIMB_TYPE.LIMB_LEG, BasePart.LIMB_TYPE.LIMB_LEG };

        Character.Create("fish", "TestTorso", limbNameArray, limbTypeArray);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
