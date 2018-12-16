﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    public delegate void HealthEventHander(float damage);
    public event HealthEventHander EventHealthDeduction;

    public float maxHealth = 100f;
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
        if (EventHealthDeduction != null)
        {
            EventHealthDeduction(damage);
        }
    }

    public void RegenerateHealth(float add)
    {
        health += add;
    }

    private IEnumerator Respawn()
    {
        playerMovement.ChangeControlStatus(false);
        yield return new WaitForSeconds(2);
        health = maxHealth;
        gameObject.transform.position = spawn.position;
        yield return new WaitForSeconds(2);
        playerMovement.ChangeControlStatus(true);
    }  
}
