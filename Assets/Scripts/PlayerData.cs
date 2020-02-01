using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : SingletonTemplate<PlayerData>
{
    public string name;
    public int currency;

    public string equippedHead;
    public string equippedTorso;
    public string equippedLeftArm;
    public string equippedRightArm;
    public string equippedLeftLeg;
    public string equippedRightLeg;

    List<BaseTorso> ownedTorsoList;
    List<ArmPart> ownedArmList;
    List<LegPart> ownedLegList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
