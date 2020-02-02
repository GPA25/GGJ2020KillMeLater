using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTorso : BasePart
{
    // Speed will be affected by this
    public float movespdMult = 1.0f;

    // how fast the attack animation will be 
    public float atkSpdMult = 1.0f;

    // How Long before the next attack
    public float atkDelay = 1.0f;

    public float mass = 0.1f;

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void LoadTexture(string filename)
    {
        Texture2D tex = Resources.Load<Texture2D>("Textures/" + filename);
        this.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
    }
}