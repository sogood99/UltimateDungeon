using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideScriptDemon : CollideScript
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (self.tag != collision.tag)
        {
            self.GetComponent<SoldierScript>().attackFromCollider(collision.gameObject);
        }
    }
}
