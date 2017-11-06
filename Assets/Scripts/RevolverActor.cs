﻿using System.Collections;
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

	// Use this for initialization
	void Start () {
        item = FindObjectOfType<ItemPickUp>();
        agent = FindObjectOfType<Agent>();
        gamePad = InputManager.ActiveDevice;
	}
	
	// Update is called once per frame
	void Update () {

	    shot_timer -= Time.deltaTime;

        if(Input.GetMouseButtonDown(0) && shot_timer <= 0.0f && item.canFire == true)
        {
            muzzle_flash.Play();
            item.Shoot();
            Shoot();
            shot_timer = shot_time;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            item.reloadGun();
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
            item.reloadGun();
        }
#endif
    }


    void Shoot()
    {
        RaycastHit hit;
        GameObject impact_object;

        if (Physics.Raycast(ray_cast_point.transform.position, ray_cast_point.transform.forward, out hit, range))
        {
            if(hit.transform.tag == "Enemy")
            {
                impact_object = Instantiate(enemy_impact_effect, hit.point, Quaternion.LookRotation(hit.normal));

                hit.transform.gameObject.GetComponent<Agent>().agentTakeDamage(damage);
            }
            else
                impact_object = Instantiate(impact_effect, hit.point, Quaternion.LookRotation(hit.normal));

            Destroy(impact_object, 1.0f);
        }
    }
}