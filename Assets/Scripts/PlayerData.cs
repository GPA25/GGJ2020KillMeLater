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
        equipmentSlot = new string[6];

        equipmentSlot[(int)EQUIP_SLOT.EQUIP_HEAD] = PlayerPrefs.GetString("equippedHead", "Base Head");
        equipmentSlot[(int)EQUIP_SLOT.EQUIP_TORSO] = PlayerPrefs.GetString("equippedTorso", "Base Torso");
        equipmentSlot[(int)EQUIP_SLOT.EQUIP_LA] = PlayerPrefs.GetString("equippedLeftArm", "Base Arm");
        equipmentSlot[(int)EQUIP_SLOT.EQUIP_RA] = PlayerPrefs.GetString("equippedRightArm", "Base Arm");
        equipmentSlot[(int)EQUIP_SLOT.EQUIP_LL] = PlayerPrefs.GetString("equippedLeftLeg", "Base Leg");
        equipmentSlot[(int)EQUIP_SLOT.EQUIP_RL] = PlayerPrefs.GetString("equippedRightLeg", "Base Leg");
    }

    public enum EQUIP_SLOT
    {
        EQUIP_HEAD,
        EQUIP_TORSO,
        EQUIP_LA,
        EQUIP_RA,
        EQUIP_LL,
        EQUIP_RL,

        EQUIP_END
    }

    public string name;
    public int currency;

    public string[] equipmentSlot;

    private List<string> inventory;     // list of names of parts in Inventory
    [SerializeField]
    private int maxInventorySize = 30;  // temporary

    public List<string> GetInventory()
    {
        return inventory;
    }

    public void SaveInventoryToPlayerPrefs()
    {
        PlayerPrefs.SetInt("inventorySize", inventory.Count);

        for (int i = 0; i < maxInventorySize; i++)
        {
            if (i < inventory.Count)    // inventory item
            {
                PlayerPrefs.SetString("inventory_" + i, inventory[i]);
            }
            else    // blank slot
            {
                PlayerPrefs.SetString("inventory_" + i, "");
            }
        }

        Debug.Log("Inventory Saved.");
        PlayerPrefs.Save();
    }

    private bool IsInventoryFull()
    {
        return inventory.Count == maxInventorySize;
    }

    public bool CheckInventoryCapacityRemaining(int count)
    {
        return ((inventory.Count + count) <= maxInventorySize);
    }

    public bool AddInventoryItem(string newItem)
    {
        if (IsInventoryFull())
        {
            Debug.Log("Inventory full!");
            return false;
        }

        inventory.Add(newItem);
        return true;
    }

    public void SwapInventoryItemWithEquip(int slotId, string prevEquipItem)
    {
        inventory[slotId] = prevEquipItem;
    }

    // Start is called before the first frame update
    void Start()
    {
        ReadInventoryFromPlayerPrefs();
    }

    private void ReadInventoryFromPlayerPrefs()
    {
        inventory = new List<string>();

        int invSize = PlayerPrefs.GetInt("inventorySize", inventory.Count);
        for (int i = 0; i < maxInventorySize; i++)
        {
            string item = PlayerPrefs.GetString("inventory_" + i, "");
            if (!string.IsNullOrEmpty(item))
            {
                inventory.Add(item);
                Debug.Log("Inventory: " + item);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
