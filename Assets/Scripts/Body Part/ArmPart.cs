using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmPart : BasePart
{
    // Dmage the arm will do
    int damage = 1;

    // how long before the attack starts
    float windUpTime = 1.0f;

    // How fast the attack animation will be
    float attackSpeed = 1.0f;

    // How long to finish the attack
    float recoveryTime = 1.0f;

    // How Long before the next attack
    float attackDelay = 1.0f;

    override public void LoadTexture()
    {
        Texture2D tex = Resources.Load<Texture2D>("Textures/Arm/" + name);
        this.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.95f), 512);
    }
}
