using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : SingletonTemplate<PlayerData>
{
    string name;
    int currency;

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
