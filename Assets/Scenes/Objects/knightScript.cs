using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class knightScript : MonoBehaviour
{
    public int totalHealth = 1000;
    //private int health = 1000;
    public int attack = 10;
    public float attackForce = 5000f;
    public string FindWhat = "Enemy";
    public float reachDistance = 10f;
    public float attackCooldown = 0.5f;
    public float attackDuration = 0.5f;

    public GameObject focusGameObj()
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
    public void attackFunc(GameObject closest)
    {
        if ((closest.transform.position - transform.position).sqrMagnitude < reachDistance)
        {
            GetComponent<Animator>().SetBool("Attacking", true);
            Rigidbody2D rb = closest.GetComponent<Rigidbody2D>();
            rb.AddRelativeForce((rb.position - GetComponent<Rigidbody2D>().position).normalized * 10);
        }
        else
        {
            GetComponent<Animator>().SetBool("Attacking", false);
        }
    }
    public void setDestinatedPath(GameObject closest)
    {
        GetComponent<AIDestinationSetter>().target = closest.transform.Find("TrackPosition");
    }
    private void Update()
    {
        GameObject closest = focusGameObj();
        setDestinatedPath(closest);
        attackFunc(closest);
    }
}
