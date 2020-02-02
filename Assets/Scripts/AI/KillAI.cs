using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAI : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.root != this.transform.root)
        {
            BaseAI ai = collision.GetComponent<BaseAI>();
            ai.isAlive = false;
           
        }
        Debug.Log("pew");
    }
}
