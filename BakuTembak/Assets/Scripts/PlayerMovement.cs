using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
// Start is called before the first frame update
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump=true;
            animator.SetBool("isJumping", true);
        }
        
    }

    void FixedUpdate()
    {      
        //move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump=false;
    }

    public void OnLanding()
    {
    animator.SetBool("isJumping", false);
    } 
}