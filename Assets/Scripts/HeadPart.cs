using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadPart : BasePart
{
    override public void LoadTexture()
    {
        Texture2D tex = Resources.Load<Texture2D>("Textures/character_Head_" + name);
        this.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.05f), 512);
    }

    public static HeadPart Create(string name)
    {
        GameObject go = new GameObject();
        go.name = name;
        go.AddComponent<SpriteRenderer>();
        go.AddComponent<HeadPart>();
        go.GetComponent<HeadPart>().name = name;
        go.GetComponent<HeadPart>().LoadTexture();

        return go.GetComponent<HeadPart>();
    }
}
