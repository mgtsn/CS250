using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim; 

    public Transform groundCheck;
    public float groundCheckRadius = .1f;
    public LayerMask whatIsGround;
    public bool isGrounded;

    public float moveSpeed = 10;
    public float jumpForce = 10;
    public float airSpeed = 6;

    public int direction;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        float x = Input.GetAxisRaw("Horizontal"); // * Time.deltaTime;
        float y = Input.GetAxisRaw("Vertical");

        if (x == 1 || x == -1)
        {
            if (y == 1)
            {
                direction = 2;
            } else if (y == -1)
            {
                direction = 4;
            } else
            {
                direction = 1;
            }
        } else if (x == 0)
        {
            if (y == 1)
            {
                direction = 3;
            }
            else if (y == -1)
            {
                direction = 5;
            }
            else
            {
                direction = 0;
            }
        }

        anim.SetInteger("Dir", direction);


        if (x > 0)
        {
            sprite.flipX = false;
        }
        else if (x < 0)
        {
            sprite.flipX = true;
        }

        if (isGrounded)
        {
            rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(x * airSpeed, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

    }
}