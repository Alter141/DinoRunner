using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DinoMove : MonoBehaviour
{
    private Animator anim;
    public float jumpPower = 22f;
    private new Rigidbody2D rigidbody;
    public bool isGround;
    public bool onAir;
    public static bool fix; 
    
    private void Awake()
    {   
        fix = false;
        onAir = false;
        anim = GetComponent<Animator>();
        Time.timeScale = 0f;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.J) && !onAir)
        {
            fix = true;
            GameCrtl.instance.StartGameDino();
            rigidbody.velocity = Vector2.up * jumpPower;
            onAir = true;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && fix == true)
        {
            anim.SetTrigger("dino");
            rigidbody.velocity = Vector2.down * jumpPower;
        }

        else
        {
            isGround = true;
        }

        anim.SetBool("isGround", isGround);
        GameCrtl.instance.Score();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            onAir = false;
            isGround = true;
        }
    }
} 
