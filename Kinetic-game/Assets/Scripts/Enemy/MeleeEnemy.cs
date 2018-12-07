using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy {

    [SerializeField]
    private float meleeRange;

	public override void Attack()
    {
        PlayAnimation();

    }

    private void PlayAnimation()
    {
        animator.SetFloat("speed", 0);
        if (Random.Range(0, 2) % 2 == 0)
        {
            animator.SetTrigger("attack");
        }
        else
        {
            animator.SetTrigger("secondAttack");
        }
    }

    public override bool InMeleeRange()
    {
        if (Target != null)
        {
            return Vector2.Distance(transform.position, Target.transform.position) <= meleeRange;
        }
        else
        {
            return false;
        }
    }

    public override bool InShootingRange()
    {
        return false;
    }
}
