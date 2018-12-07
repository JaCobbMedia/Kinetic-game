using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    public float health;
    private Animator animator;
    public Transform spawn;
    private PlayerMovement playerMovement;

	void Start () {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
	}
	
	void Update () {

        animator.SetFloat("health", health);
        if (health <= 0)
        {
            StartCoroutine(Respawn());
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

    private IEnumerator Respawn()
    {
        Debug.Log("playerStatus");
        playerMovement.ChangeControlStatus(false);
        yield return new WaitForSeconds(2);
        health = 100;
        gameObject.transform.position = spawn.position;
        yield return new WaitForSeconds(2);
        playerMovement.ChangeControlStatus(true);
    }  
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Damage")
        {
            TakeDamage(5);
        }
    }
}
