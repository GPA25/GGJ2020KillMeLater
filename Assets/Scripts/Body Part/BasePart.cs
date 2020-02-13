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

        go.AddComponent<SpriteRenderer>();

        switch(((LIMB_TYPE)(partData.partType)))
        {
            case LIMB_TYPE.LIMB_HEAD:
                go.AddComponent<HeadPart>();
            break;

            case LIMB_TYPE.LIMB_TORSO:
                go.AddComponent<BaseTorso>();
                break;

            case LIMB_TYPE.LIMB_ARM:
                go.AddComponent<ArmPart>();
                break;

            case LIMB_TYPE.LIMB_LEG:
                go.AddComponent<LegPart>();
                break;

            default:
                return null;
                break;
        }
        go.GetComponent<BasePart>().LoadPartData(partData);
        go.name = partData.name;

        return go.GetComponent<BasePart>();
    }

    public void LoadPartData(PartData partData)
    {
        this.name = partData.name;
        this.flavourText = partData.flavorText;
        this.limbType = (LIMB_TYPE)(partData.partType);
        this.rarity = (RARITY)(partData.rarity);
        this.price = partData.price;

        this.LoadTexture(partData.fileName);

        switch (((LIMB_TYPE)(partData.partType)))
        {
            case LIMB_TYPE.LIMB_HEAD:
                break;

            case LIMB_TYPE.LIMB_TORSO:
                this.GetComponent<BaseTorso>().movespdMult = partData.moveSpeedMult;
                this.GetComponent<BaseTorso>().atkSpdMult = partData.attackSpeedMult;
                this.GetComponent<BaseTorso>().mass = partData.mass;
                break;

            case LIMB_TYPE.LIMB_ARM:
                this.GetComponent<ArmPart>().attackSpeed = partData.attackSpeed;
                this.GetComponent<ArmPart>().attackDelay = partData.armAttackDelay;
                this.GetComponent<ArmPart>().windUpTime = partData.windupTime;
                this.GetComponent<ArmPart>().recoveryTime = partData.recoveryTime;
                this.GetComponent<ArmPart>().knockback = partData.knockbackStrength;
                this.GetComponent<ArmPart>().atkRange = 5.0f;
                break;

            case LIMB_TYPE.LIMB_LEG:
                this.GetComponent<LegPart>().moveSpd = partData.moveSpeed;
                break;

            default:
                break;
        }
    }
}
