using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaSystem : MonoBehaviour
{
    [SerializeField]
    float rateR = 0.75f;
    [SerializeField]
    float rateSR = 0.24f;
    [SerializeField]
    float rateUR = 0.01f;

    [SerializeField]
    private GachaAnimator animator;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SingleSummon()
    {
        if (CheckInventory(1))
        {
            BasePart part = RandomGachaNoGuarantee();

            // add to inventory

            animator.StartGachaSequence();
        }
    }

    public void TenSummon()
    {
        if (CheckInventory(10))
        {
            for (int i = 0; i < 10; i++)
            {
                //BasePart part = RandomGachaNoGuarantee();
            }
        }
    }

    private bool CheckInventory(int numSlotsNeeded)
    {
        // check if player has enough inventory slots
        
        return true;
    }

    private BasePart RandomGachaNoGuarantee()
    {
        float roll = Random.Range(0f, 1f);
        if (roll <= rateUR)
        {
            Debug.Log("UR");
            // get UR part
        }
        else if (roll <= rateUR + rateSR)
        {
            Debug.Log("SR");
            // get SR part
        }
        else
        {
            Debug.Log("R");
            // get R part
        }

        return null;
    }

    private BasePart RandomGachaGuarantee()
    {
        return null;
    }
}
