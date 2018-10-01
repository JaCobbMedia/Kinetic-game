using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_mechanics : MonoBehaviour {

    public float speed;
    public float torqSpeed;
    public float speedReduced;
    public float jumpForce = 3.0f;

    private float moveHori;
    private float moveVert;

    private bool inAir = true;

    private Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate () {

        //Debug.Log(inAir);
        moveHori = Input.GetAxis("Horizontal");
        moveVert = Input.GetAxis("Vertical");

        var movement = new Vector2(moveHori, 0.0f);

        if (!inAir)
        {

            rb.AddTorque(-moveHori * torqSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
            rb.AddForce(movement * speed * Time.fixedDeltaTime);
        }
        rb.AddForce(movement * speedReduced);

        if (Input.GetKeyDown(KeyCode.W) && !inAir)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        inAir = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        inAir = true;
    }


}
