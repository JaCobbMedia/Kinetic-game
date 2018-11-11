using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour {

    private LineRenderer lineRenderer;
    public Transform laserHitPoint;


	void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;
	}
	
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up);

        laserHitPoint.position = hit.point;

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, laserHitPoint.position);

        if(lineRenderer.enabled == true && hit.collider.tag == "Player")
        {
            Laser_mechanics laser_Mechanics = gameObject.GetComponentInParent(typeof(Laser_mechanics)) as Laser_mechanics;
            laser_Mechanics.HitTarget(hit.collider.gameObject);
        }

	}

    public IEnumerator ShootLaser()
    {
        yield return new WaitForSeconds(3);
        lineRenderer.enabled = true;
    }

    public IEnumerator DisableLaser()
    {
        yield return new WaitForSeconds(2);
        lineRenderer.enabled = false;
    }
}
