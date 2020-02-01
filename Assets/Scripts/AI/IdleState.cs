using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public IdleState(GameObject _attachedObject = null)
    {
        attachedObject = _attachedObject;
    }

    public override void Init()
    {
        stateEnd = true;
    }

    public override void Update(float _dt)
    {
        stateEnd = true;
    }

    public override void OnEnd()
    {
        stateEnd = true;
    }
}
