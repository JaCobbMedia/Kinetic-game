using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeState : IEnemyState
{
    private Enemy enemy;

    private float attackTimer;

    private float attackCooldown = 1f;

    private bool canAttack = true;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        Attack();
        if (enemy.Target == null || !enemy.InMeleeRange())
        {
            enemy.ChangeState(new PatrolState());
        }
    }

    public void Exit()
    {
    }

    public void OnTriggerEnter(Collider2D other)
    {
        if (other.tag == "Edge")
        {
            enemy.ChangeDirection();
        }
    }

    private void Attack()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackCooldown)
        {
            canAttack = true;
            attackTimer = 0;
        }
        if (canAttack)
        {
            enemy.Attack();
            canAttack = false;
        }
    }
}
