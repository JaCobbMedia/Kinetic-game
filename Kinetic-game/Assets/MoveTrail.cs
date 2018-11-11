using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour {

    public float speed;

    private Transform player;

    private Vector2 direction;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        direction = (player.transform.position - transform.position).normalized;
    }

    void Update () {
        transform.Translate(direction * Time.deltaTime * speed);
        Destroy(gameObject, 1);
	}
}
