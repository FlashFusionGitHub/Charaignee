using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;


//the PlayerWithinAttackRange question asks if the player is within a specified distance
//from the player, if the condition is true then the behaviour/question return a result of success
//otherwise it returns failure

public class PlayerWithinAttackRange : AIBehaviour
{
    public float range = 2.0f;

    private FirstPersonController player;

    void Start()
    {
        player = FindObjectOfType<FirstPersonController>();
    }

    public override BehaviourResult Execute(NavMeshAgent agent)
    {
        if (Vector3.Distance(agent.transform.position, player.transform.position) < range)
            return BehaviourResult.Success;
       
        return BehaviourResult.Failure;
    }
}
