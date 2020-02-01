using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePart : MonoBehaviour
{
    public enum RARITY
    {
        RARITY_RARE = 0,
        RARITY_SUPER_RARE,
        RARITY_ULTRA_RARE,

        TOTAL
    }

    public int price = 1;

    public string name = "";

    public RARITY rarity = RARITY.RARITY_RARE;

    void Start()
    {
    }

    virtual public void LoadTexture(){}
}
