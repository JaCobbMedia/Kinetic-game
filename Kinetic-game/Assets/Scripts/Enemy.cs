﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed;

    public float stoppingDistance;

    private Transform player;

    public CharacterController2D controller;

    private float direction = 0f;

    private float currentFacing = 0f;

    public bool jump;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update () {
        ResolveFacingDirection();
        ResolveMovingDirection();
	}

    void ResolveFacingDirection()
    {
        if (CalculateDirection(player.position, transform.position) != currentFacing)
        {
            controller.Flip();
            currentFacing = CalculateDirection(player.position, transform.position);
        }
    }

    void ResolveMovingDirection()
    {
        if (!IsInStoppingDistance())
        {
            direction = CalculateDirection(player.position, transform.position);
        }
        else
        {
            if (direction != 0)
            {
                currentFacing = direction;
            }
            direction = 0;
        }
    }

    private bool IsInStoppingDistance()
    {
        return (Vector2.Distance(transform.position, player.position) < stoppingDistance);
    }

    float CalculateDirection(Vector2 targetPos, Vector2 currentPos)
    {
        if(targetPos.x > currentPos.x)
        {
            return 1;
        } else
        {
            return -1;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(direction * speed * Time.deltaTime, false, jump);
        Debug.Log(jump);
        jump = false;
    }

    public void HasCollided()
    {
        Debug.Log("has collided");
        if(!IsInStoppingDistance())
        {
            jump = true;
        }
    }
}
