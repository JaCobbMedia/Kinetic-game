using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {


    public float health;

	void Start () {
	}
	
	void Update () {

        if(health <= 0)
        {
            Destroy(gameObject);
        }
		
	}

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void RegenerateHealth(float add)
    {
        health += add;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Damage")
        {
            TakeDamage(5);
        }
    }
}
