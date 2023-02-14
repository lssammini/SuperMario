using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movespeed;
    public float jumpForce;
    public bool onGround;

    private Rigidbody2D rb;
    private Animator anim;
    public int state;
    public bool hit = false;
    public float horizontal;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            onGround = false;
        }
    }

    private void FixedUpdate()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxisRaw("Jump");

        Vector2 movement = new Vector2(horizontal * movespeed, rb.velocity.y);

    

            if (horizontal > 0 )
            {
                state = 1;
                transform.localScale = new Vector3((float)-1, (float)1, (float)1);
            }
            else if (horizontal < 0 )
            {
                state = 1;
                transform.localScale = new Vector3((float)1, (float)1, (float)1);
            }
            else
            {
                state = 0;
            }

        if (Input.GetKey(key: KeyCode.F))
        {
            hit = true;
            state = 2;
        }

        if (onGround)
            {
                if (jump > 0.1f)
                {
                    movement.y = jumpForce;
                }
            }

        
        rb.velocity = movement;
    }

    private void Update()
    {

        if (!onGround)
        {
            state = 0;
        }
        anim.SetInteger("State", (int)state);
    }
}
