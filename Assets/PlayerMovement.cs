using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movespeed;
    public float jumpForce;
    public bool onGround;
    public HealthBar healthBar;
    private Rigidbody2D rb;
    private Animator anim;
    private float health = 100f;
    public int state;
    public bool hit = false;
    public float horizontal;
    public float damage;
    public bool onEnemy;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
    void MakeDamage(float damage)
    {
        health -= damage;
        healthBar.UpdateHealth(health);
    }

    private void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            onGround = true;
        }
        if (collision.CompareTag("Player2") && hit)
        {
            onEnemy = true;
        }
    }

    private void StopHit()
    {
        hit = false;
        Debug.Log("Stop hitting");
   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            onGround = false;
        }
        if (collision.CompareTag("Player2"))
        {
            onEnemy = false;
        }

    }

    private void FixedUpdate()
    {
        // Detecta as teclas pressionadas
        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1f;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1f;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            horizontal = 0f;
        }

        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

       

        // Atualiza a posição do personagem
        Vector2 movement = new Vector2(horizontal * movespeed, rb.velocity.y);
        rb.velocity = movement;
    }

    private void Attack() 
    {
        hit = true;
        anim.SetTrigger("Attack");

       
    }


    private void Update()
    {
        if (onEnemy && hit)
        {
            Debug.Log("hit");
        }
        if (Input.GetKey(KeyCode.F))
        {
            //hit = true;
            //MakeDamage(damage);
            Attack();
        }

        if (!onGround && rb.velocity.y > 0)
        {
            state = 2; // Set the state to "Jump" when the character is going up
        }
        else if (!onGround && rb.velocity.y < 0)
        {
            state = 3; // Set the state to "Fall" when the character is falling
        }
        else if (onGround && state != 2 && horizontal == 0)
        {
            state = 0; // Set the state to "Idle" when the character is on the ground and not moving
        }
        else if (onGround && state != 2 && horizontal != 0)
        {
            state = 1; // Set the state to "Move" when the character is on the ground and moving
        }

        anim.SetInteger("State", (int)state);
    }


}
