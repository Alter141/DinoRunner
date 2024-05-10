using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DinoMove : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxUp;
    [SerializeField] private BoxCollider2D boxDown;
    private Animator anim;
    public float jumpPower = 22f;
    private new Rigidbody2D rigidbody;
    public bool isGround;
    public bool onAir;

    
    private void Awake()
    {   
        boxUp.enabled = true;
        boxDown.enabled = false;
        onAir = false;
        anim = GetComponent<Animator>();
        Time.timeScale = 0;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0) && !onAir)
        {
          
            GameCrtl.instance.StartGameDino();
            rigidbody.velocity = Vector2.up * jumpPower;
            onAir = true;

        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {   
            anim.SetTrigger("dino");
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
