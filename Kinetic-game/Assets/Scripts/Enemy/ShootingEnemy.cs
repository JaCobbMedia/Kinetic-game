using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy {

    [SerializeField]
    private Transform gunPosition;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float shootingRange;

    public override void Attack()
    {
        if (direction == 1)
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

    public override bool InMeleeRange()
    {
        return false;
    }

    public override bool InShootingRange()
    {
        if (Target != null)
        {
            return Vector2.Distance(transform.position, Target.transform.position) <= shootingRange;
        }
        else
        {
            return false;
        }
    }
}
