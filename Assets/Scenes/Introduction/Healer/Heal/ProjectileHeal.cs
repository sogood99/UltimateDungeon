using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHeal : Projectile
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            anim.SetBool("Hit", true);
            hit = true;
            attackFunc(collision.gameObject);
        }
        else if (collision.gameObject.layer.Equals(8) && collision.gameObject.tag != "NotBlockObstical")
        {
            anim.SetBool("Hit", true);
            hit = true;
        }
    }
}
