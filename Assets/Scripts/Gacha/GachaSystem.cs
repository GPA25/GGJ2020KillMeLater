using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaSystem : MonoBehaviour
{
    [SerializeField]
    private float rateR = 0.75f;
    [SerializeField]
    private float rateSR = 0.24f;
    [SerializeField]
    private float rateUR = 0.01f;

    private int numSummons = 0;

    [SerializeField]
    private GameObject[] buttonsToHide;

    [SerializeField]
    private GachaAnimator animator;

    [SerializeField]
    private Vector3[] summonPositions;    // for all 10

    private BasePart.RARITY gachaRarity;    // rarity that had been gacha'd
    private bool gachaEnded = false;     // start the next gacha
    private bool isSingleSummon = false;

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
        if (numSummons > 0)
        {
            if (!gachaEnded)
            {
                numSummons--;

                List<PartData> parts = PartsTable.Instance.GetPartsByRarity(gachaRarity);
                int roll = Random.Range(0, parts.Count);
                BasePart partGO = BasePart.Create(parts[roll].name, (BasePart.LIMB_TYPE)(parts[roll].partType));
                if (!isSingleSummon) {
                    partGO.transform.position = summonPositions[9 - numSummons];
                }

                Debug.Log("Roll: " + parts[roll].name);

                gachaEnded = true;
            }
            else
            {
                gachaEnded = false;
                Summon();
            }
        }
        else
        {
            // Exit scene
        }
    }

    public void SingleSummon()
    {
        if (CheckInventory(1))
        {
            numSummons = 1;
            Summon();
            isSingleSummon = true;
            foreach (GameObject go in buttonsToHide)
            {
                go.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Inventory full");
        }
    }

    private void Summon()
    {
        gachaRarity = RandomGachaNoGuarantee();
        // start animation sequence
        animator.StartGachaSequence(gachaRarity);
    }

    public void TenSummon()
    {
        if (CheckInventory(10))
        {
            numSummons = 10;
            Summon();
            foreach (GameObject go in buttonsToHide)
            {
                go.SetActive(false);
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
