using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player1 : MonoBehaviour
{
    int moveSpeed = 5;
    int jumpHeight = 15;
    int winner;
    int lives;

    Animator animator;

    private SpriteRenderer spriteRenderer;
    bool isGrounded;
    Rigidbody2D rb2d;
    Vector3 originalPos;
    public static AudioSource audioSrc;
    public GameObject heart1, heart2, heart3;
    //public static int lives;

    [SerializeField] 
    Transform groundCheck;
   
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer> ();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        originalPos = gameObject.transform.position;
        lives = 3;
        audioSrc = GetComponent<AudioSource>();
        heart1.gameObject.SetActive (true);
        heart2.gameObject.SetActive (true);
        heart3.gameObject.SetActive (true);
    }

    public static double abs(double val)
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


    // Start is called before the first frame update
    private void FixedUpdate()
    {

        if (lives == 0)
        {

            winner = 2;
            SceneManager.LoadScene("EndScreen2");
        }


        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetKey("a"))
        {


            if (abs(rb2d.velocity.x) < moveSpeed)
            {
                rb2d.velocity += new Vector2(0 - moveSpeed, 0);
                //animator.Play("PWalking");
            }

        }

        if (Input.GetKey("d"))
        {

            if (abs(rb2d.velocity.x) < moveSpeed)
            {
                rb2d.velocity += new Vector2(moveSpeed, 0);
                //animator.Play("PWalking");
            }

        }



        if (Input.GetKey("w") && isGrounded)
        {
            rb2d.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            //animator.Play("PJump");
        }


        if (!Input.anyKey)
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            //animator.Play("PattisIdle");
        }
        
        bool flipSprite = (spriteRenderer.flipX ? (rb2d.velocity.x > 0.01f) : (rb2d.velocity.x < -0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        else
        {
            spriteRenderer.flipX = spriteRenderer.flipX;
        }
        
        if (lives > 3)
        {
             lives = 3;
        }
        switch (lives)
        {
            case 3:
                heart1.gameObject.SetActive (true);
                heart2.gameObject.SetActive (true);
                heart3.gameObject.SetActive (true);
                break;
            case 2:
                heart1.gameObject.SetActive (true);
                heart2.gameObject.SetActive (true);
                heart3.gameObject.SetActive (false);
                break;  
            case 1:
                heart1.gameObject.SetActive (true);
                heart2.gameObject.SetActive (false);
                heart3.gameObject.SetActive (false);
                break; 
            case 0:
                heart1.gameObject.SetActive (false);
                heart2.gameObject.SetActive (false);
                heart3.gameObject.SetActive (false); 
                break;
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "deathbox")
        {
            audioSrc.Play();
            lives -= 1;
            gameObject.transform.position = originalPos;
        }
    }

}
