using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float fireRate = 0f;

    public float damage = 10f;

    public LayerMask masksToHit;

    public Enemy enemyScript;

    public Transform bulletTrailPrefab;

    private float timeToFire = 0f;

    Transform firePoint;

    private Transform player;

    private PlayerStatus playerStatus;

	void Awake () {
        firePoint = transform.Find("FirePoint");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerStatus = player.GetComponent<PlayerStatus>();
    }

	void Update () {
		if(Time.time > timeToFire && enemyScript.IsReadyToFire())
        {
            Shoot();
            timeToFire = Time.time + 1 / fireRate;
        }
	}

    private void Shoot()
    {
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        Vector2 playerPosition = new Vector2(player.position.x, player.position.y);

        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, playerPosition - firePointPosition, 100, masksToHit);

        Effect();
        if (hit.collider != null && IsPlayer(hit.collider))
        {
            playerStatus.TakeDamage(damage);
        }
    }

    private void Effect()
    {

        Instantiate(bulletTrailPrefab, firePoint.position, player.rotation);
    }

    private bool IsPlayer(Collider2D collision)
    {
        return collision.tag == "Player";
    }
}
