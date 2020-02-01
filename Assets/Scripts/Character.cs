using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    HeadPart head;
    BaseTorso torso;

    // Start is called before the first frame update
    void Start()
    {
        head = HeadPart.Create("Test");
        torso = BaseTorso.Create("Test");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
