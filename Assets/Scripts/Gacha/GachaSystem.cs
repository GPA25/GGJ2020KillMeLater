using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaSystem : MonoBehaviour
{
    //[SerializeField]
    //private float rateR = 0.75f;
    [SerializeField]
    private float rateSR = 0.24f;
    [SerializeField]
    private float rateUR = 0.01f;
    [SerializeField]
    private float guaranteedUR = 0.03f;

    private int numSummons = 0;

    [SerializeField]
    private GameObject[] buttonsToHide;

    [SerializeField]
    private GachaAnimator animator;
    [SerializeField]
    private GameObject doneButton;

    [SerializeField]
    private GameObject flavorText;
    [SerializeField]
    private GameObject nameText;

    [SerializeField]
    private ParticleSystem particleSystemR;
    [SerializeField]
    private ParticleSystem particleSystemSR;
    [SerializeField]
    private ParticleSystem particleSystemUR;

    [SerializeField]
    private Vector3[] summonPositions;    // for all 10

    private BasePart.RARITY gachaRarity;    // rarity that had been gacha'd
    private bool gachaEnded = false;     // start the next gacha
    private bool isSingleSummon = false;

    private List<BasePart> summonList;  // list for storing parts from the summons

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        summonList = new List<BasePart>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private BasePart Roll(bool isGuarantee)
    {
        if (isGuarantee)
            gachaRarity = RandomGachaGuaranteeSR();
        else
            gachaRarity = RandomGachaNoGuarantee();

        List<PartData> parts = PartsTable.Instance.GetPartsByRarity(gachaRarity);
        int roll = Random.Range(0, parts.Count);
        BasePart partGO = BasePart.Create(parts[roll].name);

        // ADD TO INVENTORY
        PlayerData.Instance.AddInventoryItem(parts[roll].name);
        Debug.Log("Roll: " + parts[roll].name);

        return partGO;
    }

    public void GachaRoll()
    {
        if (numSummons > 0)
        {
            if (!gachaEnded)
            {
                numSummons--;

                //BasePart partGO = Roll();
                // get next part
                BasePart partGO = summonList[numSummons];   // start taking from back of List
                partGO.gameObject.SetActive(true);
                gachaRarity = partGO.rarity;
                partGO.transform.localScale = new Vector3(0.45f, 0.45f, 0.45f);

                animator.StartSummonSequence(partGO.transform, isSingleSummon);
                switch (gachaRarity)
                {
                    case BasePart.RARITY.RARITY_RARE:
                        particleSystemR.gameObject.SetActive(true);
                        particleSystemR.Play();
                        break;
                    case BasePart.RARITY.RARITY_SUPER_RARE:
                        particleSystemSR.gameObject.SetActive(true);
                        particleSystemSR.Play();
                        break;
                    case BasePart.RARITY.RARITY_ULTRA_RARE:
                        particleSystemUR.gameObject.SetActive(true);
                        particleSystemUR.Play();
                        break;
                }

                gachaEnded = true;
            }
            else
            {
                if (!isSingleSummon)
                {
                    summonList[numSummons].gameObject.SetActive(false);
                }
                gachaEnded = false;

                // turn off particle effects
                switch (gachaRarity)
                {
                    case BasePart.RARITY.RARITY_RARE:
                        particleSystemR.Stop();
                        particleSystemR.gameObject.SetActive(false);
                        break;
                    case BasePart.RARITY.RARITY_SUPER_RARE:
                        particleSystemSR.Stop();
                        particleSystemSR.gameObject.SetActive(false);
                        break;
                    case BasePart.RARITY.RARITY_ULTRA_RARE:
                        particleSystemUR.Stop();
                        particleSystemUR.gameObject.SetActive(false);
                        break;
                }
                // turn off text
                flavorText.SetActive(false);
                nameText.SetActive(false);

                SummonAnim();
            }
        }
        else if (!isSingleSummon)
        {
            // show all summons
            for (int i = 0; i < summonList.Count; i++)
            {
                summonList[i].transform.position = summonPositions[summonList.Count - 1 - i];
                summonList[i].gameObject.SetActive(true);
                // resize to be smaller to fit screen
                summonList[i].transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            }
            doneButton.SetActive(true);

            // turn off particle effects
            switch (gachaRarity)
            {
                case BasePart.RARITY.RARITY_RARE:
                    particleSystemR.Stop();
                    particleSystemR.gameObject.SetActive(false);
                    break;
                case BasePart.RARITY.RARITY_SUPER_RARE:
                    particleSystemSR.Stop();
                    particleSystemSR.gameObject.SetActive(false);
                    break;
                case BasePart.RARITY.RARITY_ULTRA_RARE:
                    particleSystemUR.Stop();
                    particleSystemUR.gameObject.SetActive(false);
                    break;
            }

            // turn off text
            flavorText.SetActive(false);
            nameText.SetActive(false);
        }
    }

    public void DoGachaSummon(int numSummon)
    {
        if (PlayerData.Instance.CheckInventoryCapacityRemaining(numSummon))
        {
            numSummons = numSummon;
            isSingleSummon = numSummon == 1;
            foreach (GameObject go in buttonsToHide)
            {
                go.SetActive(false);
            }
            DoGachaRolls();
            SummonAnim();
        }
        else
        {
            Debug.Log("Inventory full");
        }
    }

    private void SummonAnim()
    {
        gachaRarity = summonList[numSummons - 1].rarity;    // get next summon
        // start animation sequence
        animator.StartGachaSequence(gachaRarity);
    }

    private void DoGachaRolls()
    {
        int guaranteedSRIdx = -1;
        if (numSummons >= 10)   // jic
        {
            guaranteedSRIdx = Random.Range(0, numSummons);
        }
        for (int i = 0; i < numSummons; i++)
        {
            // roll next part to be summoned + save to inventory
            BasePart partGO = Roll(i == guaranteedSRIdx);
            partGO.gameObject.SetActive(false); // disable first
            summonList.Add(partGO);
        }

        PlayerData.Instance.SaveInventoryToPlayerPrefs();
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

    private BasePart.RARITY RandomGachaGuaranteeSR()
    {
        float roll = Random.Range(0f, 1f);
        if (roll <= guaranteedUR)
        {
            Debug.Log("UR");
            return BasePart.RARITY.RARITY_ULTRA_RARE;
        }
        else
        {
            Debug.Log("SR");
            return BasePart.RARITY.RARITY_SUPER_RARE;
        }
    }
}
