using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGameObj : MonoBehaviour
{
    void Start()
    {
        if (GetComponentInParent<SoldierScript>().health <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
        else
        {
            GetComponent<KillGameObj>().enabled = false;
        }
    }
}
