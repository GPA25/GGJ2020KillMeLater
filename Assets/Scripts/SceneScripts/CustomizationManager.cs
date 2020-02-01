using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] limbNameList = {"Muscle", "Muscle", "stockin", "banana"};
        BasePart.LIMB_TYPE[] limbTypeList = {BasePart.LIMB_TYPE.LIMB_ARM, BasePart.LIMB_TYPE.LIMB_ARM, BasePart.LIMB_TYPE.LIMB_LEG, BasePart.LIMB_TYPE.LIMB_LEG};

        Character.Create("fish", "TestTorso", limbNameList, limbTypeList);       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
