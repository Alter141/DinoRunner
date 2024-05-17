using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{
    public static float speed = 16f;
    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dino")
        {
            GameCrtl.instance.GameOver();
        }
    }
}
