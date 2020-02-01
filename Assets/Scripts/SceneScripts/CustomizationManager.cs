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

    public List<HeadPart> headList = new List<HeadPart>();
    public List<BaseTorso> torsoList = new List<BaseTorso>();
    public List<BasePart> limbList = new List<BasePart>();

    BasePart selectedPart;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = Instantiate(prefabObj);
        go.transform.parent = characterDisplay;
        go.transform.localScale = new Vector3(1, 1, 1);
        go.transform.localPosition = Vector3.zero;
        Character charac = go.GetComponent<Character>();

        LoadAllItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadAllItems()
    {
        List<PartData> partDataList = PartsTable.instance.GetPartsByType(BasePart.LIMB_TYPE.LIMB_END);
        Debug.Log(partDataList.Count);
        foreach(PartData data in partDataList)
        {
            GameObject go = new GameObject(); //Create the GameObject
            go.name = data.name;
            go.AddComponent<Button>();
            Image img = go.AddComponent<Image>(); //Add the Image Component script
            Texture2D tex = Resources.Load<Texture2D>("Textures/" + data.fileName);
            img.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 1000);
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
}