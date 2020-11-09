using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWizard : MonoBehaviour
{
    protected float time;
    public GameObject wizardPrefab;
    protected Vector3 pos1 = new Vector3(62.3f, 17.5f);
    protected Vector3 pos2 = new Vector3(62.3f, 27.7f);
    public float deltaTime;
    void Start()
    {
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - time > deltaTime)
        {
            time = Time.time;
            Debug.Log("sike");
            Instantiate(wizardPrefab, pos1, Quaternion.identity);
            Instantiate(wizardPrefab, pos2, Quaternion.identity);
        }
    }
}
