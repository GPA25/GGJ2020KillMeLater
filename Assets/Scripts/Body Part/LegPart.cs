using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegPart : BasePart
{

    public float moveSped = 1.0f;

    override public void LoadTexture()
    {
        Texture2D tex = Resources.Load<Texture2D>("Textures/Leg/" + name);
        this.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.95f), 512);
    }

    public static LegPart Create(string name)
    {
        GameObject go = new GameObject();
        go.name = name;
        go.AddComponent<SpriteRenderer>();
        go.AddComponent<LegPart>();
        go.GetComponent<LegPart>().name = name;
        go.GetComponent<LegPart>().LoadTexture();

        return go.GetComponent<LegPart>();
    }

    public float moveSpd = 1.0f;

}
