using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance = null;
    public static PlayerData Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Debug.Log(string.Format("Instance of PartsTable already exists! Deleting PartsTable script in %s.", gameObject.name));
            Destroy(this);
        }
        
        DontDestroyOnLoad(this);

        name = PlayerPrefs.GetString("name");
        currency = PlayerPrefs.GetInt("currency");

        equippedHead = PlayerPrefs.GetString("equippedHead");
        equippedTorso = PlayerPrefs.GetString("equippedTorso");
        equippedLeftArm = PlayerPrefs.GetString("equippedLeftArm");
        equippedRightArm = PlayerPrefs.GetString("equippedRightArm");
        equippedLeftLeg = PlayerPrefs.GetString("equippedLeftLeg");
        equippedRightLeg = PlayerPrefs.GetString("equippedRightLeg");
    }

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
