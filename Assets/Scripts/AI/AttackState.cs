using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    public ArmPart currArm;

    public AttackState(GameObject _attachedObject = null)
    {
        attachedObject = _attachedObject;
        animator = _attachedObject.GetComponent<Animator>();
        Init();
    }

    public override void Init()
    {
        currArm = GetRandomArm();
    }

    public override void Update(float _dt)
    {
    }

    public override void OnEnd()
    {

    }

    public void Attack()
    {
        Debug.Log("atk");
        if(currArm.gameObject.name == "Right Arm Display")
        {
            animator.Play("AIRightPunchWindUp");
        }
        else
        {
            animator.Play("AILeftPunchWindUp");
        }

        currArm = GetRandomArm();
        target = AIData.Instance.GetNearestTarget(attachedObject);
    }

}
