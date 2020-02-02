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

    public virtual void LoadTexture(string filename){}

    public static BasePart Create(string name)
    {
        GameObject go = new GameObject();

        PartData partData = PartsTable.Instance.GetPartData(name);

        switch(((LIMB_TYPE)(partData.partType)))
        {
            case LIMB_TYPE.LIMB_HEAD:
                go.name = name;
                go.AddComponent<SpriteRenderer>();
                go.AddComponent<HeadPart>();
                go.GetComponent<HeadPart>().name = name;
                go.GetComponent<HeadPart>().LoadTexture(partData.fileName);
            break;

            case LIMB_TYPE.LIMB_TORSO:
                go.name = name;
                go.AddComponent<SpriteRenderer>();
                go.AddComponent<BaseTorso>();
                go.GetComponent<BaseTorso>().name = name;
                go.GetComponent<BaseTorso>().LoadTexture(partData.fileName);
                go.GetComponent<BaseTorso>().health = partData.health;
                go.GetComponent<BaseTorso>().movespdMult = partData.moveSpeedMult;
                go.GetComponent<BaseTorso>().damageMult = partData.damageMult;
                go.GetComponent<BaseTorso>().atkSpdMult = partData.attackSpeedMult;
                go.GetComponent<BaseTorso>().atkDelay = partData.torsoAttackDelay;
                break;

            case LIMB_TYPE.LIMB_ARM:
                    go.name = name;
                    go.AddComponent<SpriteRenderer>();
                    go.AddComponent<ArmPart>();
                    go.GetComponent<ArmPart>().name = name;
                    go.GetComponent<ArmPart>().LoadTexture(partData.fileName);
                    go.GetComponent<ArmPart>().damage = partData.damage;
                    go.GetComponent<ArmPart>().attackSpeed = partData.attackSpeed;
                    go.GetComponent<ArmPart>().attackDelay = partData.armAttackDelay;
                    go.GetComponent<ArmPart>().windUpTime = partData.windupTime;
                    go.GetComponent<ArmPart>().recoveryTime = partData.recoveryTime;
                break;

            case LIMB_TYPE.LIMB_LEG:
                    go.name = name;
                    go.AddComponent<SpriteRenderer>();
                    go.AddComponent<LegPart>();
                    go.GetComponent<LegPart>().name = name;
                    go.GetComponent<LegPart>().LoadTexture(partData.fileName);
                    go.GetComponent<LegPart>().moveSpd = partData.moveSpeed;
                break;

            default:
                    return null;
            break;
        }

        go.GetComponent<BasePart>().rarity = (BasePart.RARITY)(partData.rarity);

        return go.GetComponent<BasePart>();
    }
}
