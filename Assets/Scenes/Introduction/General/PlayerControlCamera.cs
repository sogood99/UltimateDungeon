using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlCamera : MonoBehaviour
{
    private float x;
    private float y;
    public float speed = 10f;
    public float minX = 0f;
    public float maxX = 1000f;
    public float minY = 0f;
    public float maxY = 1000f;
    protected float yaw = 10f;
    protected float minYaw = 5f;
    protected float maxYaw = 15f;

    protected List<GameObject> gameSetObj = new List<GameObject>();
    void Update()
    {
        gameSetObj.AddRange(GameObject.FindGameObjectsWithTag("Ally"));
        gameSetObj.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + speed * x * Time.deltaTime, minX,maxX),Mathf.Clamp(transform.position.y+ speed * y * Time.deltaTime, minY, maxY));
    }

}
