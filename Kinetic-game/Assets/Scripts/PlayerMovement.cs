using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;

    public Animator animator;

    private float horizontalMove = 0f;

    public float movementSpeed;

    private bool jump = false;
    private bool canControl = true;

	void Update ()
    {
        if (canControl)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed;
            animator.SetFloat("speed", Mathf.Abs(horizontalMove));
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("isJumping", true);
            }
        } 
	}

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void OnLanding()
    {
        Debug.Log("landing");
        animator.SetBool("isJumping", false);
    }

    public void ChangeControlStatus(bool status)
    {
        canControl = status;
    }
}
