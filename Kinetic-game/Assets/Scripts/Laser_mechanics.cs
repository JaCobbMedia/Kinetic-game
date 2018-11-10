using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_mechanics : MonoBehaviour {

    private Quaternion rotation = new Quaternion(0,0,180,1);
    private Quaternion desiredRot;
    private GameObject target;
    private LaserSpawner laserSpawner;
    public float rotationSpeed = 10;
    public float laserDamage = 30f;

    private void Start()
    {
        target = GameObject.FindWithTag("Player");
        laserSpawner = GameObject.Find("Laser_beam_spawn").GetComponent<LaserSpawner>();
    }

    void Update () {

        if (target != null)
        {
            var targetDistance = Vector3.Distance(transform.position, target.transform.position);

            if (targetDistance < 13.0f)
            {
                    rotation = Quaternion.LookRotation(target.transform.position - transform.position, transform.TransformDirection(Vector3.down));
                    desiredRot = new Quaternion(0, 0, rotation.z, rotation.w);
                    StartCoroutine(laserSpawner.ShootLaser());
            }
            else
            {
                desiredRot = new Quaternion(0, 0, 0, 1);
                StartCoroutine(laserSpawner.DisableLaser());
            }
        }
        else
        {
            desiredRot = new Quaternion(0, 0, 0, 1);
            StartCoroutine(laserSpawner.DisableLaser());
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRot, rotationSpeed * Time.deltaTime);
    }

    public void HitTarget(GameObject hitTarget)
    {
        //Destroy(hitTarget);
        hitTarget.GetComponent<PlayerStatus>().TakeDamage(laserDamage);
    }
}
