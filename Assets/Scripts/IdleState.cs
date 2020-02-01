using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public override void Init()
    {
        stateEnd = false;
    }

    public override void Update()
    {
        stateEnd = true;
    }

    public override void OnEnd()
    {
        stateEnd = true;
    }
}
