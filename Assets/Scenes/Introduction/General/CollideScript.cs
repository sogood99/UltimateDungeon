using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideScript : MonoBehaviour
{
    public GameObject self;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject);
        if (self.tag != collision.tag)
        {
            self.GetComponent<SoldierScript>().attackFromCollider(collision.gameObject);
        }
        //Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        //rb.AddRelativeForce((rb.position - GetComponent<Rigidbody2D>().position).normalized * GetComponent<SoldierScript>().attackForce);
    }
}