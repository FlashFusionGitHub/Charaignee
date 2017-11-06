using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;

public class AttackAction : AIBehaviour
{
    public int damageToApply = 20;
    public float AttackTimer = 0;
    public int AttackTime = 2;
    public float attackDistance = 1.5f;
    public PlayerWithinAttackRange player_within_attack_range;
    //private HealthBar playerHealth;

    void Start()
    {
        //playerHealth = FindObjectOfType<HealthBar>();
    }

    public override BehaviourResult Execute(NavMeshAgent agent)
    {
        if(player_within_attack_range.Execute(agent) == BehaviourResult.Success)
        {
            agent.velocity = new Vector3(0, 0, 0);

            //AttackTimer -= Time.deltaTime;

            //if (AttackTimer <= 0)
            //{
            //    playerHealth.health -= damageToApply;
            //    AttackTimer = AttackTime;
            //}
        }

        return BehaviourResult.Success;
    }
}
