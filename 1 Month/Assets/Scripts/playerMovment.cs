using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerMovment : MonoBehaviour
{
    Rigidbody2D body;


    float horizontal;
    float vertical;
    bool isWalking;
    bool leftClick;
    public float runSpeed = 5.0f;
    public Animator anim;
    public float baseAtackCoolDown = 0.5f;
    private float baseAtackNext = 0.15f;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        leftClick = Input.GetButton("Fire1");
    
    }

    private void FixedUpdate()
    {

        // movement stuff
        if (horizontal == 0 && vertical == 0) 
        { 
            anim.SetBool("isWalking", false);
        }
        if (horizontal != 0 )
        {
            anim.SetBool("isWalking", true);
        }
        if (vertical != 0)
        {
            anim.SetBool("isWalking", true);
        }
        if(leftClick) 
        {
            anim.SetBool("isWalking", false);
        }
        if (!leftClick)
        {
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
        if (leftClick)
        {
            body.velocity = new Vector2(0,0);
        } 

        if (leftClick == true && Time.time > baseAtackNext)
        {
            anim.SetBool("isAttakingBase", true);
            baseAtackNext = Time.time + baseAtackCoolDown;
        }
        if (leftClick == false)
        {
            anim.SetBool("isAttakingBase", false);
        }

        anim.SetFloat("MovingX", horizontal);
        anim.SetFloat("MovingY", vertical);
        
       
    }




}
