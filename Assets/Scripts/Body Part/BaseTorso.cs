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

    void Awake()
    {
        l_LimbPosition.Add(new Vector3(0.0f, 1.0f, 9));
        l_LimbPosition.Add(new Vector3(0.46f, 0.7f, 12));
        l_LimbPosition.Add(new Vector3(-0.159f, 0.64f, 8));
        l_LimbPosition.Add(new Vector3(0.214f, -0.681f, 11));
        l_LimbPosition.Add(new Vector3(-0.29f, -0.55f, 9));
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void LoadTexture()
    {
        Texture2D tex = Resources.Load<Texture2D>("Textures/Torso/" + name);
        this.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 512);
    }
}