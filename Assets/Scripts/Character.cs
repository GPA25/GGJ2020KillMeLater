using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public HeadPart head;
    public BaseTorso torso;
    // list of attached limbs
    public List<BasePart> l_AttachedLimbs = new List<BasePart>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(string _head, string _torso, string[] limbNameArray)
    {
        head.LoadTexture(PartsTable.instance.GetPartData(_head).fileName);
        torso.LoadTexture(PartsTable.instance.GetPartData(_torso).fileName);

        for(int i = 0; i < limbNameArray.Length; ++i)
        {
            l_AttachedLimbs[i].LoadTexture(PartsTable.instance.GetPartData(limbNameArray[i]).fileName);
        }
    }

    public void InitRandom()
    {
        head.LoadTexture(PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_HEAD)[Random.Range(0, PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_HEAD).Count)].fileName);
        torso.LoadTexture(PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_TORSO)[Random.Range(0, PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_TORSO).Count)].fileName);

        l_AttachedLimbs[0].LoadTexture(PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_ARM)[Random.Range(0, PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_ARM).Count)].fileName);
        l_AttachedLimbs[1].LoadTexture(PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_ARM)[Random.Range(0, PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_ARM).Count)].fileName);
        l_AttachedLimbs[2].LoadTexture(PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_LEG)[Random.Range(0, PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_LEG).Count)].fileName);
        l_AttachedLimbs[3].LoadTexture(PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_LEG)[Random.Range(0, PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_LEG).Count)].fileName);
    }
}
