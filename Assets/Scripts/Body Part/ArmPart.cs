using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmPart : BasePart
{
    // Dmage the arm will do
    public int damage = 1;

    // how long before the attack starts
    public float windUpTime = 1.0f;

    // How fast the attack animation will be
    public float attackSpeed = 1.0f;

    // How long to finish the attack
    public float recoveryTime = 1.0f;

    // How Long before the next attack
    public float attackDelay = 1.0f;

    override public void LoadTexture(string filename)
    {
        Texture2D tex = Resources.Load<Texture2D>("Textures/" + filename);
        this.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
    }
}
