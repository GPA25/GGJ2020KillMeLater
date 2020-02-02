using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationManager : MonoBehaviour
{
    public GameObject prefabObj;
    public Transform characterDisplay;
    public GameObject highlightPrefab;

    public Transform headContentDisplay;
    public Transform torsoContentDisplay;
    public Transform limbsContentDisplay;

    public Transform[] equipmentSlots;

    public List<HeadPart> headList = new List<HeadPart>();
    public List<BaseTorso> torsoList = new List<BaseTorso>();
    public List<BasePart> limbList = new List<BasePart>();

    GameObject selectedFromInventory;
    int selectedFromEquippedIndex;
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

        highlightPrefab = Instantiate(highlightPrefab);

        LoadAllItems();
        
        LoadEquippedItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectFromInventory(GameObject partName)
    {
        selectedFromInventory = partName;
        highlightPrefab.SetActive(true);
        highlightPrefab.transform.parent = partName.transform;
        highlightPrefab.transform.localScale = new Vector3(1, 1, 1);
        highlightPrefab.transform.localPosition = new Vector3(0, 0, 1);

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
        selectedFromEquippedIndex = slotIndex;
        highlightPrefab.SetActive(true);
        highlightPrefab.transform.parent = equipmentSlots[slotIndex].transform;
        highlightPrefab.transform.localScale = new Vector3(1, 1, 1);
        highlightPrefab.transform.localPosition = new Vector3(0, 0, 1);

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

    void SwapParts()
    {
        Sprite tempoSprite = equipmentSlots[selectedFromEquippedIndex].transform.GetChild(0).GetComponent<Image>().sprite;
        equipmentSlots[selectedFromEquippedIndex].transform.GetChild(0).GetComponent<Image>().sprite = selectedFromInventory.GetComponent<Image>().sprite;
        selectedFromInventory.GetComponent<Image>().sprite = tempoSprite;
        string tempoName = equipmentSlots[selectedFromEquippedIndex].transform.GetChild(0).name;
        equipmentSlots[selectedFromEquippedIndex].transform.GetChild(0).name = selectedFromInventory.name;
        selectedFromInventory.name = tempoName;

        PlayerData.instance.equipmentSlot[selectedFromEquippedIndex] = equipmentSlots[selectedFromEquippedIndex].transform.GetChild(0).name;

        string[] equippedLimbs = { PlayerData.instance.equipmentSlot[2], PlayerData.instance.equipmentSlot[3], PlayerData.instance.equipmentSlot[4], PlayerData.instance.equipmentSlot[5] };
        displayingCharac.Init(PlayerData.instance.equipmentSlot[0], PlayerData.instance.equipmentSlot[1], equippedLimbs);

        selectedFromInventory = null;
        selectedFromEquippedIndex = (int)PlayerData.EQUIP_SLOT.EQUIP_END;
        highlightPrefab.SetActive(false);
    }

    void LoadAllItems()
    {
        List<PartData> partDataList = PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_END);
        
        foreach(PartData data in partDataList)
        {
            GameObject go = new GameObject(); //Create the GameObject
            go.name = data.name;
            Button btn = go.AddComponent<Button>();
            btn.onClick.AddListener(() => SelectFromInventory(go));
            Image img = go.AddComponent<Image>(); //Add the Image Component script
            img.preserveAspect = true;
            Texture2D tex = Resources.Load<Texture2D>("Textures/" + data.fileName);
            img.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            go.SetActive(true); //Activate the GameObject
            switch((BasePart.LIMB_TYPE)(data.partType))
            {
                case BasePart.LIMB_TYPE.LIMB_HEAD:
                    go.GetComponent<RectTransform>().SetParent(headContentDisplay);
                break;

                case BasePart.LIMB_TYPE.LIMB_TORSO:
                    go.GetComponent<RectTransform>().SetParent(torsoContentDisplay);
                break;

                case BasePart.LIMB_TYPE.LIMB_ARM:
                case BasePart.LIMB_TYPE.LIMB_LEG:
                    go.GetComponent<RectTransform>().SetParent(limbsContentDisplay);
                break;

                default:
                break;
            }
            go.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    void LoadEquippedItems()
    {
        {//head slot
            PartData data = PartsTable.instance.GetPartData(PlayerData.instance.equipmentSlot[0]);
            GameObject go = new GameObject(); //Create the GameObject
            go.name = data.name;
            Image img = go.AddComponent<Image>(); //Add the Image Component script
            img.preserveAspect = true;
            Texture2D tex = Resources.Load<Texture2D>("Textures/" + data.fileName);
            img.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            go.SetActive(true); //Activate the GameObject
            go.GetComponent<RectTransform>().SetParent(equipmentSlots[0]);
            go.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            go.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
        {//torso slot
            PartData data = PartsTable.instance.GetPartData(PlayerData.instance.equipmentSlot[1]);
            GameObject go = new GameObject(); //Create the GameObject
            go.name = data.name;
            Image img = go.AddComponent<Image>(); //Add the Image Component script
            img.preserveAspect = true;
            Texture2D tex = Resources.Load<Texture2D>("Textures/" + data.fileName);
            img.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            go.SetActive(true); //Activate the GameObject
            go.GetComponent<RectTransform>().SetParent(equipmentSlots[1]);
            go.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            go.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
        {//leftArm slot
            PartData data = PartsTable.instance.GetPartData(PlayerData.instance.equipmentSlot[2]);
            GameObject go = new GameObject(); //Create the GameObject
            go.name = data.name;
            Image img = go.AddComponent<Image>(); //Add the Image Component script
            img.preserveAspect = true;
            Texture2D tex = Resources.Load<Texture2D>("Textures/" + data.fileName);
            img.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            go.SetActive(true); //Activate the GameObject
            go.GetComponent<RectTransform>().SetParent(equipmentSlots[2]);
            go.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            go.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
        {//rightArm slot
            PartData data = PartsTable.instance.GetPartData(PlayerData.instance.equipmentSlot[3]);
            GameObject go = new GameObject(); //Create the GameObject
            go.name = data.name;
            Image img = go.AddComponent<Image>(); //Add the Image Component script
            img.preserveAspect = true;
            Texture2D tex = Resources.Load<Texture2D>("Textures/" + data.fileName);
            img.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            go.SetActive(true); //Activate the GameObject
            go.GetComponent<RectTransform>().SetParent(equipmentSlots[3]);
            go.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            go.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
        {//leftLeg slot
            PartData data = PartsTable.instance.GetPartData(PlayerData.instance.equipmentSlot[4]);
            GameObject go = new GameObject(); //Create the GameObject
            go.name = data.name;
            Image img = go.AddComponent<Image>(); //Add the Image Component script
            img.preserveAspect = true;
            Texture2D tex = Resources.Load<Texture2D>("Textures/" + data.fileName);
            img.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            go.SetActive(true); //Activate the GameObject
            go.GetComponent<RectTransform>().SetParent(equipmentSlots[4]);
            go.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            go.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
        {//rightLeg slot
            PartData data = PartsTable.instance.GetPartData(PlayerData.instance.equipmentSlot[5]);
            GameObject go = new GameObject(); //Create the GameObject
            go.name = data.name;
            Image img = go.AddComponent<Image>(); //Add the Image Component script
            img.preserveAspect = true;
            Texture2D tex = Resources.Load<Texture2D>("Textures/" + data.fileName);
            img.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            go.SetActive(true); //Activate the GameObject
            go.GetComponent<RectTransform>().SetParent(equipmentSlots[5]);
            go.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            go.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
    }
}