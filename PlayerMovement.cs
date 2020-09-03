using System.Collections;
using System.Collections.Generic;
//using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5;
    public float jumpCount = 3;
    int jumpHeight = 15;
    //int lives =
    //int y_thresh
    //if under a certain y_thresh, subtrack life

    bool isGrounded;
    Rigidbody2D rb2d;

    [SerializeField]
    Transform groundCheck;
  


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    double abs(double val)
    {
        if (val < 0)
        {
            return (-1) * val;
        }
        else
        {
            return val;
        }
    }

    private void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            if(abs(rb2d.velocity.x) < moveSpeed)
            {
                rb2d.velocity += new Vector2(moveSpeed, 0);
            }
        }
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {
            if(abs(rb2d.velocity.x) < moveSpeed )
            {
                rb2d.velocity += new Vector2(0 - moveSpeed, 0);
            }
        }

        if (!Input.anyKey)
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if ((Input.GetKey("space") || Input.GetKey(KeyCode.UpArrow)) && isGrounded)
        {
            //rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
            rb2d.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);

        }
    }



}




//private void FixedUpdate()
//{
//    if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
//    {
//        isGrounded = true;
//    }
//    else
//    {
//        isGrounded = false;
//    }

//    if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
//    {
//        rb2d.velocity = new Vector2(moveSpeed, 0);
//    }
//    else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
//    {
//        rb2d.velocity = new Vector2(0 - moveSpeed, 0);
//    }
//    else
//    {
//        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
//    }

//    if ((Input.GetKey("space") || Input.GetKey(KeyCode.UpArrow)) && isGrounded)
//    {
//        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
//        //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 2), ForceMode2D.Impulse);

//    }
//}

