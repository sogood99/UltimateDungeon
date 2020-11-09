using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 50f;
    public GameObject target;
    protected Animator anim;
    public int attack;
    protected bool hit = false;
    public bool faceOther = true;
    public string otherTag = "Fill";

    private void Start()
    {
        Vector3 diff = target.transform.position - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        if (faceOther)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
        GetComponent<Rigidbody2D>().velocity = speed * (target.GetComponent<Rigidbody2D>().position - GetComponent<Rigidbody2D>().position).normalized;
        anim = GetComponentInChildren<Animator>();
        Destroy(gameObject, 5f);
    }

//            if (collision.tag == otherTag)
//        {
//            anim.SetBool("Hit", true);
//            hit = true;
//            attackFunc(collision.gameObject);
//    Vector2 targetRB = collision.gameObject.GetComponent<Rigidbody2D>().position;
//    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(targetRB.x - transform.position.x, targetRB.y - transform.position.y).normalized* pushBack);
//}
//        else if (collision.tag != "Ally" && collision.tag != "Enemy" && collision.tag != "Dead")
//        {
//            anim.SetBool("Hit", true);
//            hit = true;
//        }
    private void FixedUpdate()
    {
        if (hit)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    public void attackFunc(GameObject other)
    {
        if (other.tag == "Enemy" || other.tag == "Ally")
        {
            other.GetComponent<SoldierScript>().health -= attack;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == otherTag)
        {
            anim.SetBool("Hit", true);
            hit = true;
            attackFunc(collision.gameObject);
        }else if (collision.gameObject.layer.Equals(8)&& collision.gameObject.tag != "NotBlockObstical")
        {
            anim.SetBool("Hit", true);
            hit = true;
        }
    }
}
