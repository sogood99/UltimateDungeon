using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeSoldierScriptHealer : RangeSoldierScript
{
    public override GameObject focusGameObj()
    {
        GameObject[] gameSet;
        gameSet = GameObject.FindGameObjectsWithTag(FindWhat);
        float distance = Mathf.Infinity;
        GameObject closest = null;
        Vector3 position = transform.position;
        foreach (GameObject gameObj in gameSet)
        {
            if (gameObj != gameObject)
            {
                if ((gameObj.GetComponent<SoldierScript>().health < gameObj.GetComponent<SoldierScript>().totalHealth))
                {
                    float nextDist = (gameObj.transform.position - position).sqrMagnitude;
                    if (nextDist < distance)
                    {
                        closest = gameObj;
                        distance = nextDist;
                    }
                }
            }
        }
        if (closest == null)
        {
            foreach (GameObject gameObj in gameSet)
            {
                if (gameObj != gameObject && !gameObj.GetComponent<RangeSoldierScriptHealer>())
                {
                    float nextDist = (gameObj.transform.position - position).sqrMagnitude;
                    if (nextDist < distance)
                    {
                        closest = gameObj;
                        distance = nextDist;
                    }
                }
            }
        }
        return closest;
    }
    public override string setFindWhat(string tg)
    {
        return tg;
    }
}
