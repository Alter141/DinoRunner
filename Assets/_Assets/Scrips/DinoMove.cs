using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DinoMove : MonoBehaviour
{
    public float jumpPower = 22f;
    private new Rigidbody2D rigidbody;
    public bool isGround;

    
    private void Awake()
    {
        isGround = true;
        Time.timeScale = 0;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
 
        if (Input.GetKey(KeyCode.Mouse0) && isGround)
        {
            GameCrtl.instance.StartGameDino();
            rigidbody.velocity = Vector2.up * jumpPower;
            isGround = false;
        }
        GameCrtl.instance.Score();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
} 
