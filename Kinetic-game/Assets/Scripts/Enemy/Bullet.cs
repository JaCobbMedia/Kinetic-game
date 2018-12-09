using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

    [SerializeField]
    private float speed;

    private Rigidbody2D myRigidBody;

    private Vector2 direction;

    [SerializeField]
    private float damage;

	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        myRigidBody.velocity = direction * speed;		
	}

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void Initialize(Vector2 direction)
    {
        this.direction = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStatus>().TakeDamage(damage);
            Destroy(gameObject, 1);
        }
    }
}
