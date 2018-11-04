using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour {

    private Enemy enemy;

    private void Start()
    {
        enemy = gameObject.GetComponentInParent(typeof(Enemy)) as Enemy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InvokeCollision(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        InvokeCollision(collision);
    }

    private void InvokeCollision(Collider2D collision)
    {
        if (collision.tag == "Terrain")
        {
            if (enemy != null)
            {
                enemy.HasCollided();
            }
        }
    }
}
