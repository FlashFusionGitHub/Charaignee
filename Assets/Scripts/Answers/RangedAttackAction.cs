using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class RangedAttackAction : AIBehaviour {

    public GameObject projectile;
    public GameObject projectile_spawn_point;
    public PlayerWithinRangedAttackRange player_within_ranged_attack_range;

    public float projectile_speed = 50.0f;
    public float shot_time = 1.0f;

    private float shot_timer = 0.0f;

    private FirstPersonController player;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<FirstPersonController>();

    }

    public override BehaviourResult Execute(NavMeshAgent agent)
    {
        if(player_within_ranged_attack_range.Execute(agent) == BehaviourResult.Success)
        {
            agent.velocity = new Vector3(0, 0, 0);

            if(shot_timer <= 0)
            {
                Shoot();
            }

            shot_timer -= Time.deltaTime;
        }

        return AIBehaviour.BehaviourResult.Success;
    }

    void Shoot()
    {
        GameObject theProjectile = Instantiate(projectile);

        theProjectile.transform.position = projectile_spawn_point.transform.position;

        Rigidbody rb = theProjectile.GetComponent<Rigidbody>();

        Vector3 direction = player.transform.position - theProjectile.transform.position;

        rb.velocity = direction * projectile_speed;

        shot_timer = shot_time;

        Destroy(theProjectile, 3.0f);
    }
}
