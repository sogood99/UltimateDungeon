using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Graphics : MonoBehaviour
{
    public AIPath aiPath;
    public Animator animator;
    public Transform healthBar;
    public SoldierScript self;
    //public bool flipped = false;
    public float normalScale = 1f;
    public float flippedScale = -1f;//for demon
    protected Vector3 bar;
    //private Vector3 bar;

    private void Start()
    {
        bar = healthBar.transform.localScale;
    }

    void Update()
    {
        //Debug.Log(healthBar.parent.gameObject);
        animator.SetFloat("Speed", aiPath.desiredVelocity.sqrMagnitude);
        //if (aiPath.desiredVelocity.x > 0f)
        //{
        //    transform.localScale = new Vector3(normalScale, 1f, 1f);
        //}
        //else if (aiPath.desiredVelocity.x < -0f) 
        //{
        //    transform.localScale = new Vector3(flippedScale, 1f, 1f);
        //    //healthBar.GetComponentInParent<Transform>().GetComponentInParent<Transform>().localScale = new Vector3(-bar.x, bar.y, bar.z);
        //}
        if (transform.localScale.x < 0)
        {
            healthBar.localScale = new Vector3(-bar.x, bar.y, bar.z);
        }
        else
        {
            healthBar.localScale = new Vector3(bar.x, bar.y, bar.z);
        }
        healthBar.Find("Bar").localScale = new Vector3(Mathf.Clamp(self.health / (float)self.totalHealth, 0, 1), healthBar.localScale.y);
        //healthBar.localScale = new Vector3(Mathf.Clamp(self.health / (float)self.totalHealth, 0, 1), healthBar.localScale.y);
    }
}
