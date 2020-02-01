using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopState : BaseState
{
    public float movementSpeed = 1.0f;

    public HopState(GameObject _attachedObject = null)
    {
        attachedObject = _attachedObject;
    }
    public override void Init()
    {
        target = AIData.Instance.GetNearestTarget(attachedObject);
        movementSpeed = GetMovementSpeed();

        stateEnd = false;
    }

    public override void Update(float _dt)
    {
        if (target == null)
        {
            target = AIData.Instance.GetNearestTarget(attachedObject);
        }

        Vector2 dir = target.transform.position - attachedObject.transform.position;
    }

    public override void OnEnd()
    {
        stateEnd = true;
    }
}
