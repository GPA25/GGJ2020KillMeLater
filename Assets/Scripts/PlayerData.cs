using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : SingletonTemplate<PlayerData>
{
    string name;
    int currency;

    string currentlyEquippedHead;
    string currentlyEquippedTorso;
    string[] currentlyEquippedLimbs;

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

    // public void SaveBody()
    // {
    //     PlayerPrefs.SetString("head", currentlyEquippedHead);
    //     PlayerPrefs.SetString("torso", currentlyEquippedTorso);
    //     for(int i = 0; i < currentlyEquippedLimbs.Count; ++i)
    //     {
    //         PlayerPrefs.SetString("limb" + i, currentlyEquippedLimbs[i]);
    //     }
    // }
    // public void LoadBody()
    // {
    //     currentlyEquippedHead = PlayerPrefs.GetString("head", "");
    //     currentlyEquippedTorso = PlayerPrefs.GetString("torso", "");

    //     currentlyEquippedLimbs.Clear();
    //     for(int i = 0; i < currentlyEquippedLimbs.Count; ++i)
    //     {
    //         PlayerPrefs.GetString("limb" + i, currentlyEquippedLimbs[i]);
    //     }
    // }
}
