using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsPlayer(collision) || IsEnemy(collision))
        {
            DamageTarget(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(IsPlayer(collision) || IsEnemy(collision))
        {
        }
    }

    private bool IsPlayer(Collider2D collision)
    {
        return collision.tag == "Player";
    }

    private bool IsEnemy(Collider2D collision)
    {
        return collision.tag == "Enemy";
    }

    public void DamageTarget(GameObject hitTarget)
    {
        //Destroy(hitTarget);
        PlayerStatus player = hitTarget.GetComponent<PlayerStatus>();
        if(player != null)
        {
            player.TakeDamage(200f);
        }
        Enemy enemy = hitTarget.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.Die();
        }
    }
}