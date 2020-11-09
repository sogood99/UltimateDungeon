using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SoldierScript : MonoBehaviour
{
    public int totalHealth = 500;
    public int health = 500;
    public int attack = 20;
    public float attackForce = 1000f;
    public string FindWhat = "Fill";
    public float reachDistance = 4f;
    public Animator anim;
    protected Graphics gfx;
    protected Vector3 originalScale;

    public virtual GameObject focusGameObj()
    {
        GameObject[] gameSet;
        gameSet = GameObject.FindGameObjectsWithTag(FindWhat);
        float distance = Mathf.Infinity;
        GameObject closest = null;
        Vector3 position = transform.position;
        foreach (GameObject gameObj in gameSet)
        {
            float nextDist = (gameObj.transform.position - position).sqrMagnitude;
            if (nextDist < distance)
            {
                closest = gameObj;
                distance = nextDist;
            }
        }
        return closest;
    }

    public virtual string setFindWhat(string tg)
    {
        if (tg == "Enemy")
        {
            return "Ally";
        }
        else if (tg == "Ally")
        {
            return "Enemy";
        }
        return "Fill";
    }

    private void Start()
    {
        anim.SetBool("Dead", false);
        gfx = GetComponentInChildren<Graphics>();
        FindWhat = setFindWhat(tag);
        originalScale = transform.localScale;
    }

    public virtual void attackFunc(GameObject closest)
    {
        if (closest.transform.position.x - transform.position.x > 0.01f)
        {
            transform.localScale = new Vector3(gfx.normalScale, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(gfx.flippedScale, 1f, 1f);
        }
        if ((closest.transform.position - transform.position).sqrMagnitude<reachDistance)
        {
            anim.SetBool("Attacking", true);
        }
        else
        {
            anim.SetBool("Attacking", false);
        }
    }

    public void attackFromCollider(GameObject other)
    {
        if (other.GetComponent<SoldierScript>())
        {
            other.GetComponent<SoldierScript>().health -= attack;
        }
    }

    public virtual void setDestinatedPath(GameObject closest)
    {
        if ((closest.transform.Find("TrackPositionBack").position - transform.position).sqrMagnitude < (closest.transform.Find("TrackPositionFront").position - transform.position).sqrMagnitude)
        {
            GetComponent<AIDestinationSetter>().target = closest.transform.Find("TrackPositionBack");
        }
        else
        {
            GetComponent<AIDestinationSetter>().target = closest.transform.Find("TrackPositionFront");
        }
    }
    private void Update()
    {
        health = Mathf.Clamp(health, -10, totalHealth);
        if (health > 0)
        {
            FindWhat = setFindWhat(tag);
            GameObject closest = focusGameObj();
            if (closest != null)
            {
                //Debug.Log(closest);
                setDestinatedPath(closest);
                attackFunc(closest);
            }
            else
            {
                anim.SetBool("Attacking", false);
            }
        }
        else
        {
            transform.gameObject.tag = "Dead";
            anim.SetBool("Dead", true);
            GetComponent<AIPath>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            transform.Find("HealthBar").gameObject.SetActive(false);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
