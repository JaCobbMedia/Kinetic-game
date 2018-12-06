using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedState : IEnemyState
{

    private Enemy enemy;

    private float shootTimer;

    [SerializeField]
    private float shootCooldown = 1f;

    private bool canShoot = true;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        Shoot();

        if(enemy.Target != null)
        {
            enemy.Move();
        }
        else
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

    private void Shoot()
    {
        shootTimer += Time.deltaTime;

        if(shootTimer >= shootCooldown)
        {
            canShoot = true;
            shootTimer = 0;
        }
        if(canShoot)
        {
            enemy.Shoot();
            canShoot = false;
        }
    }
}
