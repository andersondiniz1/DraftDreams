using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    public Rigidbody2D rb;

    public int moveSpeed;
    private float direction;

    public int jumpForce;
    private int dobleJump = 1;

    public bool inGround;
    public Transform groundChek;
    public Transform detectWall;
    public LayerMask whatIsGround;
    public float radius = 0.2f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {

        inGround = Physics2D.OverlapCircle(groundChek.position, radius, whatIsGround);
        //inGround = Physics2D.OverlapCircle(detectWall.position, radius, whatIsGround);



        Move();
        Jump();

    }


    void Move()
    {
        direction = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

        //float inputAxis = Input.GetAxis("Horizontal");

        if (direction > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        if (direction < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }

    }

    void Jump()
    {
        //pula se o player estiver no chão
        if (Input.GetButtonDown("Jump") && inGround == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        }
        //segundo pulo se o player já estiver no ar
        if (Input.GetButtonDown("Jump") && inGround == false && dobleJump > 0)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            dobleJump--;
        }
        if (inGround)
        {
            dobleJump = 1;
        }
    }
}
