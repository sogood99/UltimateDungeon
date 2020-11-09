using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideScriptHammer : CollideScript
{
	private int count = 0;
    private float timeLapse;

    private void Start()
    {
        timeLapse = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
        //Debug.Log(Time.time - timeLapse);
        if (self.tag != collision.tag)
        {
            self.GetComponent<SoldierScript>().attackFromCollider(collision.gameObject);
            if (count == 1)
            {
                self.GetComponent<SoldierScript>().attackFromCollider(collision.gameObject);
            }
        }
        if (Time.time - timeLapse > 1.5f)
        {
            count = 0;
        }
        timeLapse = Time.time;
		count++;
		count = count % 3;
	}
}
