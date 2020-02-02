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
        if(this.GetComponent<Rigidbody2D>())
        this.GetComponent<Rigidbody2D>().mass = torso.mass;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(string _head, string _torso, string[] limbNameArray)
    {
        head.LoadPartData(PartsTable.instance.GetPartData(_head));
        torso.LoadPartData(PartsTable.instance.GetPartData(_torso));

        for(int i = 0; i < limbNameArray.Length; ++i)
        {
            l_AttachedLimbs[i].LoadPartData(PartsTable.instance.GetPartData(limbNameArray[i]));
        }
    }

    public void InitRandom()
    {
        head.LoadPartData(PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_HEAD)[Random.Range(0, PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_HEAD).Count)]);
        torso.LoadPartData(PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_TORSO)[Random.Range(0, PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_TORSO).Count)]);

        l_AttachedLimbs[0].LoadPartData(PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_ARM)[Random.Range(0, PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_ARM).Count)]);
        l_AttachedLimbs[1].LoadPartData(PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_ARM)[Random.Range(0, PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_ARM).Count)]);
        l_AttachedLimbs[2].LoadPartData(PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_LEG)[Random.Range(0, PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_LEG).Count)]);
        l_AttachedLimbs[3].LoadPartData(PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_LEG)[Random.Range(0, PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_LEG).Count)]);
    }
}
