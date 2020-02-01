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
    }

    protected virtual void Update()
    {
        AILogicHardcode();
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

                if (Vector2.Distance(this.transform.position, chaseState.target.transform.position) < attackState.currArm.atkRange * 0.5)
                {
                    SetState(AI_STATE.ATTACK_STATE);

                    // Start the attack
                    {
                        attackState.Attack();
                        attackDelay = attackState.currArm.attackDelay;
                    }
                }

                if (chaseState.target.transform.position.x - chaseState.attachedObject.transform.position.x > 0.0f)
                {
                    chaseState.attachedObject.transform.root.localEulerAngles = new Vector3(0, 180, 0);
                    Debug.Log(chaseState.attachedObject.transform.root);
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
        attackState.animator.speed = ((AttackState)attackState).currArm.windUpTime;
    }

    public void SetAttackSpeed()
    {
        attackState.animator.speed = ((AttackState)attackState).currArm.attackSpeed;
    }

    public void SetRecoverySpeed()
    {
        attackState.animator.speed = ((AttackState)attackState).currArm.recoveryTime;
    }

    public void SetState(AI_STATE _newState)
    {
        currentState = _newState;
    }
}
