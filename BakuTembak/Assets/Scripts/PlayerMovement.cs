using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;
    private bool facingRight;
    // private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        
        moveSpeed = 3f;
        jumpForce = 60f;
        isJumping = false;
        facingRight = true;

    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }
        

        // updating with the physic engine inside unity
    void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
            transform.Translate (new Vector3 (moveHorizontal * moveSpeed * Time.deltaTime, 0f, 0f));
            if (moveHorizontal > 0.1f && !facingRight) 
            {
                //If we're moving right but not facing right, flip the sprite and set facingRight to true.
                Flip ();
                facingRight = true;
            } 
            if (moveHorizontal < 0.1f && facingRight) 
            {
                //If we're moving left but not facing left, flip the sprite and set facingRight to false.
                Flip ();
                facingRight = false;
            }

        }
        if (!isJumping && moveVertical > 0.1f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }
        //Player Movement. Check for horizontal movement
        // if (moveHorizontal > 0.1f || moveHorizontal < -0.1f) 
        // {
            
        // }
        //If we're not moving horizontally, check for vertical movement. The "else if" stops diagonal movement. Change to "if" to allow diagonal movement.
        if (moveVertical > 0.1f || moveVertical < -0.1f) 
        {
            transform.Translate (new Vector3 (0f, moveVertical * moveSpeed * Time.deltaTime, 0f));
        }

        // //Variables for the animator to use as params
        // anim.SetFloat ("MoveX", moveHorizontal);
        // anim.SetFloat ("MoveY", moveVertical);
        // }

        void Flip()
        {
            // Switch the way the player is labelled as facing
            facingRight = !facingRight;

            // Multiply the player's x local scale by -1
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    } 
}
