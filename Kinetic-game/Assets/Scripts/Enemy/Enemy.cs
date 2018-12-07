using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public abstract class Enemy : MonoBehaviour {

    private IEnemyState currentState;

    public GameObject Target { get; set; }

    [SerializeField]
    public float speed;

    [SerializeField]
    private float deathTime = 5f;

    public CharacterController2D controller;

    public Animator animator;

    protected float direction = 1f;

    public abstract void Attack();

    public abstract bool InMeleeRange();

    public abstract bool InShootingRange();

    void Start () {
        ChangeState(new IdleState());
	}
	
    private void FixedUpdate()
    {
        currentState.Execute();
    }

    public void ChangeState(IEnemyState newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;

        currentState.Enter(this);
    }

    public void Move()
    {
        LookAtTarget();
        controller.Move(direction * speed * Time.deltaTime, false, false);
        animator.SetFloat("speed", Mathf.Abs(direction));
    }

    public void ChangeDirection()
    {
        direction = -direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentState.OnTriggerEnter(collision);
    }

    private void LookAtTarget()
    {
        if (Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;

            if ((xDir < 0 &&  direction == 1) || (xDir > 0 && direction == -1))
            {
                ChangeDirection();
            }
        }
    }

    public void Die()
    {
        ChangeState(new DeadState());
        Destroy(gameObject, deathTime);
    }

}
