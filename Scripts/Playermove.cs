using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;

    Rigidbody2D rb2D;

    public bool betterJump = false;

    public float fallMultiplier = 0.5f;

    public float lowJumpMultiplier = 1f;

    public SpriteRenderer spriteRenderer;
    public Animator animator;



    public float dashCooldown;
    public float dashForce=30; 
    public GameObject dashParticle;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        dashCooldown -= Time.deltaTime;    
    }

    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);

            if (Input.GetKey("e") && dashCooldown <= 0)
            {
                Dash();
            }
        }



        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);

            if (Input.GetKey("e") && dashCooldown <= 0)
            {
                Dash();
            }
        }


        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }

        if (Input.GetKey("space") && Checkground.isgrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }

        if (Checkground.isgrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }

        if (Checkground.isgrounded == true)
        {
            animator.SetBool("Jump", false);
        }



        if (betterJump) 
        {
            if (rb2D.velocity.y<0)
            {
                rb2D.velocity += Vector2.up*Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if (rb2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up* Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }

        if (Input.GetKey("e") && dashCooldown <= 0)
        {
            Dash();
        }

    }
    public void Dash()
    {
        GameObject dashObject;

        dashObject = Instantiate(dashParticle, transform.position, transform.rotation);

        if (spriteRenderer.flipX == false)
        {
            rb2D.AddForce(Vector2.right* dashForce, ForceMode2D.Impulse);
        }
        else
        {
            rb2D.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
        }

        dashCooldown = 2;
        Destroy(dashObject, 1);

    }
}
