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

    public RARITY rarity = RARITY.RARITY_RARE;
    public int price = 1;
}
