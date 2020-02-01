using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    BaseTorso torso = new BaseTorso();

    void Awake()
    {
        SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        Texture2D tex = Resources.Load<Texture2D>("Sprites/sprite01");
        sr.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}