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
        //move
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //animation to walk
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            //able to jump
            jump=true;
            //animation jumping
            animator.SetBool("isJumping", true);
        }
        if (Input.GetKey(KeyCode.M)) MenuManager.Instance.UpdateGameState(GameState.PauseGame);
    }

    void FixedUpdate()
    {      
        //move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        //not able to jump
        jump=false;
    }

    public void OnLanding()
    {
    // when land back to idle animation
    animator.SetBool("isJumping", false);
    } 
}