using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    private IEnemyState currentState;

    public GameObject Target { get; set; }

    [SerializeField]
    public float speed;

    public CharacterController2D controller;

    public Animator animator;

    public bool Attack { get; set; }

    [SerializeField]
    private Transform gunPosition;

    [SerializeField]
    private GameObject bulletPrefab;

    private float direction = 1f;

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

    public void Shoot()
    {
        if(direction == 1)
        {
            GameObject tmp = (GameObject)Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
            tmp.GetComponent<Bullet>().Initialize(Vector2.right);
        } 
        else
        {
            GameObject tmp = (GameObject)Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
            tmp.GetComponent<Bullet>().Initialize(Vector2.left);
        }
    }
}
