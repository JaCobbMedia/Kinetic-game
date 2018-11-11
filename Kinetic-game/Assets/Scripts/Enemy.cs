using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed;

    public float playerStoppingDistance;

    public float spawningStoppingDistance;

    private Transform player;

    public CharacterController2D controller;

    public Animator animator;

    private float direction = 0f;

    private float currentFacing = 0f;

    private Vector2 spawningPosition;

    private bool jump;

    private bool isTriggered = false;

	void Start () {
        spawningPosition = new Vector3(transform.position.x, transform.position.y);
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update () {
        if(isTriggered && !IsInPlayerStoppingDistance())
        {
            ResolveFacingDirection(player.position);
            ResolveMovingDirection(player.position);
        }
        if(!isTriggered && !IsInSpawningDistance())
        {
            ResolveFacingDirection(spawningPosition);
            ResolveMovingDirection(spawningPosition);
        }

	}

    void ResolveFacingDirection(Vector2 targetPosition)
    {
        if (CalculateDirection(targetPosition, transform.position) != currentFacing)
        {
            controller.Flip();
            currentFacing = CalculateDirection(targetPosition, transform.position);
        }
    }

    void ResolveMovingDirection(Vector2 targetPosition)
    {
        if ((isTriggered && !IsInPlayerStoppingDistance()) || (!isTriggered && !IsInSpawningDistance()))
        {
            direction = CalculateDirection(targetPosition, transform.position);
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

    private bool IsInPlayerStoppingDistance()
    {
        return (Vector2.Distance(transform.position, player.position) < playerStoppingDistance);
    }

    private bool IsInSpawningDistance()
    {
        return (Vector2.Distance(transform.position, spawningPosition) < spawningStoppingDistance);
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
        if ((isTriggered && !IsInPlayerStoppingDistance()) || (!isTriggered && !IsInSpawningDistance()))
        {
            controller.Move(direction * speed * Time.deltaTime, false, jump);
            animator.SetFloat("speed", Mathf.Abs(direction));
            jump = false;
        }
    }

    public bool IsReadyToFire()
    {
        return (isTriggered && IsInPlayerStoppingDistance());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsPlayer(collision))
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(IsPlayer(collision))
        {
            isTriggered = false;
        }
    }

    private bool IsPlayer(Collider2D collision)
    {
        return collision.tag == "Player";
    }
}
