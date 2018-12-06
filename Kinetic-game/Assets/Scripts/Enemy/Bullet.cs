using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

    [SerializeField]
    private float speed;

    private Rigidbody2D myRigidBody;

    private Vector2 direction;

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
}
