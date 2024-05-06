using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloundMove : MonoBehaviour
{
    private float speed = 1.4f;
    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
    }
}
