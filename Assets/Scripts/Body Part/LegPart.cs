using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegPart : BasePart
{
    // ASH WHY GOT 2
    public float moveSpeed = 1.0f;

    override public void LoadTexture(string filename)
    {
        Texture2D tex = Resources.Load<Texture2D>("Textures/" + filename);
        this.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
    }

    public static LegPart Create(string name)
    {
        PartData part = PartsTable.Instance.GetPartData(name);

        GameObject go = new GameObject();
        go.name = name;
        go.AddComponent<SpriteRenderer>();
        go.AddComponent<LegPart>();
        go.GetComponent<LegPart>().name = name;
        go.GetComponent<LegPart>().LoadTexture(part.fileName);

        return go.GetComponent<LegPart>();
    }
    
    // ASH WHY GOT 2
    public float moveSpd = 1.0f;

}
