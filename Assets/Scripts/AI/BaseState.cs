using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    //if the state has eneded
    public bool stateEnd;

    // Target of the unit
    public GameObject target;

    // This Gameobject
    public GameObject attachedObject;

    public virtual void Init()
    {
        stateEnd = false;
    }
    
    public virtual void Update(float _dt) 
    {
    }

    public virtual void OnEnd() 
    {
        stateEnd = true;
    }

}
