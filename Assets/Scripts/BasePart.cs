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
    public enum LIMB_TYPE
    {
        LIMB_HEAD,
        LIMB_TORSO,
        LIMB_ARM,
        LIMB_LEG,

        LIMB_END
    }

    public int price = 1;

    public string name = "";

    public string flavourText = "";

    public RARITY rarity = RARITY.RARITY_RARE;

    public LIMB_TYPE limbType = LIMB_TYPE.LIMB_END;

    virtual public void LoadTexture(){}

    public static BasePart Create(string name, LIMB_TYPE limbType)
    {
        GameObject go = new GameObject();
        
        switch(limbType)
        {
            case LIMB_TYPE.LIMB_HEAD:
                go.name = name;
                go.AddComponent<SpriteRenderer>();
                go.AddComponent<HeadPart>();
                go.GetComponent<HeadPart>().name = name;
                go.GetComponent<HeadPart>().LoadTexture();
            break;

            case LIMB_TYPE.LIMB_TORSO:
                go.name = name;
                go.AddComponent<SpriteRenderer>();
                go.AddComponent<BaseTorso>();
                go.GetComponent<BaseTorso>().name = name;
                go.GetComponent<BaseTorso>().LoadTexture();
            break;

            case LIMB_TYPE.LIMB_ARM:
                    go.name = name;
                    go.AddComponent<SpriteRenderer>();
                    go.AddComponent<ArmPart>();
                    go.GetComponent<ArmPart>().name = name;
                    go.GetComponent<ArmPart>().LoadTexture();
            break;

            case LIMB_TYPE.LIMB_LEG:
                    go.name = name;
                    go.AddComponent<SpriteRenderer>();
                    go.AddComponent<LegPart>();
                    go.GetComponent<LegPart>().name = name;
                    go.GetComponent<LegPart>().LoadTexture();
            break;

            default:
                    return null;
            break;
        }

        return go.GetComponent<BasePart>();
    }
}
