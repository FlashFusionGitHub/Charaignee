using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class RevolverActor : MonoBehaviour {

    private float shot_timer = 0;

    public Camera ray_cast_point;
    public ParticleSystem muzzle_flash;
    public GameObject enemy_impact_effect;
    public GameObject impact_effect;

    public float damage = 50.0f;
    public float range = 150.0f;

    public float shot_time = 1;

    private ItemPickUp item;

    private InputDevice gamePad;

    public Agent agent;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        item = FindObjectOfType<ItemPickUp>();
        agent = FindObjectOfType<Agent>();
        gamePad = InputManager.ActiveDevice;
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

	    shot_timer -= Time.deltaTime;

        if(Input.GetMouseButtonDown(0) && shot_timer <= 0.0f && item.canFire == true)
        {
            muzzle_flash.Play();
            item.Shoot();
            Shoot();
            audioSource.Play();
            shot_timer = shot_time;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            item.canFire = false;
            item.reloadGun();
            GetComponent<Animator>().Play("Reload", 0);
        }

#if UNITY_PS4
        if(gamePad.RightTrigger.WasPressed && shot_timer <= 0.0f && item.canFire == true)
        {
            muzzle_flash.Play();
            item.Shoot();
            Shoot();
            shot_timer = shot_time;
        }

        if (gamePad.Action3.WasPressed)
        {
            item.canFire = false;
            item.reloadGun();
            GetComponent<Animator>().Play("Reload", 0);
        }
#endif
    }


    void Shoot()
    {
        GetComponent<Animator>().Play("Shoot",0);

        RaycastHit hit;
        GameObject impact_object;

        if (Physics.Raycast(ray_cast_point.transform.position, ray_cast_point.transform.forward, out hit, range))
        {
            if(hit.transform.tag == "Enemy")
            {
                impact_object = Instantiate(enemy_impact_effect, hit.point, Quaternion.LookRotation(hit.normal));

                hit.transform.gameObject.GetComponent<Agent>().agentTakeDamage(damage);
            }
            else if (hit.transform.tag == "RangedEnemy")
            {
                impact_object = Instantiate(enemy_impact_effect, hit.point, Quaternion.LookRotation(hit.normal));

                hit.transform.gameObject.GetComponent<RangedAgent>().agentTakeDamage(damage);
            }
            else if (hit.transform.tag == "Boss")
            {
                impact_object = Instantiate(enemy_impact_effect, hit.point, Quaternion.LookRotation(hit.normal));

                hit.transform.gameObject.GetComponent<BossActor>().BossTakeDamage(damage);
            }
            else if (hit.transform.tag == "Wall")
            {
                impact_object = Instantiate(impact_effect, hit.point, Quaternion.LookRotation(hit.normal));

                hit.transform.gameObject.GetComponent<WallActor>().wallTakeDamage(damage);
            }
            else
                impact_object = Instantiate(impact_effect, hit.point, Quaternion.LookRotation(hit.normal));

            Destroy(impact_object, 1.0f);
        }
    }
}
