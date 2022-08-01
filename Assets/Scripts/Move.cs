using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCollider;
    [SerializeField] private float jumpOffset;
    [SerializeField] private LayerMask groundMask;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = groundCollider.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
    }

    private void Update()
    {
        MovePlayer();
        Attack();
        Jump();
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {
            anim.SetBool("Walk", true);
        }
        else if (horizontal < 0)
        {
            anim.SetBool("Walk", true);
        }
        else if (horizontal == 0)
        {
            anim.SetBool("Walk", false);
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Attack()
    {
        float horizontal = Input.GetAxis("Horizontal"); 

        float attack = Input.GetAxis("Fire1");

        if (attack > 0)
        {
            anim.SetBool("Attack", true);
        }
        else if (attack < 0.3)
        {
            anim.SetBool("Attack", false);
        }

        float superAttack = Input.GetAxis("Fire2");

        if (superAttack > 0)
        {
            anim.SetBool("SuperAttack", true);
        }
        else if (superAttack < 0.3)
        {
            anim.SetBool("SuperAttack", false);
        }

        if((horizontal > 0 || horizontal < 0) & attack > 0)
        {
            anim.SetBool("RunAttack", true);
        }
        else
        {
            anim.SetBool("RunAttack", false);
        }
    }

    private void Jump()
    {
        bool jump = Input.GetButtonDown("Jump"); ;

        if (isGrounded & jump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (isGrounded == false)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
    }
}
