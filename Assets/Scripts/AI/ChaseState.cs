using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState
{
    public ChaseState(GameObject _attachedObject = null)
    {
        attachedObject = _attachedObject;
        animator = _attachedObject.GetComponent<Animator>();
        Init();
    }

    public float movementSpeed = 1.0f;

    public override void Init()
    {
        target = AIData.Instance.GetNearestTarget(attachedObject);

        movementSpeed =  GetMovementSpeed();

        animator.speed = movementSpeed;

        if (target)
        {
            Vector2 dir = target.transform.position - attachedObject.transform.position;

            if (dir.x > 0)
            {
                attachedObject.transform.localScale.Set(attachedObject.transform.localScale.x, attachedObject.transform.localScale.y, -attachedObject.transform.localScale.z);
            }
        }
    }

    public override void Update(float _dt)
    {
        if (target == null)
        {
            target = AIData.Instance.GetNearestTarget(attachedObject);
        }

        if (target != null)
        {
            if (attachedObject.GetComponent<Rigidbody2D>().velocity.y == 0)
                this.attachedObject.transform.position = Vector2.MoveTowards(attachedObject.transform.position, target.transform.position, movementSpeed * _dt);
        }
    }

    public override void OnEnd()
    {
        stateEnd = true;
    }

}
