using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeSoldierScript : SoldierScript
{
    public bool faceOther = true;
    public override void attackFunc(GameObject closest)
    {
        Transform graphic = anim.GetComponent<Transform>();
        if (faceOther && closest.transform.position.y > graphic.position.y)
        {
            Vector3 diff = closest.transform.position - graphic.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            if (closest.transform.position.x > graphic.position.x)
            {
                graphic.rotation = Quaternion.Euler(0f, 0f, rot_z);
            }
            else
            {
                graphic.rotation = Quaternion.Euler(0f, 0f, rot_z-180);
            }
        }
        else
        {
            graphic.rotation = Quaternion.identity;
        }

        if (closest.transform.position.x - transform.position.x > 0)
        {
            transform.localScale = new Vector3(gfx.normalScale, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(gfx.flippedScale, 1f, 1f);
        }
        if ((closest.transform.position - transform.position).sqrMagnitude < reachDistance)
        {
            GetComponentInChildren<FireProjectile>().closest = closest;
            anim.SetBool("Attacking", true);
        }
        else
        {
            anim.SetBool("Attacking", false);
        }
    }

}
