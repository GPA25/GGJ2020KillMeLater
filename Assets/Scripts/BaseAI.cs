using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAI : MonoBehaviour
{
    public BaseState currentState;

    public List<BaseAI> l_otherAI;
   
    // Start is called before the first frame update
    void Start()
    {
        StoreOtherAIInList();
    }

    public void StoreOtherAIInList()
    {
        foreach (BaseAI go in GameObject.FindObjectsOfType<BaseAI>())
        {
            if (go == this)
                continue;

            l_otherAI.Add(go);
        }
    }
}
