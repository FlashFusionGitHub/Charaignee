using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;

//if the player within attack question returns a result of success
//the agent will set its velocity to zero, it will then begin attacking the 
//player when its attack timer is zero, when it has completed the attack its attack timer will reset
//when the action is complete it will return a result of success

public class AttackAction : AIBehaviour
{
    public int damageToApply = 20;
    public float AttackTimer = 0;
    public int AttackTime = 2;
    public float attackDistance = 1.5f;
    public PlayerWithinAttackRange player_within_attack_range;
    private HealthBar playerHealth;

    public AudioSource audioSourceAttack;

    void Start()
    {
        playerHealth = FindObjectOfType<HealthBar>();
    }

    public override BehaviourResult Execute(NavMeshAgent agent)
    {
        if(player_within_attack_range.Execute(agent) == BehaviourResult.Success)
        {
            agent.velocity = new Vector3(0, 0, 0);

            AttackTimer -= Time.deltaTime;

            if (AttackTimer <= 0)
            {
                audioSourceAttack.Play();
                playerHealth.TakeDamge(damageToApply);
                AttackTimer = AttackTime;
            }
        }

        return BehaviourResult.Success;
    }
}
