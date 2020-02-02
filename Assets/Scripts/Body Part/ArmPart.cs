using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmPart : BasePart
{
    // Damage the arm will do
    public int damage = 1;

    // how long before the attack starts
    public float windUpTime = 1.0f;

    // How fast the attack animation will be
    public float attackSpeed = 1.0f;

    // How long to finish the attack
    public float recoveryTime = 1.0f;

    // How Long before the next attack
    public float attackDelay = 1.0f;

    // Range of the arm
    public float atkRange = 5.0f;

    public float knockback = 1.0f;

    override public void LoadTexture(string filename)
    {
        Texture2D tex = Resources.Load<Texture2D>("Textures/" + filename);
        this.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.root != this.transform.root)
        {
            Character charac =  collision.transform.GetComponent<Character>();

            if(charac != null)
            {
                Vector2 dir = collision.transform.root.position - this.transform.root.position;

                if (dir.x < 0)
                {
                    collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1.0f, 1.0f) * knockback, ForceMode2D.Impulse);
                }
                else
                {
                    collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(1.0f, 1.0f) * knockback, ForceMode2D.Impulse);
                }

            }
        }
    }
}
