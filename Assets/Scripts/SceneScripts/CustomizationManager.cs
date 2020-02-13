using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationManager : MonoBehaviour
{
    [SerializeField]
    private Color RColor;
    [SerializeField]
    private Color SRColor;
    [SerializeField]
    private Color URColor;

    public GameObject prefabObj;
    public Transform characterDisplay;
    public RectTransform highlightPrefab;
    public GameObject rareIndicatorPrefab;
    public Text currencyText;

    public Transform headContentDisplay;
    public Transform torsoContentDisplay;
    public Transform armsContentDisplay;
    public Transform legsContentDisplay;

    public Transform[] equipmentSlots;

    public List<HeadPart> headList = new List<HeadPart>();
    public List<BaseTorso> torsoList = new List<BaseTorso>();
    public List<BasePart> limbList = new List<BasePart>();

    GameObject selectedFromInventory;
    int selectedFromEquippedIndex = (int)PlayerData.EQUIP_SLOT.EQUIP_END;
    Character displayingCharac;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = Instantiate(prefabObj);
        go.transform.parent = characterDisplay;
        go.transform.localScale = new Vector3(1, 1, 1);
        go.transform.localPosition = Vector3.zero;
        displayingCharac = go.GetComponent<Character>();

        string[] equippedLimbs = { PlayerData.instance.equipmentSlot[2], PlayerData.instance.equipmentSlot[3], PlayerData.instance.equipmentSlot[4], PlayerData.instance.equipmentSlot[5] };
        displayingCharac.Init(PlayerData.instance.equipmentSlot[0], PlayerData.instance.equipmentSlot[1], equippedLimbs);

        selectedFromInventory = null;
        selectedFromEquippedIndex = (int)PlayerData.EQUIP_SLOT.EQUIP_END;
        highlightPrefab = Instantiate(highlightPrefab);
        currencyText.text = PlayerData.instance.currency.ToString();

        LoadInventory();

        LoadEquippedItems();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectFromInventory(GameObject inventoryItem)
    {
        selectedFromInventory = inventoryItem;
        HighlightItem(inventoryItem);

        if (selectedFromEquippedIndex < (int)PlayerData.EQUIP_SLOT.EQUIP_END)
        {
            PartData partData1 = PartsTable.instance.GetPartData(selectedFromInventory.name);
            PartData partData2 = PartsTable.instance.GetPartData(equipmentSlots[selectedFromEquippedIndex].transform.GetChild(0).name);

            if (partData1.partType == partData2.partType)
            {
                SwapParts();
            }
        }
    }
    public void SelectFromEquipped(int slotIndex)
    {
        if (slotIndex >= (int)PlayerData.EQUIP_SLOT.EQUIP_END)
            return;

        selectedFromEquippedIndex = slotIndex;
        HighlightItem(equipmentSlots[slotIndex].GetChild(0).gameObject);



        if (selectedFromInventory != null)
        {
            PartData partData1 = PartsTable.instance.GetPartData(selectedFromInventory.name);
            PartData partData2 = PartsTable.instance.GetPartData(equipmentSlots[selectedFromEquippedIndex].transform.GetChild(0).name);

            if (partData1.partType == partData2.partType)
            {
                SwapParts();
            }
        }
    }

    public void SellPartFromInventory()
    {
        if (selectedFromInventory != null)
        {
            PartData partData = PartsTable.instance.GetPartData(selectedFromInventory.name);
            PlayerData.Instance.EarnCurrency(partData.price);
            currencyText.text = PlayerData.instance.currency.ToString();
            PlayerData.instance.RemoveItem(selectedFromInventory.name);
            PlayerData.Instance.SaveInventoryAndCurrencyToPlayerPrefs();

            Destroy(selectedFromInventory.transform.parent.gameObject);
            selectedFromInventory = null;
            highlightPrefab.gameObject.SetActive(false);
        }
    }

    void SwapParts()
    {
        //swaps item in playerData
        PlayerData.instance.equipmentSlot[selectedFromEquippedIndex] = selectedFromInventory.name;
        PlayerData.Instance.AddInventoryItem(equipmentSlots[selectedFromEquippedIndex].GetChild(0).name);
        PlayerData.Instance.RemoveItem(selectedFromInventory.name);
        PlayerData.Instance.SaveInventoryAndCurrencyToPlayerPrefs();
        PlayerData.Instance.SaveEquipment();

        {//swaps items for graphical purpose
            Transform itemFromEquipped = equipmentSlots[selectedFromEquippedIndex].GetChild(0);
            Transform itemFromInventoryParent = selectedFromInventory.transform.parent;

            itemFromEquipped.GetComponent<RectTransform>().SetParent(itemFromInventoryParent);
            selectedFromInventory.GetComponent<RectTransform>().SetParent(equipmentSlots[selectedFromEquippedIndex]);

            //equipmentSlots[selectedFromEquippedIndex].GetChild(0).GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 1);
            itemFromEquipped.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 1);
            itemFromEquipped.GetComponent<RectTransform>().sizeDelta = selectedFromInventory.GetComponent<RectTransform>().sizeDelta;
        }

        //reset characters equipped parts to show newly equipped parts
        string[] equippedLimbs = { PlayerData.instance.equipmentSlot[2], PlayerData.instance.equipmentSlot[3], PlayerData.instance.equipmentSlot[4], PlayerData.instance.equipmentSlot[5] };
        displayingCharac.Init(PlayerData.instance.equipmentSlot[0], PlayerData.instance.equipmentSlot[1], equippedLimbs);

        highlightPrefab.gameObject.SetActive(false);
        selectedFromInventory = null;
        selectedFromEquippedIndex = (int)PlayerData.EQUIP_SLOT.EQUIP_END;
    }

    private void CreateIndicatorFor(GameObject go, PartData part)
    {
        GameObject indicator = Instantiate(rareIndicatorPrefab);
        SetTextAndColor(indicator.GetComponent<Text>(), (BasePart.RARITY)(part.rarity));


        indicator.GetComponent<RectTransform>().SetParent(go.transform);
        indicator.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 1);
        indicator.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }

    private void SetTextAndColor(Text indicator, BasePart.RARITY rarity)
    {
        switch (rarity)
        {
            case BasePart.RARITY.RARITY_RARE:
                indicator.GetComponent<Text>().text = "R";
                indicator.GetComponent<Text>().color = RColor;
                break;
            case BasePart.RARITY.RARITY_SUPER_RARE:
                indicator.GetComponent<Text>().text = "SR";
                indicator.GetComponent<Text>().color = SRColor;
                break;
            case BasePart.RARITY.RARITY_ULTRA_RARE:
                indicator.GetComponent<Text>().text = "UR";
                indicator.GetComponent<Text>().color = URColor;
                break;

            default:
                break;
        }
    }

    void HighlightItem(GameObject go)
    {
        highlightPrefab.gameObject.SetActive(true);
        highlightPrefab.SetParent(go.transform);
        highlightPrefab.localScale = new Vector3(1, 1, 1);
        highlightPrefab.localPosition = new Vector3(0, 0, 1);
        //highlightPrefab.SetParent(null);
    }

    void LoadInventory()
    {
        List<string> inventory = PlayerData.instance.GetInventory();

        if (inventory == null || inventory.Count <= 0)
            return;

        foreach (string partName in inventory)
        {
            PartData partData = PartsTable.instance.GetPartData(partName);
            BasePart part = null;
            part = CreatePartAsImage(partData);
            Button btn = (new GameObject()).AddComponent<Button>();
            btn.onClick.AddListener(() => SelectFromInventory(part.gameObject));
            btn.gameObject.AddComponent<RectTransform>();
            part.GetComponent<RectTransform>().SetParent(btn.transform);
            part.GetComponent<RectTransform>().sizeDelta = btn.gameObject.GetComponent<RectTransform>().sizeDelta;

            switch ((BasePart.LIMB_TYPE)(partData.partType))
            {
                case BasePart.LIMB_TYPE.LIMB_HEAD:
                    part.gameObject.GetComponent<RectTransform>().SetParent(headContentDisplay);
                    break;

                case BasePart.LIMB_TYPE.LIMB_TORSO:
                    part.gameObject.GetComponent<RectTransform>().SetParent(torsoContentDisplay);
                    break;

                case BasePart.LIMB_TYPE.LIMB_ARM:
                    part.gameObject.GetComponent<RectTransform>().SetParent(armsContentDisplay);
                    break;

                case BasePart.LIMB_TYPE.LIMB_LEG:
                    part.gameObject.GetComponent<RectTransform>().SetParent(legsContentDisplay);
                    break;

                default:
                    break;
            }
            part.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    public void LoadAllItems()
    {
        foreach (Transform child in headContentDisplay)
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (Transform child in torsoContentDisplay)
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (Transform child in armsContentDisplay)
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (Transform child in legsContentDisplay)
        {
            GameObject.Destroy(child.gameObject);
        }

        List<PartData> partDataList = PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_END);

        foreach (PartData data in partDataList)
        {
            BasePart part = null;
            part = CreatePartAsImage(data);
            Button btn = (new GameObject()).AddComponent<Button>();
            btn.onClick.AddListener(() => SelectFromInventory(btn.transform.GetChild(0).gameObject));
            btn.gameObject.AddComponent<RectTransform>();
            switch ((BasePart.LIMB_TYPE)(data.partType))
            {
                case BasePart.LIMB_TYPE.LIMB_HEAD:
                    btn.gameObject.GetComponent<RectTransform>().SetParent(headContentDisplay);
                    break;

                case BasePart.LIMB_TYPE.LIMB_TORSO:
                    btn.gameObject.GetComponent<RectTransform>().SetParent(torsoContentDisplay);
                    break;

                case BasePart.LIMB_TYPE.LIMB_ARM:
                    btn.gameObject.GetComponent<RectTransform>().SetParent(armsContentDisplay);
                    break;

                case BasePart.LIMB_TYPE.LIMB_LEG:
                    btn.gameObject.GetComponent<RectTransform>().SetParent(legsContentDisplay);
                    break;

                default:
                    break;
            }

            part.GetComponent<RectTransform>().SetParent(btn.transform);
            part.GetComponent<RectTransform>().sizeDelta = btn.gameObject.GetComponent<RectTransform>().sizeDelta;

            btn.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    public void AddCurrency(int amount)
    {
        PlayerData.instance.EarnCurrency(amount);
        currencyText.text = PlayerData.instance.currency.ToString();
    }

    void LoadEquippedItems()
    {
        for (int i = 0; i < 6; ++i)
        {
            PartData data = PartsTable.instance.GetPartData(PlayerData.instance.equipmentSlot[i]);
            BasePart part = CreatePartAsImage(data);
            part.GetComponent<RectTransform>().SetParent(equipmentSlots[i]);
            part.GetComponent<RectTransform>().sizeDelta = equipmentSlots[i].gameObject.GetComponent<RectTransform>().sizeDelta;
            part.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            part.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
    }

    private BasePart CreatePartAsImage(PartData data)
    {
        BasePart part = BasePart.Create(data.name);
        Image img = part.gameObject.AddComponent<Image>(); //Add the Image Component script
        img.preserveAspect = true;
        img.sprite = part.GetComponent<SpriteRenderer>().sprite;
        Destroy(part.GetComponent<SpriteRenderer>());

        CreateIndicatorFor(img.gameObject, data);

        return part;
    }
}