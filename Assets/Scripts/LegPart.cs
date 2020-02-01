using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegPart : BasePart
{
    public float moveSped = 1.0f;

    override public void LoadTexture()
    {
        Texture2D tex = Resources.Load<Texture2D>("Textures/character_Leg_" + name);
        this.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.95f), 512);
    }
}
