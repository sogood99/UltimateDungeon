using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttack : MonoBehaviour
{
    public GameObject skeletonPrefab;

    private string pntTg;
    

    private void OnEnable()
    {
        pntTg = transform.parent.gameObject.tag;
        Instantiate(skeletonPrefab, transform.position + new Vector3(0, -5), Quaternion.identity).tag = pntTg;
        Instantiate(skeletonPrefab, transform.position + new Vector3(0, 5), Quaternion.identity).tag = pntTg;
        Instantiate(skeletonPrefab, transform.position + new Vector3(5, 0), Quaternion.identity).tag = pntTg;
        Instantiate(skeletonPrefab, transform.position + new Vector3(-5, 0), Quaternion.identity).tag = pntTg;
    }
}
