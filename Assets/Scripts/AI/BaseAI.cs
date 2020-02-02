using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAI : MonoBehaviour
{
    public enum AI_STATE
    {
        IDLE_STATE = 0,
        CHASE_STATE,
        ATTACK_STATE,
    }
    public bool isAlive = true;

    public AI_STATE currentState;

    ChaseState chaseState;
    AttackState attackState;

    float attackDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        CreateAI();
        isAlive = true;
    }

    protected virtual void Update()
    {
        AILogicHardcode();

        if(!isAlive)
        {
            gameObject.SetActive(false);
        }
    }

    public virtual void AILogicHardcode()
    {
        switch (currentState)
        {
            case AI_STATE.IDLE_STATE:
                break;
            case AI_STATE.CHASE_STATE:
                attackDelay -= Time.deltaTime;
                chaseState.Update(Time.deltaTime);

                if (chaseState.target == null || !chaseState.target.GetComponent<BaseAI>().isAlive)
                    chaseState.target = AIData.Instance.GetNearestTarget(this.gameObject);

                if (attackState.currArm == null)
                    attackState.Attack();

                attackState.animator.speed = chaseState.movementSpeed;

                if (chaseState.target == null || attackState.currArm == null)
                    break;

                if (chaseState.target.transform.position.x - chaseState.attachedObject.transform.position.x > 0.0f)
                {
                    chaseState.attachedObject.transform.root.localEulerAngles = new Vector3(0, 180, 0);
                }
                else
                {
                    chaseState.attachedObject.transform.root.localEulerAngles = new Vector3(0, 0, 0);
                }

                if (Vector2.Distance(this.transform.root.position, chaseState.target.transform.root.position) < 2.5f)
                {
                    SetState(AI_STATE.ATTACK_STATE);

                    // Start the attack
                    {
                        attackState.Attack();
                        attackDelay = attackState.currArm.attackDelay;
                    }
                }
                break;

            case AI_STATE.ATTACK_STATE:
                break;
        }
    }

    void CreateAI()
    {
        chaseState = new ChaseState(this.gameObject);
        attackState = new AttackState(this.gameObject);

        currentState = AI_STATE.CHASE_STATE;
    }

    public void SetWindUpSpeed()
    {
        attackState.animator.speed = attackState.currArm.windUpTime;
        Debug.Log(attackState.animator.speed);
    }

    public void SetAttackSpeed()
    {
        attackState.animator.speed = attackState.currArm.attackSpeed;
    }

    public void SetRecoverySpeed()
    {
        attackState.animator.speed = attackState.currArm.recoveryTime;
    }

    public void SetState(AI_STATE _newState)
    {
        currentState = _newState;
    }
}
