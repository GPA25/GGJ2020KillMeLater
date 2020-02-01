using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    public AttackState(GameObject _attachedObject = null)
    {
        attachedObject = _attachedObject;
        Init();
    }

    public override void Init()
    {
        stateEnd = false;
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
