using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTorso : BasePart
{
    public int health = 1;

    // Speed will be affected by this
    public float movespdMult = 1.0f;

    // Damage will be affected by this
    public float damageMult = 1.0f;

    // how fast the attack animation will be 
    public float atkSpdMult = 1.0f;

    // How Long before the next attack
    public float atkDelay = 1.0f;

    // Positions of the limbs
    public List<Vector3> l_LimbPosition = new List<Vector3>();

    // list of attached limbs
    public List<BasePart> l_AttachedLimbs = new List<BasePart>();

    void Awake()
    {
        for(int i = 0; i < 4; ++i)
        {
            l_LimbPosition.Add(new Vector3());
        }
        LoadTexture();

        l_AttachedLimbs.Add(ArmPart.Create("Test"));
        l_AttachedLimbs.Add(ArmPart.Create("Test"));
        l_AttachedLimbs.Add(LegPart.Create("Test"));
        l_AttachedLimbs.Add(LegPart.Create("Test"));

        l_LimbPosition[0] = new Vector3(0.46f, 0.7f, 12);
        l_LimbPosition[1] = new Vector3(-0.08f, 0.64f, 8);
        l_LimbPosition[2] = new Vector3(0.37f, -0.55f, 11);
        l_LimbPosition[3] = new Vector3(-0.36f, -0.57f, 9);

        for(int i = 0; i < 4 ; ++i)
        {
            l_AttachedLimbs[i].transform.parent = this.transform;
            l_AttachedLimbs[i].transform.localPosition = l_LimbPosition[i];
            l_AttachedLimbs[i].GetComponent<SpriteRenderer>().sortingOrder = (int)(l_LimbPosition[i].z);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StorePartsInList()
    {
        foreach (BasePart go in GameObject.FindObjectsOfType<BasePart>())
        {
            if (go == this)
                continue;

            l_AttachedLimbs.Add(go);
        }
    }

    override public void LoadTexture()
    {
        Texture2D tex = Resources.Load<Texture2D>("Textures/character_Torso_" + name);
        this.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 512);
    }

    public static BaseTorso Create(string name)
    {
        GameObject go = new GameObject();
        go.name = name;
        go.AddComponent<SpriteRenderer>();
        go.AddComponent<BaseTorso>();
        go.GetComponent<BaseTorso>().name = name;
        go.GetComponent<BaseTorso>().LoadTexture();

        return go.GetComponent<BaseTorso>();
    }
}
