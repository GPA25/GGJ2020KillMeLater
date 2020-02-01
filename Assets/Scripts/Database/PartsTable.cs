using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsTable : MonoBehaviour
{

    public static PartsTable instance = null;
    public static PartsTable Instance
    {
        get { return instance; }
    }

    [SerializeField]
    private TextAsset partsDatabase;

    private Dictionary<string, PartData> partsTable;    // parts, hashed by part name

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Debug.Log(string.Format("Instance of PartsTable already exists! Deleting PartsTable script in %s.", gameObject.name));
            Destroy(this);
        }
        partsTable = new Dictionary<string, PartData>();

        InitPartsList();
    }

    private void InitPartsList()
    {
        PartsListData partsListData = JsonUtility.FromJson<PartsListData>(partsDatabase.text);
        foreach (PartData data in partsListData.data)
        {
            partsTable.Add(data.name, data);
        }
    }

    public PartData GetPartData(string partName)
    {
        if (partsTable.ContainsKey(partName))
        {
            return partsTable[partName];
        }
        return null;
    }

    public List<PartData> GetPartsByRarity(BasePart.RARITY rarity)
    {
        List<PartData> partsList = new List<PartData>();
        foreach (var key in partsTable.Keys)
        {
            PartData part = partsTable[key];
            if (part.rarity == (int)rarity)
            {
                partsList.Add(part);
            }
        }

        return partsList;
    }

    public List<PartData> GetPartsByType(BasePart.LIMB_TYPE type)  // change to enum
    {
        List<PartData> partsList = new List<PartData>();
        foreach (var key in partsTable.Keys)
        {
            PartData part = partsTable[key];
            if (type == BasePart.LIMB_TYPE.LIMB_END) // any part type
            {
                partsList.Add(part);
            }
            else if (part.partType == (int)type)
            {
                partsList.Add(part);
            }
        }

        return partsList;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
