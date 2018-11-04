using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;

    public Animator animator;

    private float horizontalMove = 0f;

    public float movementSpeed;

    private bool jump = false;

	void Update ()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        jump = Input.GetButtonDown("Jump");
	}

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
