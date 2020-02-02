﻿using System.Collections;
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

    private List<Transform> tenSummon;  // list for storing parts from ten summon

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        tenSummon = new List<Transform>();
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

                // ROLL FOR THE PART HERE
                List<PartData> parts = PartsTable.Instance.GetPartsByRarity(gachaRarity);
                int roll = Random.Range(0, parts.Count);
                BasePart partGO = BasePart.Create(parts[roll].name);
                partGO.transform.localScale = new Vector3(0.45f, 0.45f, 0.45f);

                // ADD TO INVENTORY
                PlayerData.Instance.AddInventoryItem(parts[roll].name);
                Debug.Log("Roll: " + parts[roll].name);

                if (!isSingleSummon) {
                    tenSummon.Add(partGO.transform);
                }
                else
                {
                    // SAVE TO INVENTORY
                    PlayerData.Instance.SaveInventoryToPlayerPrefs();
                }
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
                    tenSummon[9 - numSummons].gameObject.SetActive(false);
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

                Summon();
            }
        }
        else if (!isSingleSummon)
        {
            // show all 10 summons
            for (int i = 0; i < 10; i++)
            {
                tenSummon[i].position = summonPositions[i];
                tenSummon[i].gameObject.SetActive(true);
                // resize to be smaller to fit screen
                tenSummon[i].localScale = new Vector3(0.15f, 0.15f, 0.15f);
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

            // SAVE TO INVENTORY
            PlayerData.Instance.SaveInventoryToPlayerPrefs();
        }
    }

    public void SingleSummon()
    {
        if (PlayerData.Instance.CheckInventoryCapacityRemaining(1))
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
        if (PlayerData.Instance.CheckInventoryCapacityRemaining(10))
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
}
