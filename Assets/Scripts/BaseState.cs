using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected bool stateEnd;

    public virtual void Init()
    {
        stateEnd = false;
    }
    
    public virtual void Update() 
    { 
    }

    public virtual void OnEnd() 
    {
        stateEnd = true;
    }
}
