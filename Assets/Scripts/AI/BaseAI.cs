using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAI : MonoBehaviour
{
    public bool isAlive = true;

    BaseState currentState;

    BaseState idleState;
    BaseState chaseState;
    BaseState attackState;
    BaseState runawayState;

    public int runChance = 1;
    public int chaseChance = 1;
    public int attackChance = 1;

    // Start is called before the first frame update
    void Start()
    {
        CreateAI();
    }
    protected virtual void Update()
    {
        currentState.Update(Time.deltaTime);
        AILogicHardcode();
    }

    public virtual void AILogicHardcode()
    {
        if (currentState.stateEnd)
        {
            if (currentState == idleState)
            {
                
            }
            else if (currentState == chaseState)
            {
    
            }
            else if (currentState == attackState)
            {

            }
            else if (currentState == runawayState)
            {
			}
        }
    }

    void CreateAI()
    {
        idleState = new IdleState(this.gameObject);
        chaseState = new ChaseState(this.gameObject);
        attackState = new AttackState(this.gameObject);
        runawayState = new RunAwayState(this.gameObject);

        currentState = chaseState;
        currentState.Init();
    }

}
