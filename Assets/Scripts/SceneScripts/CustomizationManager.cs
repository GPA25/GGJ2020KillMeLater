using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationManager : MonoBehaviour
{
    public GameObject prefabObj;
    public Transform characterDisplay;

    public Transform headContentDisplay;
    public Transform torsoContentDisplay;
    public Transform limbsContentDisplay;

    public Transform headSlot;
    public Transform torsoSlot;
    public Transform leftArmSlot;
    public Transform rightArmSlot;
    public Transform leftLegSlot;
    public Transform rightLegSlot;

    public List<HeadPart> headList = new List<HeadPart>();
    public List<BaseTorso> torsoList = new List<BaseTorso>();
    public List<BasePart> limbList = new List<BasePart>();

    string selectedFromInventory;
    string selectedFromEquipped;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = Instantiate(prefabObj);
        go.transform.parent = characterDisplay;
        go.transform.localScale = new Vector3(1, 1, 1);
        go.transform.localPosition = Vector3.zero;
        Character charac = go.GetComponent<Character>();

        string[] equippedLimbs = {PlayerData.instance.equippedLeftArm, PlayerData.instance.equippedRightArm, PlayerData.instance.equippedLeftLeg, PlayerData.instance.equippedRightLeg};
        charac.Init(PlayerData.instance.equippedHead, PlayerData.instance.equippedTorso, equippedLimbs);

        LoadAllItems();
        
        LoadEquippedItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectFromInventory(string partName)
    {
        selectedFromInventory = partName;
    }
    public void SelectFromEquipped(GameObject go)
    {
        selectedFromEquipped = go.transform.GetChild(0).name;
    }

    void LoadAllItems()
    {
        List<PartData> partDataList = PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_END);
        
        foreach(PartData data in partDataList)
        {
            GameObject go = new GameObject(); //Create the GameObject
            go.name = data.name;
            Button btn = go.AddComponent<Button>();
            btn.onClick.AddListener(() => SelectFromInventory(go.name));
            Image img = go.AddComponent<Image>(); //Add the Image Component script
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
            PartData data = PartsTable.instance.GetPartData(PlayerData.instance.equippedHead);
            GameObject go = new GameObject(); //Create the GameObject
            go.name = data.name;
            Image img = go.AddComponent<Image>(); //Add the Image Component script
            Texture2D tex = Resources.Load<Texture2D>("Textures/" + data.fileName);
            img.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            go.SetActive(true); //Activate the GameObject
            go.GetComponent<RectTransform>().SetParent(headSlot);
            go.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            go.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
        {//torso slot
            PartData data = PartsTable.instance.GetPartData(PlayerData.instance.equippedTorso);
            GameObject go = new GameObject(); //Create the GameObject
            go.name = data.name;
            Image img = go.AddComponent<Image>(); //Add the Image Component script
            Texture2D tex = Resources.Load<Texture2D>("Textures/" + data.fileName);
            img.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            go.SetActive(true); //Activate the GameObject
            go.GetComponent<RectTransform>().SetParent(torsoSlot);
            go.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            go.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
        {//leftArm slot
            PartData data = PartsTable.instance.GetPartData(PlayerData.instance.equippedLeftArm);
            GameObject go = new GameObject(); //Create the GameObject
            go.name = data.name;
            Image img = go.AddComponent<Image>(); //Add the Image Component script
            Texture2D tex = Resources.Load<Texture2D>("Textures/" + data.fileName);
            img.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            go.SetActive(true); //Activate the GameObject
            go.GetComponent<RectTransform>().SetParent(leftArmSlot);
            go.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            go.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
        {//rightArm slot
            PartData data = PartsTable.instance.GetPartData(PlayerData.instance.equippedRightArm);
            GameObject go = new GameObject(); //Create the GameObject
            go.name = data.name;
            Image img = go.AddComponent<Image>(); //Add the Image Component script
            Texture2D tex = Resources.Load<Texture2D>("Textures/" + data.fileName);
            img.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            go.SetActive(true); //Activate the GameObject
            go.GetComponent<RectTransform>().SetParent(rightArmSlot);
            go.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            go.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
        {//leftLeg slot
            PartData data = PartsTable.instance.GetPartData(PlayerData.instance.equippedLeftLeg);
            GameObject go = new GameObject(); //Create the GameObject
            go.name = data.name;
            Image img = go.AddComponent<Image>(); //Add the Image Component script
            Texture2D tex = Resources.Load<Texture2D>("Textures/" + data.fileName);
            img.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            go.SetActive(true); //Activate the GameObject
            go.GetComponent<RectTransform>().SetParent(leftLegSlot);
            go.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            go.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
        {//rightLeg slot
            PartData data = PartsTable.instance.GetPartData(PlayerData.instance.equippedRightLeg);
            GameObject go = new GameObject(); //Create the GameObject
            go.name = data.name;
            Image img = go.AddComponent<Image>(); //Add the Image Component script
            Texture2D tex = Resources.Load<Texture2D>("Textures/" + data.fileName);
            img.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            go.SetActive(true); //Activate the GameObject
            go.GetComponent<RectTransform>().SetParent(rightLegSlot);
            go.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            go.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
    }
}