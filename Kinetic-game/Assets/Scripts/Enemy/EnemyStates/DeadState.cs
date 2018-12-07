using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IEnemyState
{

    private Enemy enemy;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
        this.enemy.animator.SetTrigger("die");
    }

    public void Execute()
    {
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
    }
}
