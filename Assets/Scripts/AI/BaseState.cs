using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    //if the state has eneded
    public bool stateEnd;

    // Target of the unit
    public GameObject target;

    //Animator for player
    public Animator animator;

    // This Gameobject
    public GameObject attachedObject;

    public virtual void Init()
    {
    }
    
    public virtual void Update(float _dt) 
    {
    }

    public virtual void OnEnd() 
    {
        stateEnd = true;
    }

    public float GetMovementSpeed()
    {
        if (!attachedObject)
            return 0.0f;

        float movementSpeed = 1.0f;

        int numLegs = 0;

        foreach (LegPart go in attachedObject.GetComponentsInChildren<LegPart>())
        {
            movementSpeed += go.moveSpd;
            ++numLegs;
        }

        BaseTorso torso = attachedObject.GetComponentInChildren<BaseTorso>();

        if (torso && numLegs >= 2)
        {

            return movementSpeed / numLegs * torso.movespdMult;
        }
        else
            return 0.5f;
    }

    public ArmPart GetRandomArm()
    {
        if (!attachedObject)
            return null;

        ArmPart[] l_ArmPart = attachedObject.GetComponentsInChildren<ArmPart>();

        if (l_ArmPart.Length > 0)
            return l_ArmPart[Random.Range(0, l_ArmPart.Length)];

        return null;

    }
}
