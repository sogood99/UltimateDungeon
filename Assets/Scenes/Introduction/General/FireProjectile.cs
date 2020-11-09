using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public GameObject projectile;
    public GameObject closest;
    public Transform shootPosition;

    private void OnEnable()
    {
        if (closest != null)
        {
            GameObject obj = Instantiate(projectile, shootPosition.position, Quaternion.identity);
            obj.GetComponent<Projectile>().target = closest;
            obj.GetComponent<Projectile>().otherTag = transform.parent.GetComponent<SoldierScript>().FindWhat;
            //if (transform.parent.tag == "Enemy")
            //{
            //    obj.GetComponent<Projectile>().otherTag = "Ally";
            //}
            //else if (transform.parent.tag == "Ally")
            //{
            //    obj.GetComponent<Projectile>().otherTag = "Enemy";
            //}
        }
    }
}
