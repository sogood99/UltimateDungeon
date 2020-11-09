using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombProjectile : Projectile
{
    public float pushBack = 250f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == otherTag)
        {
            anim.SetBool("Hit", true);
            hit = true;
            attackFunc(collision.gameObject);
            gameObject.GetComponent<Collider2D>().enabled = false;
            Vector2 targetRB = collision.gameObject.GetComponent<Rigidbody2D>().position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(targetRB.x - transform.position.x, targetRB.y - transform.position.y).normalized * pushBack);
        }
        else if (collision.gameObject.layer.Equals(8) && collision.gameObject.tag != "NotBlockObstical")
        {
            anim.SetBool("Hit", true);
            hit = true;
        }
    }
}

