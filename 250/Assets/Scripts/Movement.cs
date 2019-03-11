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
    public GameObject beam;
    public float cooldown = .7f;
    public float cdcount = 0;


    void Shoot()
    {
        float n = 0;
        float x = 0;
        float y = 0;
        if (sprite.flipX)
        {
            if (direction == 0)
            {
                n = 180;
                x = -.5f;
            }
            else if (direction == 1)
            {
                n = 180;
                x = -.5f;
            }
            else if (direction == 2)
            {
                n = 135;
                x = -.35f;
                y = .35f;
            }
            else if (direction == 3)
            {
                n = 90;
                y = .5f;

            }
            else if (direction == 4)
            {
                n = 225;
                x = -.35f;
                y = -.35f;
            }
            else if (direction == 5)
            {
                n = 270;
                y = -1f;
            }
        }
        else
        {
            if (direction == 0)
            {
                n = 0;
                x = .5f;
            }
            else if (direction == 1)
            {
                n = 0;
                x = .5f;
            }
            else if (direction == 2)
            {
                n = 45;
                x = .35f;
                y = .35f;
            }
            else if (direction == 3)
            {
                n = 90;
                y = .5f;
            }
            else if (direction == 4)
            {
                n = 315;
                x = .35f;
                y = -.35f;
            }
            else if (direction == 5)
            {
                n = 270;
                y = -.5f;
            }
        }

        Quaternion q = Quaternion.Euler(0, 0, n);
        Vector3 v = new Vector3(transform.position.x + (x*1.5f), transform.position.y + (y*1.5f), 0);
        Instantiate(beam, v, q);
    }

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

        cdcount -= Time.deltaTime;

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

        if (Input.GetButtonDown("Fire1"))
        {
            if (cdcount <= 0)
            {
                Shoot();
                cdcount = cooldown;
            }
        }

    }
}