using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour{

    public NavMeshAgent agent;

    public float health = 100;

    public PatrolAction patrol;
    public PurseAction purse;
    public AttackAction attack;
    public PlayerWithinPurseRange player_within_pursue_range;
    public PlayerWithinAttackRange player_within_attack_range;

    private AIBehaviour aibehaviour;
    private AIBehaviour aibehaviour2;
    private AIBehaviour aibehaviour3;

    public Animator melee_animator;

    // Use this for initialization
    void Start() {
        aibehaviour = patrol;
        aibehaviour2 = purse;
        aibehaviour3 = attack;
    }

    // Update is called once per frame
    void Update()
    {
        if (player_within_pursue_range.Execute(agent) == AIBehaviour.BehaviourResult.Success)
        {
            aibehaviour2.Execute(agent);
            melee_animator.SetInteger("Speed", 1);
        }
        else
        {
            aibehaviour.Execute(agent);
            melee_animator.SetInteger("Speed", -1);
        }


        if (player_within_attack_range.Execute(agent) == AIBehaviour.BehaviourResult.Success)
        {
            aibehaviour3.Execute(agent);
            melee_animator.SetBool("isAttacking", true);
        }
        else
        {
            melee_animator.SetBool("isAttacking", false);
        }
    

        if(health <= 0)
        {
            Destroy(agent.gameObject);
        }
    }

    public void agentTakeDamage(float playerAttack)
    {
        health -= playerAttack;
    }
}
