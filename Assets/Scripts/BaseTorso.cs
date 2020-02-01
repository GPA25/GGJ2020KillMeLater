using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTorso : BasePart
{
    int health = 1;

    // Speed will be affected by this
    float movespdMult = 1.0f;

    // Damage will be affected by this
    float damageMult = 1.0f;

    // how fast the attack animation will be 
    float atkSpdMult = 1.0f;

    // How Long before the next attack
    float atkDelay = 1.0f;

    // Positions of the limbs
    public List<Vector2> l_LimbPosition;

    // list of attached limbs
    public List<BasePart> l_AttachedLimbs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StorePartsInList()
    {
        foreach (BasePart go in GameObject.FindObjectsOfType<BasePart>())
        {
            if (go == this)
                continue;

            l_AttachedLimbs.Add(go);
        }
    }
}
