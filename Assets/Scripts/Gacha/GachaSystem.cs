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

    private BasePart.RARITY gachaRarity;    // rarity that had been gacha'd

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GachaRoll()
    {
        List<PartData> parts = PartsTable.Instance.GetPartsByRarity(gachaRarity);
        int roll = Random.Range(0, parts.Count);
        BasePart partGO = BasePart.Create(parts[roll].name, (BasePart.LIMB_TYPE)(parts[roll].partType));

        Debug.Log("Roll: " + parts[roll].name);
    }

    public void SingleSummon()
    {
        if (CheckInventory(1))
        {
            BasePart.RARITY rarity = RandomGachaNoGuarantee();
            // start animation sequence
            animator.StartGachaSequence(rarity);
        }
        else
        {
            Debug.Log("Inventory full");
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
        else
        {
            Debug.Log("Inventory full");
        }
    }

    private bool CheckInventory(int numSlotsNeeded)
    {
        // check if player has enough inventory slots
        
        return true;
    }

    private BasePart.RARITY RandomGachaNoGuarantee()
    {
        float roll = Random.Range(0f, 1f);
        if (roll <= rateUR)
        {
            Debug.Log("UR");
            return BasePart.RARITY.RARITY_ULTRA_RARE;
        }
        else if (roll <= rateUR + rateSR)
        {
            Debug.Log("SR");
            return BasePart.RARITY.RARITY_SUPER_RARE;
        }
        else
        {
            Debug.Log("R");
            return BasePart.RARITY.RARITY_RARE;
        }
    }

    private BasePart RandomGachaGuarantee()
    {
        return null;
    }
}
