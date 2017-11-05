using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public float damage = 1;
    public float fireRate = 1;
    public int ammo = 36;
    public int magazine = 6;
    public Transform spawnPoint;

    private float fireDelay;
    private Camera fpsCam;
    private LineRenderer bulletTrail;
    private WaitForSeconds trailLife = new WaitForSeconds(0.07f);

    // Use this for initialization
    void Start()
    {
        bulletTrail = GetComponent<LineRenderer>();
        fpsCam = GetComponentInParent<Camera>();

        fireDelay = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && fireDelay >= fireRate)
        {
            fireDelay = 0;

            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            RaycastHit hit;

            // moves the bulletTrail to the end of the spawn point
            bulletTrail.SetPosition(0, spawnPoint.position);

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit))
            {

                bulletTrail.SetPosition(1, hit.point);
                Enemy enemyHealth = hit.collider.GetComponent<Enemy>();

                if (enemyHealth != null)
                {
                    enemyHealth.takeDamage(damage);
                }
            }
        else {
            bulletTrail.SetPosition(1, rayOrigin + (fpsCam.transform.forward));
        }
        }
        fireDelay += 1 * Time.deltaTime;
    }

    private IEnumerator ShotEffect() {
        bulletTrail.enabled = true;
        yield return trailLife;
            bulletTrail.enabled = false;
    }
}
