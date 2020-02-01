using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState
{
    public ChaseState(GameObject _attachedObject = null)
    {
        attachedObject = _attachedObject;
    }

    public float movementSpeed = 1.0f;

    public override void Init()
    {
        target = AIData.Instance.GetNearestTarget(attachedObject);
        movementSpeed =  AIData.Instance.GetMovementSpeed(attachedObject);

        stateEnd = false;
    }

    public override void Update(float _dt)
    {
        if (target == null) 
        {
            target = AIData.Instance.GetNearestTarget(attachedObject);
            
        }
        
        this.attachedObject.transform.position = Vector2.MoveTowards(attachedObject.transform.position, target.transform.position, movementSpeed * _dt);
    }

    public override void OnEnd()
    {
        stateEnd = true;
    }

}
