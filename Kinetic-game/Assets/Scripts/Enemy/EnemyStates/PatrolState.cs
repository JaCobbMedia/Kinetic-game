using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{

    private Enemy enemy;

    private float patrolTimer;

    private float patrolDuration = 10f;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
        this.enemy.ChangeDirection();
    }

    public void Execute()
    {
        Patrol();
        if (enemy.Target != null && enemy.InMeleeRange())
        {
            enemy.ChangeState(new MeleeState());
        }

        if (enemy.Target != null && enemy.InShootingRange())
        {
            enemy.ChangeState(new RangedState());
        }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        if(other.tag == "Edge")
        {
            enemy.ChangeDirection();
        }
    }

    private void Patrol()
    {
        patrolTimer += Time.deltaTime;

        enemy.Move();
        if (patrolTimer >= patrolDuration)
        {
            this.enemy.ChangeState(new IdleState());
        }
    }
}
