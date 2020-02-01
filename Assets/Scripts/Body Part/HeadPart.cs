using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadPart : BasePart
{
    override public void LoadTexture(string filename)
    {
        Texture2D tex = Resources.Load<Texture2D>("Textures/" + filename);
        this.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.05f), 512);
    }
}